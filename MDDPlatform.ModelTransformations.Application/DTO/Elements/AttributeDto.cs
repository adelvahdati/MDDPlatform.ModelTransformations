namespace MDDPlatform.ModelTransformations.Application.DTO.Elements;
public class AttributeDto
{
    public string Name { get; set;}
    public string Value { get; set;}

    public AttributeDto(string name, string value)
    {
        Name = name;
        Value = value;
    }
}
