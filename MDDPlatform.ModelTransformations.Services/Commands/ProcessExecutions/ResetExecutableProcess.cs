using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class ResetExecutableProcess : ICommand
{
    public Guid ProcessId {get;set;}

    public ResetExecutableProcess(Guid processId)
    {
        this.ProcessId = processId;
    }
}
public class ResetExecutableProcessHandler : ICommandHandler<ResetExecutableProcess>
{
    private readonly IExecutableProcessRepository _repository;

    public ResetExecutableProcessHandler(IExecutableProcessRepository repository)
    {
        this._repository = repository;
    }

    public void Handle(ResetExecutableProcess command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ResetExecutableProcess command)
    {
        var executableProcess = await _repository.GetAsync(command.ProcessId);
        if(Equals(executableProcess,null))
            throw new Exception("Reset Executable Process Failed : Executable Process Not Found");
        
        executableProcess.ResetProcess();
        await _repository.UpdateAsync(executableProcess);
    }
}
