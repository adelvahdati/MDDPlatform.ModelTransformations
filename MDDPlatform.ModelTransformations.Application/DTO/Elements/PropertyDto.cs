namespace MDDPlatform.ModelTransformations.Application.DTO.Elements;
public class PropertyDto{
    public string Name { get; set; }
    public string Type { get; set; }
    public string? Value { get; set; }
    public bool IsCollection { get; set; }
    public List<AttributeDto> Attributes {get;set;}


    public PropertyDto(string name, string type, string? value, bool isCollection,List<AttributeDto>? attributes = null)
    {
        Name = name;
        Type = type;
        Value = value;
        IsCollection = isCollection;
        Attributes = attributes == null ? new() : attributes;
    }
}