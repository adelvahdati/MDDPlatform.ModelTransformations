using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class ScriptDto
{
    public Guid Id {get;set;}
    public string Title {get; set;}
    public List<InstructionDto> Instructions {get; set;}
    public Guid DomainModelId {get;set;}

    public ScriptDto(Guid id, string title, List<InstructionDto> instructions,Guid domainModelId)
    {
        Id = id;
        Title = title;
        Instructions = instructions;
        DomainModelId = domainModelId;
    }

    public static ScriptDto CreateFrom(Script script)
    {
        var instructions = script.Instructions.Select(ins=> InstructionDto.CreateFrom(ins)).ToList();
        return new(script.Id,script.Title,instructions,script.DomainModelId);
    }
}