using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.ModelTransformations.Services.Saga;

namespace MDDPlatform.ModelTransformations.Services.DomainServices;
public class ProcessExecutor : IProcessExecutor
{
    private readonly IExecutableProcessRepository _repository;
    private readonly IPatternInstanceTemplateRepository _templateRepository;
    private readonly IProcessNotificationService _notificationService;
    private ITransformationService _transformationService;
    private ISagaRepository _sagaRepository;

    public ProcessExecutor(IExecutableProcessRepository repository, IPatternInstanceTemplateRepository templateRepository, IProcessNotificationService notificationService, ITransformationService transformationService, ISagaRepository sagaRepository)
    {
        _repository = repository;
        _templateRepository = templateRepository;
        _notificationService = notificationService;
        _transformationService = transformationService;
        _sagaRepository = sagaRepository;
    }

    public async Task ExecuteProcessAsync(ExecutableProcess executableProcess)
    {

        if(Equals(executableProcess,null))
            throw new Exception("Executable process not found");
        
        if(executableProcess.Status == ProcessExecutionStatus.Done)
            throw new Exception("Process Execution is Done ...");

        var taskInstance = executableProcess.NextTask();
        if(taskInstance == null)
            throw new Exception("Task instance is Null");
        
        if(taskInstance.Type == TaskType.PatternInstanceExecution)
        {
            ProcessSaga saga = ProcessSaga.Create(executableProcess.Id,taskInstance.Id);
            var coordinationId = saga.ExternalCoordinationId;
            var stepId = saga.ExternalStepId;
            await _sagaRepository.CreateAsync(saga);

            try
            {
                executableProcess.StartTask(taskInstance.Id);
                var taskTemplate = await _templateRepository.GetTemplateAsync(taskInstance.TemplateId);
                if(Equals(taskTemplate,null))
                    throw new Exception("Task template not found");
            
                await _notificationService.TaskIsExecutingAsync(executableProcess.Id,taskInstance.Id,executableProcess.Status);
                await _repository.UpdateAsync(executableProcess);
                
                var fieldValues = taskInstance.Attributes.Select(taskAttribute=> new FieldValue(taskAttribute.Name,taskAttribute.Value)).ToList();
                
                await _transformationService.ExecutePatternInstanceAsync(taskTemplate.PatternName,fieldValues,coordinationId,stepId);

            }catch(Exception ex)
            {                
                Console.WriteLine("------------Process Executor Failed -------------");
                Console.WriteLine(ex.Message);
                executableProcess.ResetTask(taskInstance.Id);
                await _repository.UpdateAsync(executableProcess);
                await _sagaRepository.DeleteAsync(saga.Id);
            }

        }
    }

    
}