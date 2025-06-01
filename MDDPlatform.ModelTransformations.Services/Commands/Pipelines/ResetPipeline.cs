using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class ResetPipeline : ICommand
{
    public Guid PipelineId {get;set;}

    public ResetPipeline(Guid pipelineId)
    {
        this.PipelineId = pipelineId;
    }
}
public class ResetPipelineHandler : ICommandHandler<ResetPipeline>
{
    private readonly IPipelineRepository _pipelineRepository;

    public ResetPipelineHandler(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    public void Handle(ResetPipeline command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ResetPipeline command)
    {
        var pipeline = await _pipelineRepository.GetPipelineAsync(command.PipelineId);
        if(Equals(pipeline,null))
            throw new Exception("Pipeline not found");
        
        pipeline.ResetPipline();
        await _pipelineRepository.UpdatePipelineAsync(pipeline);
    }
}
