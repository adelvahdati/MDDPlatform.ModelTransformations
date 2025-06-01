using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeletePipeline : ICommand
{
    public Guid PipelineId {get;set;}

    public DeletePipeline(Guid pipelineId)
    {
        PipelineId = pipelineId;
    }
}
public class DeletePipelineHandler : ICommandHandler<DeletePipeline>
{
    private readonly IPipelineRepository _pipelineRepository;

    public DeletePipelineHandler(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    public void Handle(DeletePipeline command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeletePipeline command)
    {
        var pipeline = await _pipelineRepository.GetPipelineAsync(command.PipelineId);
        if(Equals(pipeline,null))
            throw new Exception("Pipeline not found");
        
        await _pipelineRepository.DeletePipelineAsync(pipeline);
    }
}
