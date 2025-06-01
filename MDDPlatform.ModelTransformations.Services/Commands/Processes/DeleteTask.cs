using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeleteTask : ICommand
{
    public Guid ProcessId {get;set;}
    public Guid PhaseId {get;set;}
    public Guid ActivityId {get;set;}
    public Guid TaskId {get;set;}

    public DeleteTask(Guid processId, Guid phaseId, Guid activityId, Guid taskId)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        ActivityId = activityId;
        TaskId = taskId;
    }
}
public class DeleteTaskHandler : ICommandHandler<DeleteTask>
{
    private readonly IProcessRepository _processRepository;

    public DeleteTaskHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public void Handle(DeleteTask command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeleteTask command)
    {
        var process = await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");

        process.DeleteTask(command.PhaseId,command.ActivityId,command.TaskId);
        await _processRepository.UpdateProcessAsync(process);
    }
}
