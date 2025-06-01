using System.Text;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;


public class CSharpInterfaceDeclaration
{
    public string Namespace { get; protected set; }

    public List<string> UsingStatements { get; protected set; }

    public string Name { get; protected set; }

    public List<string> Extend { get; protected set; }

    public List<PropertyDto> Properties {get;protected set;}
    
    public List<OperationDto> Operations {get;set;}

    public CSharpInterfaceDeclaration(string @namespace, List<string> usingStatements, string name, List<string> extend, List<PropertyDto> properties, List<OperationDto> operations)
    {
        Namespace = @namespace;
        UsingStatements = usingStatements;
        Name = name;
        Extend = extend;
        Properties = properties;
        Operations = operations;
    }
    public CSharpInterfaceDeclaration(ElementDto element){
        Namespace = ExtractNamespace(element);
        UsingStatements = ExtractUsingStatements(element);
        Name = element.Name;
        Extend = ExtractExtendedInterface(element);
        Properties = element.Properties;
        Operations = element.Operations;
    }
    private string ExtractNamespace(ElementDto element,string namespaceAttribute = "namespace")
    {
        var attribute =  element.Attributes.Where(attr=>attr.Name.Trim().ToLower() == namespaceAttribute.Trim().ToLower())
                                            .FirstOrDefault();

        if(attribute == null)
            return "";

        return attribute.Value;
    }

    private List<string> ExtractUsingStatements(ElementDto element,string usingStatementAttribute = "using")
    {
        var statements =  element.Attributes.Where(attr=>attr.Name.Trim().ToLower()==usingStatementAttribute.Trim().ToLower())
                            .SelectMany(attr=>attr.Value.Split(","))
                            .ToList();
        
        if(statements == null)
            return new();
        
        return statements;
    }
    private List<string> ExtractExtendedInterface(ElementDto element, string extendAttribute = "extend")
    {
        var extendInterfaceAttribute = element.Attributes.Where(attr=>attr.Name.Trim().ToLower() == extendAttribute.Trim().ToLower())
                                                        .FirstOrDefault();
        
        if(extendInterfaceAttribute == null)
            return new();
        
        if(string.IsNullOrEmpty(extendInterfaceAttribute.Value))
            return new();

        var result = extendInterfaceAttribute.Value.Split(",");

        return result.ToList();        

    }
    public string Build(){
        StringBuilder builder = new();
        builder.AppendLine(BuildUsingStatements());
        builder.AppendLine(BuildNameSpace());
        builder.AppendLine(BuildStartOfInterface());
        builder.AppendIndented(BuildInterfaceProperties());
        builder.AppendIndented(BuildInterfaceOperations());
        builder.AppendLine(BuildEndOfInterface());
        return builder.ToString();
    }
    // Build Using Statements
    private string BuildUsingStatements()
    {
        StringBuilder builder = new();
        foreach(var usingStatement in UsingStatements){
            builder.AppendFormat("using {0};",usingStatement);
            builder.AppendLine();
        }
        return builder.ToString();
    }

    // Build Namespace
    private string BuildNameSpace()
    {
        StringBuilder builder = new();
        if(!string.IsNullOrEmpty(Namespace)){
            builder.AppendFormat("namespace {0};",Namespace);
            builder.AppendLine();
        }
        return builder.ToString();
    }
    
    private string BuildStartOfInterface()
    {
        StringBuilder builder = new();
        
        string interfaceDeclaration="interface";

        
        builder.AppendFormat("public {0} {1}",interfaceDeclaration,Name);
        
        if(Extend.Count>0)
        {
            string imp = string.Join(",",Extend);
            builder.AppendFormat(" : {0}",imp);
        }
        builder.AppendLine();
        builder.Append("{");
        builder.AppendLine();

        return builder.ToString();
    }
    // Build Interface Properties
    private string BuildInterfaceProperties()
    {
        StringBuilder builder =new();
        foreach(var property in Properties)
        {
            var declaration = new InterfacePropertyDeclaration(property);
            builder.AppendLine(declaration.Build());
        }
        return builder.ToString();
    } 


    // Build Interface Operations
    private string BuildInterfaceOperations()
    {
        StringBuilder builder =new();

        foreach(var operation in Operations)
        {
            var declaration = new InterfaceOperationDeclaration(operation);
            builder.AppendLine(declaration.Build());
        }

        return builder.ToString();
    }

    // Build End Of Interface
    private string BuildEndOfInterface()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("}");
        return builder.ToString();
    }


}