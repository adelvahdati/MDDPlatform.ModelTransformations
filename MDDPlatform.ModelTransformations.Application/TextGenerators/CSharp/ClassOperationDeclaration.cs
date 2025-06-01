using System.Text;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;
public class ClassOperationDeclaration
{
    public string Visibility {get; protected set;}
    public List<AttributeDto> Attributes { get; protected set; }
    public string Name {get; protected set;}
    public OperationOutput Output {get;protected set;}
    public List<OperationInput> Inputs {get;protected set;}
    public string Body {get;protected set;}

    protected ClassOperationDeclaration(string visibility, List<AttributeDto> attributes, string name, OperationOutput output, List<OperationInput> inputs, string body)
    {
        Visibility = visibility;
        Attributes = attributes;
        Name = name;
        Output = output;
        Inputs = inputs;
        Body = body;
    }

    public ClassOperationDeclaration(OperationDto operation)
    {
        Visibility = ExtractVisibility(operation);
        Attributes = operation.Attributes == null? new List<AttributeDto>() : operation.Attributes;
        Name = operation.Name;
        Output = operation.Output;
        Inputs = operation.Inputs;
        Body = ExtractBody(operation);
    }

    public string Build()
    {
        StringBuilder  builder = new StringBuilder("");
        // Build Operation Attributes
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

        // Build Operation
        string output = Output.IsCollection == true? $"List<{Output.Type}>" : Output.Type;
        var inputs = Inputs.Select(input=> $"{input.Type} {input.Name}").ToList();
        var inputParameters = string.Join(",",inputs);

        builder.AppendFormat("{0} {1} {2}({3})",Visibility,output,Name,inputParameters);
        builder.AppendLine();
        builder.AppendLine("{");

        StringBuilder operationBody = new StringBuilder(Body);;
            
        
        builder.AppendIndented(operationBody.ToString());        
        builder.AppendLine("}");
        return builder.ToString();
    }

    private string ExtractVisibility(OperationDto operation,string visibilityAttribute = "visibility")
    {
        string defaultVisibility="public";
        var attribute = operation.Attributes.FirstOrDefault(attr=>attr.Name.Trim().ToLower() == visibilityAttribute.Trim().ToLower());
        if(attribute == null)
            return defaultVisibility;
        
        List<string> validVisibility = new List<string>{"public","private","protected","internal"};
        if(validVisibility.Any(item=>item ==attribute.Value.Trim().ToLower()))
            return attribute.Value.Trim().ToLower();
        
        return defaultVisibility;
    }
    private string ExtractBody(OperationDto operation,string bodyAttribute ="body")
    {
        string NotImplementedExceptionStatement = "throw new NotImplementedException();";
        var attribute = operation.Attributes.FirstOrDefault(attr=>attr.Name.Trim().ToLower() == bodyAttribute.Trim().ToLower());
        if(Equals(attribute,null))
            return NotImplementedExceptionStatement;
        
        if(string.IsNullOrEmpty(attribute.Value.Trim()))
            return NotImplementedExceptionStatement;

        return attribute.Value;
    }

}