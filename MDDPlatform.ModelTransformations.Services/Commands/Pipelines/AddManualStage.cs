using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace  MDDPlatform.ModelTransformations.Services.Commands;
public class AddManualStage : ICommand{
    public Guid PipelineId {get;set;}
    public string StageTitle {get;set;}
    public Guid TaskId {get;set;}

    public AddManualStage(Guid pipelineId, string stageTitle,Guid taskId = default(Guid))
    {
        PipelineId = pipelineId;
        StageTitle = stageTitle;
        TaskId = taskId;
    }
}
public class AddManualStageHandler : ICommandHandler<AddManualStage>
{
    private readonly IPipelineRepository _pipelienRepository;

    public AddManualStageHandler(IPipelineRepository pipelienRepository)
    {
        _pipelienRepository = pipelienRepository;
    }

    public void Handle(AddManualStage command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(AddManualStage command)
    {
        var pipeline = await _pipelienRepository.GetPipelineAsync(command.PipelineId);
        if(Equals(pipeline,null))
            throw new Exception("Pipeline not found");
        
        pipeline.AddManualStage(command.StageTitle,command.TaskId);
        await _pipelienRepository.UpdatePipelineAsync(pipeline);
    }
}
