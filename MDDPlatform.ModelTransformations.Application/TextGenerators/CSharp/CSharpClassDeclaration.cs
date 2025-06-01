using System.Text;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;

public class CSharpClassDeclaration
{
    public string Namespace {get;protected set;}

    public List<string> UsingStatements {get;protected set;}

    public string Name {get;protected set;}

    public string Extend {get;protected set;}

    public List<string> Realize {get;protected set;}

    public string Visibility {get;protected set;}

    public bool IsAbstract {get;protected set;}

    public bool IsStatic {get;protected set;}

    public List<AttributeDto> Attributes { get;protected  set; }

    public List<PropertyDto> Properties {get;protected set;}
    
    public List<OperationDto> Operations {get;set;}

    protected CSharpClassDeclaration(string @namespace, List<string> usingStatements, string name, string extend, List<string> realize, string visibility, bool isAbstract, bool isStatic, List<AttributeDto> attributes, List<PropertyDto> properties, List<OperationDto> operations)
    {
        Namespace = @namespace;
        UsingStatements = usingStatements;
        Name = name;
        Extend = extend;
        Realize = realize;
        Visibility = visibility;
        IsAbstract = isAbstract;
        IsStatic = isStatic;
        Attributes = attributes;
        Properties = properties;
        Operations = operations;
    }

    public CSharpClassDeclaration (ElementDto element)
    {
        Namespace = ExtractNamespace(element);
        UsingStatements = ExtractUsingStatements(element);
        Name = element.Name;
        Extend = ExtractSupperClass(element);
        Realize = ExtractRealizedInterface(element);
        Visibility = ExtractVisibility(element);
        IsAbstract = IsAbstractClass(element);
        IsStatic = IsStaticClass(element);
        Attributes = ExtractAttributeProperties(element);
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
        return element.Attributes.Where(attr=>attr.Name.Trim().ToLower()==usingStatementAttribute.Trim().ToLower())
                            .SelectMany(attr=>attr.Value.Split(","))
                            .ToList();
    }

    private string ExtractSupperClass(ElementDto element,string supperClassAttribute = "extend")
    {
        var attribute = element.Attributes.Where(attr=>attr.Name.Trim().ToLower() == supperClassAttribute.Trim().ToLower())
                                                        .FirstOrDefault();
        if(attribute== null)                                                    
            return "";
        return attribute.Value;
    }

    private List<string> ExtractRealizedInterface(ElementDto element, string realizationAttribute = "realize")
    {
        var realizedInterfaceAttribute = element.Attributes.Where(attr=>attr.Name.Trim().ToLower() == realizationAttribute.Trim().ToLower())
                                                        .FirstOrDefault();
        
        if(realizedInterfaceAttribute == null)
            return new();
        
        if(string.IsNullOrEmpty(realizedInterfaceAttribute.Value))
            return new();

        var result = realizedInterfaceAttribute.Value.Split(",");

        return result.ToList();        

    }

    private List<AttributeDto> ExtractAttributeProperties(ElementDto element,string exclude ="namespace,isstatic,isabstract,visibility,extend,realize,using")
    {
        List<string> excludeAttributes = exclude.Trim().ToLower().Split(",").Select(item=>item.Trim()).Where(item=>!string.IsNullOrEmpty(item)).ToList();
        return element.Attributes.Where(attr=> !excludeAttributes.Contains(attr.Name.Trim().ToLower()))
                                    .ToList();
    }

    private bool IsStaticClass(ElementDto element,string staticAttribute = "IsStatic")
    {
        bool status;
        var isStaticAttribute = element.Attributes.Where(attr=>attr.Name.Trim().ToLower()==staticAttribute.Trim().ToLower())
                                                    .FirstOrDefault();
        if(isStaticAttribute == null)
            return false;

        var result =  bool.TryParse(isStaticAttribute.Value, out status);
        if(result)
            return status;
        
        return false;
    }

    private bool IsAbstractClass(ElementDto element,string abstractAttribute = "IsAbstract")
    {
        bool status;
        var abstractionStatus = element.Attributes.Where(attr=>attr.Name.Trim().ToLower()==abstractAttribute.Trim().ToLower())
                                                    .FirstOrDefault();
        if(abstractionStatus == null)
            return false;

        var result =  bool.TryParse(abstractionStatus.Value, out status);
        if(result)
            return status;
        
        return false;
    }

    private string ExtractVisibility(ElementDto element,string visibilityAttribute = "visibility")
    {
        string DefaultVisibility = "public";
        var visibility = element.Attributes.Where(attr=>attr.Name.Trim().ToLower() == visibilityAttribute.Trim().ToLower())
                                            .FirstOrDefault();
        
        if(visibility == null)
            return DefaultVisibility;
        
        return visibility.Value;        
    }

    public string Build(){
        StringBuilder builder = new();
        builder.AppendLine(BuildUsingStatements());
        builder.AppendLine(BuildNameSpace());
        builder.AppendLine(BuildClassAttributes());
        builder.AppendLine(BuildStartOfClass());
        builder.AppendIndented(BuildClassProperties());
        builder.AppendIndented(BuildClassOperations());
        builder.AppendLine(BuildEndOfClass());
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

    // Build Class Attributes
    private string BuildClassAttributes()
    {
        StringBuilder builder = new();
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
        return builder.ToString();
    }

    // Build Start Of Class
    private string BuildStartOfClass()
    {
        StringBuilder builder = new();
        List<string> extendAndRealized = new();
        if(!string.IsNullOrEmpty(Extend))
            extendAndRealized.Add(Extend);
        if(Realize.Count>0)
            extendAndRealized.AddRange(Realize);
        
        string classDeclaration="class";

        if(IsStatic && !IsAbstract)
            classDeclaration = "static class";
        if(IsAbstract && !IsStatic)
            classDeclaration = "abstract class";
        
        builder.AppendFormat("{0} {1} {2}",Visibility,classDeclaration,Name);
        
        if(extendAndRealized.Count>0)
        {
            string imp = string.Join(",",extendAndRealized);
            builder.AppendFormat(" : {0}",imp);
        }
        builder.AppendLine();
        builder.Append("{");
        builder.AppendLine();

        return builder.ToString();
    }


    // Build Class Properties
    private string BuildClassProperties()
    {
        StringBuilder builder =new();
        foreach(var property in Properties)
        {
            var declaration = new ClassPropertyDeclaration(property);
            builder.AppendLine(declaration.Build());
        }
        return builder.ToString();
    } 


    // Build Class Operations
    private string BuildClassOperations()
    {
        StringBuilder builder =new();

        foreach(var operation in Operations)
        {
            var declaration = new ClassOperationDeclaration(operation);
            builder.AppendLine(declaration.Build());
        }

        return builder.ToString();
    }


    // Build End Of Class
    private string BuildEndOfClass()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("}");
        return builder.ToString();
    }


}