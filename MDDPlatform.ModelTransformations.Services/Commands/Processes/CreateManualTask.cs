using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateManualTask : ICommand
{
    public Guid ProcessId {get;set;}    
    public Guid PhaseId {get;set;}
    public Guid ActivityId {get;set;}
    public string Title {get;set;}

    public CreateManualTask(Guid processId, Guid phaseId, Guid activityId, string title)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        ActivityId = activityId;
        Title = title;
    }
}
public class CreateManualTaskHandler : ICommandHandler<CreateManualTask>
{
    private readonly IProcessRepository _processRepository;

    public CreateManualTaskHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public void Handle(CreateManualTask command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateManualTask command)
    {
        Process process = await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");
        var task = WorkUnit.CreateManualTask(command.Title);
        process.CreateTask(command.PhaseId,command.ActivityId,task);
        await _processRepository.UpdateProcessAsync(process);
    }
}
