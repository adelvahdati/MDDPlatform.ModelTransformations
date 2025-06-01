using MDDPlatform.Messages.Events;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.ModelTransformations.Services.Saga;
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.ModelTransformations.Services.ExternalEvents;
public class ModelOperationCompleted : IDomainEvent
{
    public Guid CoordinationId {get;set;}        
    public Guid StepId {get;set;}
    public string Action {get;set;} = string.Empty;

    public ModelOperationCompleted(Guid coordinationId, Guid stepId, string action)
    {
        this.CoordinationId = coordinationId;
        this.StepId = stepId;
        this.Action = action;
    }
}
public class ModelOperationCompletedHandler : IEventHandler<ModelOperationCompleted>
{
    private IPipelineRepository _pipelineRepository;
    private IPipelineExecutor _pipelineExecutor;

    private ITransformationService _transformationService;
    private IPipelineNotificationService _pipelineNotificationService;
    private ISagaRepository _sagaRepository;
    private readonly IExecutableProcessRepository _executableProcessrepository;
    private readonly IProcessExecutor _processExecutor;
    private readonly IProcessNotificationService _processNotificationService;
    public ModelOperationCompletedHandler(IPipelineRepository pipelineRepository, ITransformationService transformationService, IPipelineNotificationService pipelineNotificationService, IPipelineExecutor pipelineExecutor, ISagaRepository sagaRepository, IExecutableProcessRepository executableProcessrepository, IProcessExecutor processExecutor, IProcessNotificationService processNotificationService)
    {
        _pipelineRepository = pipelineRepository;
        _transformationService = transformationService;
        _pipelineNotificationService = pipelineNotificationService;
        _pipelineExecutor = pipelineExecutor;
        _sagaRepository = sagaRepository;
        _executableProcessrepository = executableProcessrepository;
        _processExecutor = processExecutor;
        _processNotificationService = processNotificationService;
    }

    public void Handle(ModelOperationCompleted @event)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ModelOperationCompleted @event)
    {
        var externalCoordinationId = @event.CoordinationId;
        var saga = await _sagaRepository.GetAsync(externalCoordinationId);

        if(Equals(saga,null))
            return;
            
        
        if(saga.StepId != @event.StepId)            
            return;

            
        saga.Done();
        await _sagaRepository.UpdateAsync(saga);

        var coordinationId = saga.CoordinationId;
        var stepId = saga.StepId;

        if(saga.Type == SagaType.Pipeline)
            await HandlePipelineExecutionAsync(coordinationId,stepId);
        
        if(saga.Type == SagaType.Process)
            await HandleProcessExecutionAsync(coordinationId,stepId);
        
    }

    private async Task HandlePipelineExecutionAsync(Guid pipelineId , Guid stageId)
    {
        Pipeline? pipeline = null;
        if(pipelineId != Guid.Empty)
            pipeline = await _pipelineRepository.GetPipelineAsync(pipelineId);
        
        if(!Equals(pipeline,null))
        {
            pipeline.EndStage(stageId);
            await _pipelineRepository.UpdatePipelineAsync(pipeline);
            await _pipelineNotificationService.NotifyPipelineStageIsDone(pipelineId,stageId,pipeline.Status);
            var pipelineStatus = pipeline.Status;
            if(pipelineStatus == PipelineStatus.InProgress)
                await _pipelineExecutor.ExecutePipelineAsync(pipeline);
        }        
    }

    private async Task HandleProcessExecutionAsync(Guid executableProcessId,Guid taskId)
    {
        ExecutableProcess? executableProcess;
        if(executableProcessId != Guid.Empty)
        {
            executableProcess = await _executableProcessrepository.GetAsync(executableProcessId);
        
            if(!Equals(executableProcess,null))
            {
                executableProcess.EndTask(taskId);
                await _executableProcessrepository.UpdateAsync(executableProcess);
                await _processNotificationService.TaskIsDoneAsync(executableProcessId,taskId,executableProcess.Status);
                var processExecutionStatus = executableProcess.Status;
                if(processExecutionStatus == ProcessExecutionStatus.InProgress)
                    await _processExecutor.ExecuteProcessAsync(executableProcess);
            }        
        }

    }
}