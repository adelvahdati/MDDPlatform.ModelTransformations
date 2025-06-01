namespace MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;
public class ProeprtyValueDto
{
    public string Name {get;set;}    
    public string Value {get;set;}

    public ProeprtyValueDto(string name, string value)
    {
        Name = name;
        Value = value;
    }
}