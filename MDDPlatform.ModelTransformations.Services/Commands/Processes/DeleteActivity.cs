using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeleteActivity : ICommand
{
    public Guid ProcessId {get;set;}
    public Guid PhaseId {get;set;}
    public Guid ActivityId {get;set;}

    public DeleteActivity(Guid processId, Guid phaseId, Guid activityId)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        ActivityId = activityId;
    }
}
public class DeleteActivityHandler : ICommandHandler<DeleteActivity>
{
    private readonly IProcessRepository _processRepository;

    public DeleteActivityHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public void Handle(DeleteActivity command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeleteActivity command)
    {
        var process = await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");

        process.DeleteActivity(command.PhaseId,command.ActivityId);
        await _processRepository.UpdateProcessAsync(process);
    }
}
