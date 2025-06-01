using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class TaskAttribute : ValueObject
{
    public string Name { get; set; }
    public string Value { get; set; }

    public TaskAttribute(string name, string value)
    {
        Name = name;
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Value;
    }

    public static TaskAttribute CreateFrom(FieldValue feildValue){
        return new TaskAttribute(feildValue.Name,feildValue.Value);
    }

    public static TaskAttribute CreateFrom(TaskParameterValue parameterValue)
    {
        if(!parameterValue.IsConfigured)
            throw new Exception("Task parameter is not configured");
        if(parameterValue.Value == null)
            throw new Exception("Task parameter should not be null");
        
        return new TaskAttribute(parameterValue.Name,parameterValue.Value);
    }

}