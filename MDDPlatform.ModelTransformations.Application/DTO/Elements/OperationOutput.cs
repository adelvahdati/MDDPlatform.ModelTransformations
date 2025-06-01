namespace MDDPlatform.ModelTransformations.Application.DTO.Elements;

public class OperationOutput
{
    public string Type {get;set;}
    public bool IsCollection {get;set;}

    public OperationOutput(string type, bool isCollection)
    {
        Type = type;
        IsCollection = isCollection;
    }
    public OperationOutput(){
        Type="";
        IsCollection=false;
    }
}