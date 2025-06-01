using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeleteScript : ICommand{
    public Guid ScriptId {get;set;}

    public DeleteScript(Guid scriptId)
    {
        this.ScriptId = scriptId;
    }
}
public class DeleteScriptHandler : ICommandHandler<DeleteScript>
{
    private readonly IScriptRepository _scriptRepository;

    public DeleteScriptHandler(IScriptRepository scriptRepository)
    {
        this._scriptRepository = scriptRepository;
    }

    public void Handle(DeleteScript command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeleteScript command)
    {
        await _scriptRepository.DeleteScriptAsync(command.ScriptId);
    }
}
