using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class RunScript : ICommand
{
    public Guid ScriptId {get;set;}

    public RunScript(Guid scriptId)
    {
        ScriptId = scriptId;
    }

}
public class RunScriptHandler : ICommandHandler<RunScript>
{
    private readonly IScriptRepository _scriptRepository;
    private readonly IScriptRunner _scriptRunner;

    public RunScriptHandler(IScriptRepository scriptRepository, IScriptRunner scriptRunner)
    {
        _scriptRepository = scriptRepository;
        _scriptRunner = scriptRunner;
    }

    public void Handle(RunScript command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(RunScript command)
    {
        var script = await _scriptRepository.GetScriptAsync(command.ScriptId);
        if(Equals(script,null))
            throw new Exception("Script not found");
        await _scriptRunner.RunScriptAsync(script.DomainModelId,script.Instructions.ToList());
    }
}
