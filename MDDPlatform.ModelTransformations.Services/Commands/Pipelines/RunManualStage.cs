using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class RunManualStage : ICommand
{
    public Guid PipelineId {get;set;}
    public Guid StageId {get;set;}

    public RunManualStage(Guid pipelineId, Guid stageId)
    {
        PipelineId = pipelineId;
        StageId = stageId;
    }
}
public class RunManualStageHandler : ICommandHandler<RunManualStage>
{
    private IPipelineRepository _pipelineRepository;
    private IPipelineNotificationService _pipelineNotificationService;

    public RunManualStageHandler(IPipelineRepository pipelineRepository, IPipelineNotificationService pipelineNotificationService)
    {
        _pipelineRepository = pipelineRepository;
        _pipelineNotificationService = pipelineNotificationService;
    }

    public void Handle(RunManualStage command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(RunManualStage command)
    {
        Pipeline? pipeline = await _pipelineRepository.GetPipelineAsync(command.PipelineId);
        if(Equals(pipeline,null))
            throw new Exception("Pipeline Not found");
        var stage = pipeline.GetStage(command.StageId);
        
        if(stage.Type!=StageType.Manual)
            throw new Exception($"{command.StageId} is not manual");
        
        pipeline.EndStage(command.StageId);
        await _pipelineRepository.UpdatePipelineAsync(pipeline);
        await _pipelineNotificationService.NotifyPipelineStageIsDone(command.PipelineId,command.StageId,pipeline.Status);
    }
}