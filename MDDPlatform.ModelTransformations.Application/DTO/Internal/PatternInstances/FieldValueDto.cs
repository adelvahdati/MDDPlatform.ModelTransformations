using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class FieldValueDto
{
    public string Name {get; set;}
    public string Value {get;set;}

    public FieldValueDto(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public static FieldValueDto CreateFrom(FieldValue fieldValue)
    {
        return new(fieldValue.Name,fieldValue.Value);
    }

    internal FieldValue ToFieldValue()
    {
        return new FieldValue(Name,Value);
    }
}