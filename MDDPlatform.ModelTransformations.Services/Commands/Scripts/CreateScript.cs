using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateScript : ICommand
{
    public string Title {get;set;}
    public  List<Instruction> Instructions {get;set;}
    public Guid DomainModelId {get;set;}

    public CreateScript(string title, List<Instruction> instructions,Guid domainModelId)
    {
        Title = title;
        Instructions = instructions;
        DomainModelId = domainModelId;
    }
}
public class CreateScriptHandler : ICommandHandler<CreateScript>
{
    private readonly IScriptRepository _scriptRepository;

    public CreateScriptHandler(IScriptRepository scriptRepository)
    {
        _scriptRepository = scriptRepository;
    }

    public void Handle(CreateScript command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateScript command)
    {
        Script script = Script.Create(command.Title,command.Instructions,command.DomainModelId);
        await _scriptRepository.CreateScriptAsync(script);
    }
}
