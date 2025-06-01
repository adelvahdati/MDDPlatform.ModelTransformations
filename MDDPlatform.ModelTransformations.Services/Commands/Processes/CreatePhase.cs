using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreatePhase : ICommand
{
    public Guid ProcessId {get;set;}
    public string Title {get;set;}
    public List<string> Activities {get;set;}

    public CreatePhase(Guid processId, string title, List<string> activities)
    {
        ProcessId = processId;
        Title = title;
        Activities = activities;
    }
}
public class CreatePhaseHandler : ICommandHandler<CreatePhase>
{
    private readonly IProcessRepository _processRepository;

    public CreatePhaseHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public void Handle(CreatePhase command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreatePhase command)
    {
       Process process =  await _processRepository.GetProcessAsync(command.ProcessId);
       Phase phase  = Phase.Create(command.Title,command.Activities);
       process.AddPhase(phase);

       await _processRepository.UpdateProcessAsync(process);
    }
}
