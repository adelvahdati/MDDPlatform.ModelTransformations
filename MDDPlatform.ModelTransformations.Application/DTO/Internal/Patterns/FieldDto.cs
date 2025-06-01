using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class FieldDto
{
    public string Label {get;set;}
    public string Name {get; set;}    
    public FieldType Type {get;set;}

    public FieldDto(string label, string name, FieldType type)
    {
        Label = label;
        Name = name;
        Type = type;
    }

    public static FieldDto CreateFrom(Field field)
    {
        return new FieldDto(field.Label,field.Name,field.Type);
    }
    public Field ToField(){
        return new Field(Name,Label,Type);
    }
}