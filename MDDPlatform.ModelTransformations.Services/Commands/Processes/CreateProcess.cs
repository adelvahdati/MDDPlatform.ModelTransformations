using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateProcess : ICommand
{
    public string Title {get;set;}
    public List<string> Phases {get;set;}

    public CreateProcess(string title, List<string> phases)
    {
        Title = title;
        Phases = phases;
    }
}
public class CreateProcessHandler : ICommandHandler<CreateProcess>
{
    private readonly IProcessRepository _processRepository;

    public CreateProcessHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public void Handle(CreateProcess command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateProcess command)
    {
        Process process = Process.Create(command.Title);
        foreach(var phase in command.Phases)
        {
            process.AddPhase(phase);
        }
        await _processRepository.CreateProcessAsync(process);
    }
}
