using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateActivity : ICommand
{
    public Guid ProcessId {get;set;}    
    public Guid PhaseId {get;set;}
    public string Title {get;set;}

    public CreateActivity(Guid processId, Guid phaseId, string title)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        Title = title;
    }
}
public class CreateActivityHandler : ICommandHandler<CreateActivity>
{
    private readonly IProcessRepository _processRepository;

    public CreateActivityHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public void Handle(CreateActivity command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateActivity command)
    {
        Process process = await _processRepository.GetProcessAsync(command.ProcessId);
        process.CreateActivity(command.PhaseId,command.Title);
        await _processRepository.UpdateProcessAsync(process);
    }
}
