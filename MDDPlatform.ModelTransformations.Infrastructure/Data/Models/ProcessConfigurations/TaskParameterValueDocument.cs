using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class TaskParameterValueDocument
{
    public string Name {get;  set;}
    public string? Value {get;  set;}
    public bool IsConfigured {get;  set;}

    public TaskParameterValueDocument(string name, string? value, bool isConfigured)
    {
        Name = name;
        Value = value;
        IsConfigured = isConfigured;
    }

    public static TaskParameterValueDocument CreateFrom(TaskParameterValue parameterValue)
    {
        return new(parameterValue.Name,parameterValue.Value,parameterValue.IsConfigured);
    }

    public TaskParameterValue ToTaskParameterValue()
    {
        return TaskParameterValue.Load(Name,Value,IsConfigured);
    }
}