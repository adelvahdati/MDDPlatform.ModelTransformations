using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeleteProcess : ICommand{
    public Guid ProcessId {get;set;}

    public DeleteProcess(Guid processId)
    {
        this.ProcessId = processId;
    }
}
public class DeleteProcessHandler : ICommandHandler<DeleteProcess>
{
    private readonly IProcessRepository _processRepository;

    public DeleteProcessHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public async void Handle(DeleteProcess command)
    {
        await _processRepository.DeleteProcessAsync(command.ProcessId);
    }

    public async Task HandleAsync(DeleteProcess command)
    {
        await _processRepository.DeleteProcessAsync(command.ProcessId);
    }
}
