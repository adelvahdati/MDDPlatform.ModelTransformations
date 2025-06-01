using MDDPlatform.Messages.Events;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.ModelTransformations.Services.Saga;
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.ModelTransformations.Services.ExternalEvents;
public class ModelOperationFailed : IDomainEvent
{
    public Guid CoordinationId {get;set;}    
    public Guid StepId {get;set;}
    public string Action {get;set;}
    public string ErrorMessage {get;set;}

    public ModelOperationFailed(Guid coordinationId, Guid stepId, string action, string errorMessage)
    {
        CoordinationId = coordinationId;
        StepId = stepId;
        Action = action;
        ErrorMessage = errorMessage;
    }
}
public class ModelOperationFailedHandler : IEventHandler<ModelOperationFailed>
{
    private IPipelineRepository _pipelineRepository;
    private IPipelineNotificationService _pipelineNotificationService;

    private readonly IExecutableProcessRepository _executableProcessrepository;
    private readonly IProcessNotificationService _processNotificationService;

    private ISagaRepository _sagaRepository;


    public ModelOperationFailedHandler(IPipelineRepository pipelineRepository, IPipelineNotificationService pipelineNotificationService, IExecutableProcessRepository executableProcessrepository, IProcessNotificationService processNotificationService, ISagaRepository sagaRepository)
    {
        _pipelineRepository = pipelineRepository;
        _pipelineNotificationService = pipelineNotificationService;
        _executableProcessrepository = executableProcessrepository;
        _processNotificationService = processNotificationService;
        _sagaRepository = sagaRepository;
    }

    public void Handle(ModelOperationFailed @event)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ModelOperationFailed @event)
    {
        var externalCoordinationId = @event.CoordinationId;
        var saga = await _sagaRepository.GetAsync(externalCoordinationId);

        if(Equals(saga,null))
            return;
        
        if(saga.StepId != @event.StepId)
            return;
        
        saga.Failed();
        await _sagaRepository.UpdateAsync(saga);

        var coordinationId = saga.CoordinationId;
        var stepId = saga.StepId;

        if(saga.Type == SagaType.Pipeline)
            await HandlePipelineFailureAsync(coordinationId,stepId);
        
        if(saga.Type == SagaType.Process)
            await HandleProcessExecutionFailureAsync(coordinationId,stepId);

    }

    private async Task HandlePipelineFailureAsync(Guid pipelineId , Guid stageId)
    {
        Pipeline? pipeline = null;
        if(pipelineId != Guid.Empty)
            pipeline = await _pipelineRepository.GetPipelineAsync(pipelineId);
        
        if(!Equals(pipeline,null))
        {
            pipeline.RejectStage(stageId);
            await _pipelineRepository.UpdatePipelineAsync(pipeline);
            await _pipelineNotificationService.NotifyPipelineStageFailed(pipelineId,stageId,pipeline.Status);
        }
    }

    private async Task HandleProcessExecutionFailureAsync(Guid executableProcessId,Guid taskId)
    {
        ExecutableProcess? executableProcess = null;
        if(executableProcessId != Guid.Empty)
            executableProcess = await _executableProcessrepository.GetAsync(executableProcessId);
        
        if(!Equals(executableProcess,null))
        {
            executableProcess.RejectTask(taskId);
            await _executableProcessrepository.UpdateAsync(executableProcess);
            await _processNotificationService.TaskIsFailedAsync(executableProcessId,taskId,executableProcess.Status);
        }
    }
}
