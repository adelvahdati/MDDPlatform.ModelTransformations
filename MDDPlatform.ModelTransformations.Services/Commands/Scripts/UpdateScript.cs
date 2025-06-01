using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class UpdateScript : ICommand
{
    public Guid Id {get;set;}
    public string Title {get; set;}
    public List<Instruction> Instructions {get; set;}
    public Guid DomainModelId {get;set;}

    public UpdateScript(Guid id, string title, List<Instruction> instructions, Guid domainModelId)
    {
        Id = id;
        Title = title;
        Instructions = instructions;
        DomainModelId = domainModelId;
    }
}
public class UpdateScriptHandler : ICommandHandler<UpdateScript>
{
    private readonly IScriptRepository _scriptRepository;

    public UpdateScriptHandler(IScriptRepository scriptRepository)
    {
        _scriptRepository = scriptRepository;
    }

    public void Handle(UpdateScript command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(UpdateScript command)
    {
        var script = await _scriptRepository.GetScriptAsync(command.Id);
        if(Equals(script,null))
            throw new Exception("Script not found");
        
        var newScript =  Script.Load(command.Id,command.Title,command.Instructions,command.DomainModelId);
        await _scriptRepository.UpdateScriptAsync(newScript);        
    }
}
