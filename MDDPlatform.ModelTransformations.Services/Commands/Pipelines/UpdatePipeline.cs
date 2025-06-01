using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class UpdatePipeline : ICommand
{
    public Guid Id {get; set;}
    public string Title {get;set;}
    public List<Stage> Stages {get; set;}

    public UpdatePipeline(Guid id, string title, List<Stage> stages)
    {
        Id = id;
        Title = title;
        Stages = stages;
    }
}
public class UpdatePipelineHandler : ICommandHandler<UpdatePipeline>
{
    private readonly IPipelineRepository _pipelineRepository;

    public UpdatePipelineHandler(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    public void Handle(UpdatePipeline command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(UpdatePipeline command)
    {
        Pipeline? pipeline = await _pipelineRepository.GetPipelineAsync(command.Id);
        
        if(Equals(pipeline,null))
            throw new Exception("Pipeline not found");
        
        pipeline.Update(command.Title,command.Stages);
        await _pipelineRepository.UpdatePipelineAsync(pipeline);

    }
}