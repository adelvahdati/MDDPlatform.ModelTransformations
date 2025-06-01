using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class TaskParameterValueDto{
    public string Name {get; set;}
    public string? Value {get; set;}
    public bool IsConfigured {get;set;}

    public TaskParameterValueDto(string name, string? value, bool isConfigured)
    {
        Name = name;
        Value = value;
        IsConfigured = isConfigured;
    }
    public static TaskParameterValueDto CreateFrom(TaskParameterValue taskParameterValue){
        return new(taskParameterValue.Name,taskParameterValue.Value,taskParameterValue.IsConfigured);
    }
}