namespace MDDPlatform.ModelTransformations.Application.DTO.Elements;
public class OperationDto
{
    public List<OperationInput> Inputs {get;set;}
    public string Name {get;set;}
    public OperationOutput Output {get;set;}
    public List<AttributeDto> Attributes { get; set; }

    public OperationDto(List<OperationInput> inputs, string name, OperationOutput output,List<AttributeDto>? attributes = null)
    {
        Inputs = inputs;
        Name = name;
        Output = output;
        Attributes = attributes == null ? new() : attributes;
    }
}
