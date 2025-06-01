using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class TaskAttributeDocument
{
    public string Name { get; set; }
    public string Value { get; set; }

    public TaskAttributeDocument(string name, string value)
    {
        this.Name = name;
        this.Value = value;
    }

    public static TaskAttributeDocument CreateFrom(TaskAttribute attribute)
    {
        return new TaskAttributeDocument(attribute.Name,attribute.Value);
    }
    public  TaskAttribute ToTaskAttribute(){
        return new TaskAttribute(Name,Value);
    }
}