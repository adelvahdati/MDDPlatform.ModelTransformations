using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class PatternDto
{
    public Guid Id {get;set;}
    public string Name {get;set;}
    public string Category {get;set;}
    public string? Description {get;set;}
    public List<FieldDto> Fields {get; set;}

    public PatternDto(Guid id,string name,string category, string? description, List<FieldDto> fields)
    {
        Id = id;
        Name = name;
        Category = category;
        Description = description;
        Fields = fields;
    }

    public static PatternDto CreateFrom(Pattern pattern)
    {
        
        var fields = pattern.Fields
                            .Select(field=> FieldDto.CreateFrom(field))
                            .ToList();
        return new(pattern.Id,pattern.Name,pattern.Category,pattern.Description,fields);
    }
}