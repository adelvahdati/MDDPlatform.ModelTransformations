using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class TaskAttributeDto{
    public string Name { get; set; }
    public string Value { get; set; }

    public TaskAttributeDto(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public static TaskAttributeDto CreateFrom(TaskAttribute attribute)
    {
        return new(attribute.Name,attribute.Value);
    }

    public TaskAttribute ToTaskAttribute(){
        return new TaskAttribute(Name,Value);
    }
}