using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateActivityFromPipeline : ICommand
{
    public Guid ProcessId {get;set;}
    public Guid PhaseId {get;set;}
    public Guid PipelineId {get;set;}
    public string Title {get;set;}

    public CreateActivityFromPipeline(Guid processId, Guid phaseId, Guid pipelineId, string title)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        PipelineId = pipelineId;
        Title = title;
    }
}
public class CreateActivityFromPipelineHandler : ICommandHandler<CreateActivityFromPipeline>
{
    private readonly IPipelineRepository _pipelineRepository;
    private readonly IProcessRepository _processRepository;
    private readonly IPatternRepository _patternRepository;
    private readonly IPatternInstanceRepository _patternInstanceRepository;
    private readonly IPatternInstanceTemplateRepository _patternInstanceTemplateRepository;
    public CreateActivityFromPipelineHandler(IPipelineRepository pipelineRepository, IProcessRepository processRepository, IPatternInstanceRepository patternInstanceRepository, IPatternInstanceTemplateRepository patternInstanceTemplateRepository, IPatternRepository patternRepository)
    {
        _pipelineRepository = pipelineRepository;
        _processRepository = processRepository;
        _patternInstanceRepository = patternInstanceRepository;
        _patternInstanceTemplateRepository = patternInstanceTemplateRepository;
        _patternRepository = patternRepository;
    }

    public void Handle(CreateActivityFromPipeline command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateActivityFromPipeline command)
    {
        var process = await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");
        
        var pipeline = await _pipelineRepository.GetPipelineAsync(command.PipelineId);
        if(Equals(pipeline,null))
            throw new Exception("Pipeline Not Foudn");
        
        var stages = pipeline.Stages;
        Activity actvity = Activity.Create(command.Title);
        foreach(var stage in stages)
        {            
            WorkUnit task = await BuildTaskAsync(stage);
            actvity.CreateTask(task);
        }
        process.CreateActivity(command.PhaseId,actvity);
        await _processRepository.UpdateProcessAsync(process);
    }

    private async Task<WorkUnit> BuildTaskAsync(IPipelineStage stage)
    {
        if(stage.Type == StageType.Automatic)
            return await CreateModelTransformationTaskAsync(stage.Title,stage.TaskId);
        
        if(stage.Type == StageType.Manual)
            return WorkUnit.CreateManualTask(stage.Title);        
        
        throw new Exception("Invalid Pipeline stage");
    }

    private async Task<WorkUnit> CreateModelTransformationTaskAsync(string title, Guid taskId)
    {
        var patternInstance = await _patternInstanceRepository.GetInstanceAsync(taskId);
        if(Equals(patternInstance,null))
            throw new Exception("Pattern  Instance Not Found");

        var pattern = await _patternRepository.GetPatternAsync(patternInstance.Template.PatternId);
        if(Equals(pattern,null))
            throw new Exception("Pattern Not Found");
        
        var taskTemplate = PatternInstanceTemplate.CreateFrom(pattern,patternInstance);
        PatternInstanceTemplate? similarTemplate = await _patternInstanceTemplateRepository.GetSimilarTemplateAsync(taskTemplate);

        if(!Equals(similarTemplate,null))
            return WorkUnit.CreateModelTransformationTask(title,similarTemplate);
        
        await _patternInstanceTemplateRepository.CreateTemplateAsync(taskTemplate);
        return WorkUnit.CreateModelTransformationTask(title,taskTemplate);
    }
}
