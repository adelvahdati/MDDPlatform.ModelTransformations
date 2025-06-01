namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class NewPatternDto
{
    public string Name {get;set;}
    public string Category {get;set;}
    public string? Description {get;set;}
    public List<FieldDto> Fields {get; set;}

    public NewPatternDto(string name,string category, string? description, List<FieldDto> fields)
    {
        Name = name;
        Category = category;
        Description = description;
        Fields = fields;
    }
}