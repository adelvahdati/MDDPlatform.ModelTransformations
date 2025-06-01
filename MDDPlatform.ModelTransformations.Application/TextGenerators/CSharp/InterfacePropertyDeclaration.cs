using System.Text;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;
public class InterfacePropertyDeclaration
{
    public string PropertyName {get; protected set;}
    public string PropertyType {get;protected set;}
    public bool IsCollection {get; protected set;}
    public string ProeprtySetVisibility {get;protected set;}

    public InterfacePropertyDeclaration(string propertyName, string propertyType, bool isCollection, string proeprtySetVisibility)
    {
        PropertyName = propertyName;
        PropertyType = propertyType;
        IsCollection = isCollection;
        ProeprtySetVisibility = proeprtySetVisibility;
    }
    public InterfacePropertyDeclaration(PropertyDto property)
    {
        PropertyName = property.Name;
        PropertyType = property.Type;
        IsCollection = property.IsCollection;
        ProeprtySetVisibility = ExtractSetVisibility(property);
    }
    private string ExtractSetVisibility(PropertyDto property,string setVisibilityAttribute = "SetVisibility")
    {
        var defaulSetVisibility = "";
        var attribute = property.Attributes.FirstOrDefault(attr=>attr.Name.Trim().ToLower()== setVisibilityAttribute.Trim().ToLower());
        if(attribute == null)
            return defaulSetVisibility;
        
        List<string> validSetVisibility = new List<string>{"private","protected","internal"};
        if(validSetVisibility.Any(item=>item ==attribute.Value.Trim().ToLower()))
            return attribute.Value.Trim().ToLower();

        return defaulSetVisibility;
    }
    internal string Build()
    {
        StringBuilder builder = new StringBuilder();
        string propertyType;

        // Build Property
        if(IsCollection)
            propertyType = string.Format("List<{0}>",PropertyType);
        else
            propertyType = PropertyType;

        
        builder.AppendFormat("{0} {1}",propertyType,PropertyName);
        if(!string.IsNullOrEmpty(ProeprtySetVisibility))
            builder.Append(" {get;}");
        else
            builder.Append(" {get; set;}");
            

        builder.AppendLine();
        return builder.ToString();
    }

}