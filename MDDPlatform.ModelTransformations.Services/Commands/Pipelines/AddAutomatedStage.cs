using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class AddAutomatedStage : ICommand
{
    public Guid PipelineId {get;set;}
    public string StageTitle {get;set;}
    public Guid TaskId {get;set;}

    public AddAutomatedStage(Guid pipelineId, string stageTitle, Guid taskId)
    {
        PipelineId = pipelineId;
        StageTitle = stageTitle;
        TaskId = taskId;
    }
}
public class AddAutomatedStageHandler : ICommandHandler<AddAutomatedStage>
{
    private readonly IPipelineRepository _pipelienRepository;

    public AddAutomatedStageHandler(IPipelineRepository pipelienRepository)
    {
        _pipelienRepository = pipelienRepository;
    }

    public void Handle(AddAutomatedStage command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(AddAutomatedStage command)
    {
        var pipeline = await _pipelienRepository.GetPipelineAsync(command.PipelineId);
        if(Equals(pipeline,null))
            throw new Exception("Pipeline not found");
        
        pipeline.AddAutomaticStage(command.StageTitle,command.TaskId);
        await _pipelienRepository.UpdatePipelineAsync(pipeline);
    }
}
