using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeletePhase : ICommand{
    public Guid ProcessId {get;set;}
    public Guid PhaseId {get;set;}

    public DeletePhase(Guid processId, Guid phaseId)
    {
        ProcessId = processId;
        PhaseId = phaseId;
    }
}
public class DeletePhaseHandler : ICommandHandler<DeletePhase>
{
    private readonly IProcessRepository _processRepository;

    public DeletePhaseHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public void Handle(DeletePhase command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeletePhase command)
    {
        var process = await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");
        process.DeletePhase(command.PhaseId);
        await _processRepository.UpdateProcessAsync(process);
    }
}
