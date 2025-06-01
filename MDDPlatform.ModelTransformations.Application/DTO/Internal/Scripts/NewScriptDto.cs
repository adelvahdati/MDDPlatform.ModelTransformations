using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class NewScriptDto
{
    public string Title {get; set;}
    public List<InstructionDto> Instructions {get; set;}
    public Guid DomainModelId {get;set;}

    public NewScriptDto(string title, List<InstructionDto> instructions,Guid domainModelId)
    {
        Title = title;
        Instructions = instructions;
        DomainModelId = domainModelId;
    }

    public static NewScriptDto CreateFrom(Script script)
    {
        var instructions = script.Instructions.Select(ins=> InstructionDto.CreateFrom(ins)).ToList();
        return new(script.Title,instructions,script.DomainModelId);
    }
}