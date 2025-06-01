using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class ExecuteProcess : ICommand
{
    public Guid Id {get;set;}

    public ExecuteProcess(Guid id)
    {
        Id = id;
    }
}
public class ExecuteProcessHandler : ICommandHandler<ExecuteProcess>
{
    private readonly IExecutableProcessRepository _repository;
    private readonly IProcessExecutor _processExecutor;

    public ExecuteProcessHandler(IExecutableProcessRepository repository, IProcessExecutor processExecutor)
    {
        _repository = repository;
        _processExecutor = processExecutor;
    }

    public void Handle(ExecuteProcess command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ExecuteProcess command)
    {
        var executableProcess = await _repository.GetAsync(command.Id);
        if(Equals(executableProcess,null))
            throw new Exception("Executable process not found");

        await _processExecutor.ExecuteProcessAsync(executableProcess);
    }
}