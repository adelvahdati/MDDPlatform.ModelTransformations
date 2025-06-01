using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class FieldValueDocument
{
    public string Name {get; set;}
    public string Value {get;set;}
    internal FieldValueDocument(){
        Name = "";
        Value = "";
    }
    public FieldValueDocument(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public static FieldValueDocument CreateFrom(FieldValue fieldValue)
    {
        return new FieldValueDocument(fieldValue.Name,fieldValue.Value);    
    }
    public FieldValue ToFieldValue()
    {
        return new FieldValue(Name,Value);
    }
}