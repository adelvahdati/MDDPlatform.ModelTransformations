using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class TaskParameter : ValueObject
{
    public string Label {get;set;}
    public string Name {get; set;}    
    public FieldType Type {get;set;}

    public TaskParameter(string label, string name, FieldType type)
    {
        this.Label = label;
        this.Name = name;
        this.Type = type;
    }

    public static TaskParameter CreateFrom(Field field){
        return new TaskParameter(field.Label,field.Name,field.Type);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Label;
        yield return Name;
        yield return Type;
    }
}