using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreatePipeline : ICommand
{
    public Guid ProblemDomainId {get;set;}
    public string Title {get;set;}
    public List<NewStage> Stages {get;set;}

    public CreatePipeline(string title, List<NewStage> stages,Guid problemDomainId)
    {
        Title = title;
        Stages = stages;
        ProblemDomainId = problemDomainId;
    }
}
public class NewStage 
{
    public string Title {get;set;}
    public StageType Type {get;set;} 
    public Guid TaskId {get;set;}

    public NewStage(string title, StageType type, Guid taskId = default(Guid))
    {
        Title = title;
        Type = type;
        TaskId = taskId;
    }
}
public class CreatePipelineHandler : ICommandHandler<CreatePipeline>
{
    private readonly IPipelineRepository _pipelineRepository;

    public CreatePipelineHandler(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    public void Handle(CreatePipeline command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreatePipeline command)
    {
        Pipeline pipeline = Pipeline.Create(command.Title,command.ProblemDomainId);
        foreach(var stage in command.Stages)
        {
            if(stage.Type == StageType.Automatic)
                pipeline.AddAutomaticStage(stage.Title,stage.TaskId);

            if(stage.Type == StageType.Manual)    
                pipeline.AddManualStage(stage.Title,stage.TaskId);
        }
        await _pipelineRepository.CreatePipelineAsync(pipeline);
    }
}