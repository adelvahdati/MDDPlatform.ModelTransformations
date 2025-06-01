using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class TaskParameterDto 
{
    public string Label {get;set;}
    public string Name {get; set;}    
    public FieldType Type {get;set;}

    public TaskParameterDto(string label, string name, FieldType type)
    {
        Label = label;
        Name = name;
        Type = type;
    }
    public static TaskParameterDto CreateFrom(TaskParameter parameter)
    {
        return new TaskParameterDto(parameter.Label,parameter.Name,parameter.Type);        
    }
    public TaskParameter ToTaskParameter(){
        return new TaskParameter(Label,Name,Type);
    }
}