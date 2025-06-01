using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class TaskConfiguration : BaseEntity<Guid>
{
    public string TaskTitle {get; private set;}
    private List<TaskParameterValue> _parameterValues;

    public IReadOnlyList<TaskParameterValue> ParameterValues => _parameterValues;
    public bool IsConfigured => ! _parameterValues.Any(paramValue=>!paramValue.IsConfigured);

    public TaskConfiguration(Guid taskId, string title, List<TaskParameterValue> parameterValues)
    {
        Id= taskId;
        TaskTitle = title;
        _parameterValues = parameterValues;
    }
    public void ConfigParameter(string name,string value)
    {
        var parameterValue = _parameterValues.SingleOrDefault(fv=>fv.Name.ToLower() == name.ToLower());
        if(Equals(parameterValue, null))
            throw new Exception("Parameter not found");
        
        parameterValue.Config(value);
    }
}