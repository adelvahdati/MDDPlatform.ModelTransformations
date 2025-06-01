using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class FieldValue : ValueObject
{
    public string Name {get; set;}
    public string Value {get;set;}

    public FieldValue(string name, string value)
    {
        Name = name;
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Value;
    }
}