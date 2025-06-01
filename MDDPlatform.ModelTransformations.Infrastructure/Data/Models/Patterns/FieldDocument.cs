using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class FieldDocument
{
    public string Label {get;set;}
    public string Name {get; set;}    
    public FieldType Type {get;set;}

    public FieldDocument(string label, string name, FieldType type)
    {
        Label = label;
        Name = name;
        Type = type;
    }

    public static FieldDocument CreateFrom(Field field)
    {
        return new FieldDocument(field.Label,field.Name,field.Type);
    }
    public Field ToField(){
        return new Field(Name,Label,Type);
    }
}