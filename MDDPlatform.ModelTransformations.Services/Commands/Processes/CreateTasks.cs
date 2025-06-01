using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateTasks : ICommand
{
    public Guid ProcessId {get;set;}    
    public Guid PhaseId {get;set;}
    public Guid ActivityId {get;set;}
    public List<TaskTemplate> TaskTemplates {get;set;}

    public CreateTasks(Guid processId, Guid phaseId, Guid activityId, List<TaskTemplate> taskTemplates)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        ActivityId = activityId;
        TaskTemplates = taskTemplates;
    }
}
public class CreateTasksHandler : ICommandHandler<CreateTasks>
{
    private readonly IProcessRepository _processRepository;
    private readonly IPatternInstanceTemplateRepository _templateRepository;

    public CreateTasksHandler(IProcessRepository processRepository, IPatternInstanceTemplateRepository templateRepository)
    {
        _processRepository = processRepository;
        _templateRepository = templateRepository;
    }

    public void Handle(CreateTasks command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateTasks command)
    {
        Process process = await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");

        foreach(var taskTemplate in command.TaskTemplates)
        {
            if(taskTemplate.Type == TaskType.PatternInstanceExecution)
            {
                PatternInstanceTemplate template = await _templateRepository.GetTemplateAsync(taskTemplate.TemplateId);
                if(Equals(template,null))
                    throw new Exception("Pattern Instnce Template Not Found");

                var task = WorkUnit.CreateModelTransformationTask(taskTemplate.Title,template);

                process.CreateTask(command.PhaseId,command.ActivityId,task);
            }
            if(taskTemplate.Type == TaskType.ManualTask)
            {
                var task = WorkUnit.CreateManualTask(taskTemplate.Title);
                process.CreateTask(command.PhaseId,command.ActivityId,task);
            }
        }
        await _processRepository.UpdateProcessAsync(process);
    }
}

