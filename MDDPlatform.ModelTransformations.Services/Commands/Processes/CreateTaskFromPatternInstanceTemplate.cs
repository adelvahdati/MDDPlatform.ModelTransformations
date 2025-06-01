using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateTaskFromPatternInstanceTemplate : ICommand
{
    public Guid ProcessId {get;set;}    
    public Guid PhaseId {get;set;}
    public Guid ActivityId {get;set;}
    public Guid TemplateId {get;set;}
    public string Title {get;set;}

    public CreateTaskFromPatternInstanceTemplate(Guid processId, Guid phaseId, Guid activityId, Guid templateId, string title)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        ActivityId = activityId;
        TemplateId = templateId;
        Title = title;
    }
}
public class CreateTaskFromPatternInstanceTemplateHandler : ICommandHandler<CreateTaskFromPatternInstanceTemplate>
{
        private readonly IProcessRepository _processRepository;
        private readonly IPatternInstanceTemplateRepository _templateRepository;

    public CreateTaskFromPatternInstanceTemplateHandler(IProcessRepository processRepository, IPatternInstanceTemplateRepository templateRepository)
    {
        _processRepository = processRepository;
        _templateRepository = templateRepository;
    }

    public void Handle(CreateTaskFromPatternInstanceTemplate command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateTaskFromPatternInstanceTemplate command)
    {
        Process process = await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");
        
        PatternInstanceTemplate template = await _templateRepository.GetTemplateAsync(command.TemplateId);
        if(Equals(template,null))
            throw new Exception("Pattern Instnce Template Not Found");

        var task = WorkUnit.CreateModelTransformationTask(command.Title,template);

        process.CreateTask(command.PhaseId,command.ActivityId,task);
        await _processRepository.UpdateProcessAsync(process);
    }
}
