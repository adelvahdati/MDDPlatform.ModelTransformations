using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class Script : BaseEntity<Guid>
{

    private List<Instruction> _instructions;
    public Guid DomainModelId {get;private set;}
    public string Title {get; private set;}
    public IReadOnlyList<IInstruction> Instructions => _instructions;

    private Script(Guid id,string title, List<Instruction> instructions,Guid domainModelId)
    {
        Id = id;
        Title = title;
        _instructions = instructions;
        DomainModelId = domainModelId;
    }
    private Script(string title, List<Instruction> instructions,Guid domainModelId)
    {
        Id = Guid.Empty;
        Title = title;
        _instructions = instructions;
        DomainModelId = domainModelId;
    }

    public static Script Create(string title,Guid domainModelId){
        return new(title,new(),domainModelId);
    }
    public static Script Create(string title,List<Instruction> instructions,Guid domainModelId){
        return new(title,instructions,domainModelId);
    }
    public static Script Load(Guid id,string title,List<Instruction> instruction,Guid domainModelId)
    {
        return new Script(id,title,instruction,domainModelId);
    }
}