using System.Text;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;
public class InterfaceOperationDeclaration
{
    public string Name {get; protected set;}
    public OperationOutput Output {get;protected set;}
    public List<OperationInput> Inputs {get;protected set;}

    public InterfaceOperationDeclaration(string name, OperationOutput output, List<OperationInput> inputs)
    {
        Name = name;
        Output = output;
        Inputs = inputs;
    }
    public InterfaceOperationDeclaration(OperationDto operation)    
    {
        Name = operation.Name;
        Output = operation.Output;
        Inputs = operation.Inputs;
    }
    public string Build()
    {
        StringBuilder  builder = new StringBuilder("");
        string output = Output.IsCollection == true? $"List<{Output.Type}>" : Output.Type;
        var inputs = Inputs.Select(input=> $"{input.Type} {input.Name}").ToList();
        var inputParameters = string.Join(",",inputs);
        builder.AppendFormat("{0} {1}({2});",output,Name,inputParameters);
        builder.AppendLine();
        return builder.ToString();
    }

}