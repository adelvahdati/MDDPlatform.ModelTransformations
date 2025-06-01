namespace MDDPlatform.ModelTransformations.Application.DTO.Elements;
public class ElementDto
{
    public Guid Id {get;set;}
    public string Name {get;set;}
    public string Type {get;set;}
    public List<PropertyDto> Properties {get;set;}
    public List<RelationDto> Relations {get;set;}
    public  List<OperationDto> Operations {get;set;}
    public List<AttributeDto> Attributes { get; set; }

    public string FullName => string.Format("{0}.{1}",Name,Type);

    public ElementDto(Guid id, string name, string type, List<PropertyDto> properties, List<RelationDto> relations, List<OperationDto> operations, List<AttributeDto> attributes)
    {
        Id = id;
        Name = name;
        Type = type;
        Properties = properties;
        Relations = relations;
        Operations = operations;
        Attributes = attributes;
    }
}
