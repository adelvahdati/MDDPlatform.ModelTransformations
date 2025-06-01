using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.Builders;
public class PatternBuilder : IPatternBuilder
{
    private Guid _id;
    private string _name;
    private string _category;
    private string? _description;
    private List<Field> _fields;

    public PatternBuilder(Guid id, string name,string category, string? description, List<Field> fields)
    {
        _id = id;
        _name = name;
        _category = category;
        _description = description;
        _fields = fields;
    }

    public static IPatternBuilder Create(Guid id, string name,string category, string? description = null)
    {
        return new PatternBuilder(id,name,category,description,new List<Field>());
    }
    public IPatternBuilder AddField(string name, string label, FieldType type)
    {
        if(_fields.Exists(field=> field.Name.ToLower().Trim() == name.ToLower().Trim()))
            throw new Exception("Pattern building Error : The same feild exists");
            
        _fields.Add(new Field(name,label,type));
        return this;
    }

    public Pattern Build()
    {
        return Pattern.Load(_id,_name,_category,_description,_fields);
    }
}