using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class Pattern : BaseEntity<Guid>
{
    public string Name {get;private set;}
    public string Category {get;private set;}
    public string? Description {get;private set;}
    public List<Field> Fields {get; private set;}

    private Pattern(string name,string category, string? description, List<Field> fields)
    {
        Id = Guid.NewGuid();
        Name = name;
        Category = category;
        Description = description;
        Fields = fields;
    }
    private Pattern(Guid id, string name,string category, string? description, List<Field> fields)
    {
        Id = id;
        Name = name;
        Category = category;
        Description = description;
        Fields = fields;
    }
    public static Pattern Create(string name,string category, string? description, List<Field> fields)
    {
        //TODO : Check invariant
        return new Pattern(name,category,description,fields);
    }
    public static Pattern Load(Guid id, string name,string category, string? description, List<Field> fields)
    {
        //TODO : Check invariant
        return new Pattern(id,name,category,description,fields);
    }
    public PatternInstance CreateInstance(string title,string name, List<FieldValue> fieldValues,Guid problemDomainId)
    {
        foreach(var fieldValue in fieldValues)
        {
            if(!Fields.Exists(field=>field.Name == fieldValue.Name))
                throw new Exception($"This pattern doesn't contain {fieldValue.Name}");
        }
        return new PatternInstance(title,name,PatternTemplate.CreateFrom(this),fieldValues,problemDomainId);
    }
}