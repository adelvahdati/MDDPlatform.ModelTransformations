using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class ScriptDocument : BaseEntity<Guid>
{
    public string Title {get; set;}
    public List<InstructionDocument> Instructions {get; set;}

    public Guid DomainModelId {get;set;}
    public ScriptDocument(Guid id,string title, List<InstructionDocument> instructions,Guid domainModelId)
    {
        Id = id;
        Title = title;
        Instructions = instructions;
        DomainModelId=domainModelId;
    }
    public static ScriptDocument CreateFrom(Script script)
    {
        var instructions = script.Instructions.Select(ins=>InstructionDocument.CreateFrom(ins)).ToList();
        return new(script.Id,script.Title,instructions,script.DomainModelId);
    }

    public Script ToScript()
    {
        var instructions = Instructions.Select(insDoc=>insDoc.ToInstruction()).ToList();
        return Script.Load(Id,Title,instructions,DomainModelId);        
    }
}