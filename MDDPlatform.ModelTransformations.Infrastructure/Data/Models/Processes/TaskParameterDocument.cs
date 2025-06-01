using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class TaskParameterDocument
{
    public string Label {get;set;}
    public string Name {get; set;}    
    public FieldType Type {get;set;}

    public TaskParameterDocument(string label, string name, FieldType type)
    {
        Label = label;
        Name = name;
        Type = type;
    }
    public static TaskParameterDocument CreateFrom(TaskParameter parameter)
    {
        return new TaskParameterDocument(parameter.Label,parameter.Name,parameter.Type);
    }
    public TaskParameter ToTaskParameter()
    {
        return new TaskParameter(Label,Name,Type);
    }

}