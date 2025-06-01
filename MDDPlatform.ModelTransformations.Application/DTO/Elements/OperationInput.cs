namespace MDDPlatform.ModelTransformations.Application.DTO.Elements;

public class OperationInput{
    public string Name {get;set;}
    public string Type {get;set;}

    public OperationInput(string name, string type)
    {
        Name = name;
        Type = type;
    }
}
