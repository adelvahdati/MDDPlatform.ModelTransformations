using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class PatternDocumnet : BaseEntity<Guid>
{
    public string Name {get;set;}
    public string Category {get;set;}
    public string? Description {get;set;}
    public List<FieldDocument> Fields {get; set;}

    public PatternDocumnet(Guid id, string name,string category, string? description, List<FieldDocument> fields)
    {
        Id = id;
        Name = name;
        Category = category;
        Description = description;
        Fields = fields;
    }
    public static PatternDocumnet CreateFrom(Pattern pattern)
    {
            var fields = pattern.Fields
                                .Select(field=> FieldDocument.CreateFrom(field))
                                .ToList();
            
            return new PatternDocumnet(pattern.Id,pattern.Name,pattern.Category,pattern.Description,fields);
    }
    public Pattern ToPattern()
    {
        var fields = Fields.Select(fieldDocument=> fieldDocument.ToField()).ToList();
        return Pattern.Load(Id,Name,Category,Description,fields);
    }
}