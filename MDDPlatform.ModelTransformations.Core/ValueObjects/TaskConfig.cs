using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class TaskConfig : ValueObject
{
    public Guid TaskId {get;set;}
    public List<FieldValue> ParameterValues {get;set;}

    public TaskConfig(Guid taskId, List<FieldValue> parameterValues)
    {
        this.TaskId = taskId;
        this.ParameterValues = parameterValues;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return TaskId;
        yield return ParameterValues;        
    }
}