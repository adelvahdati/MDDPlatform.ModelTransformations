using System.Text;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;
public class ClassPropertyDeclaration
{
    public string PropertyName {get; protected set;}
    public string PropertyType {get;protected set;}
    public bool IsCollection {get; protected set;}
    public string? Value {get;protected set;}
    public bool IsReadOnly {get;protected set;}
    public string ProeprtySetVisibility {get;protected set;}
    public List<AttributeDto> Attributes {get;protected set;}

    public ClassPropertyDeclaration(PropertyDto property)
    {
        PropertyName = property.Name;
        PropertyType = property.Type;
        IsCollection = property.IsCollection;
        Value = property.Value;
        Attributes = property.Attributes == null? new List<AttributeDto>() : property.Attributes;

        IsReadOnly = IsReadOnlyProperty(property);
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

    private bool IsReadOnlyProperty(PropertyDto property,string isReadOnlyattribute = "IsReadOnly")
    {
        var attribute = property.Attributes.FirstOrDefault(attr=>attr.Name.Trim().ToLower()== isReadOnlyattribute.Trim().ToLower());
        if(attribute == null)
            return false;
        
        bool result;
        var isParsable = bool.TryParse(attribute.Value,out result);
        if(!isParsable)
            return false;
        
        return result;
    }

    internal string Build()
    {
        StringBuilder builder = new StringBuilder();
        string propertyType,propertyValue;

        // Build Property Attributes
        foreach(var attribute in Attributes)
        {
            if(attribute.Value == "")
            {
                builder.AppendFormat("[{0}]",attribute.Name);
                builder.AppendLine();
            }            
            else
            {
                builder.AppendFormat("[{0}(\"{1}\")]",attribute.Name,attribute.Value);
                builder.AppendLine();
            }
        }


        // Build Property
        if(IsCollection)
            propertyType = string.Format("List<{0}>",PropertyType);
        else
            propertyType = PropertyType;

        
        if(IsReadOnly)
        {
            builder.AppendFormat("public {0} {1}",propertyType,PropertyName);
            builder.Append(" {get;}");
        }
        else
        {
            builder.AppendFormat("public {0} {1}",propertyType,PropertyName);
            builder.Append(" {get;");
            builder.AppendFormat("{0} set;",ProeprtySetVisibility);
            builder.Append("}");
        }            

        if(Value!=null)
        {
            propertyValue = PropertyType.Contains("string",StringComparison.OrdinalIgnoreCase)? string.Format("\"{0}\"",Value) : Value;
            builder.AppendFormat(" = {0}",propertyValue);
        }
            

        builder.AppendLine();
        return builder.ToString();
    }
}