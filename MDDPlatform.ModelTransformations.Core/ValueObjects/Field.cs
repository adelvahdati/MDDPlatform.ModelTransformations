using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class Field : ValueObject
{
    public string Label {get;set;}
    public string Name {get; set;}    
    public FieldType Type {get;set;}
    public Field(string name, string label, FieldType type)
    {
        Name = name;
        Label = label;
        Type = type;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Label;
        yield return Type;
    }
}