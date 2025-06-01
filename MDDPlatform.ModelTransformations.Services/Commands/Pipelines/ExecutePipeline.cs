using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class ExecutePipeline : ICommand
{
    public Guid PipelineId {get;set;}

    public ExecutePipeline(Guid pipelineId)
    {
        this.PipelineId = pipelineId;
    }
}
public class ExecutePipelineHandler : ICommandHandler<ExecutePipeline>
{
    private IPipelineRepository _pipelineRepository;
    private ITransformationService _transformationService;
    private IPipelineNotificationService _pipelineNotificationService;
    private IPipelineExecutor _pipelineExecutor;

    public ExecutePipelineHandler(IPipelineRepository pipelineRepository, ITransformationService transformationService, IPipelineNotificationService pipelineNotificationService, IPipelineExecutor pipelineExecutor)
    {
        this._pipelineRepository = pipelineRepository;
        _transformationService = transformationService;
        _pipelineNotificationService = pipelineNotificationService;
        _pipelineExecutor = pipelineExecutor;
    }

    public void Handle(ExecutePipeline command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ExecutePipeline command)
    {
        var pipeline = await _pipelineRepository.GetPipelineAsync(command.PipelineId);
        if(Equals(pipeline,null))
            throw new Exception("Pipeline Not found");

        await _pipelineExecutor.ExecutePipelineAsync(pipeline);
    }
}
