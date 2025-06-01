using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class TaskTemplate : ValueObject{
    public string Title {get;set;}
    public TaskType Type {get;set;}
    public Guid TemplateId {get;set;}

    public TaskTemplate(string title, TaskType type, Guid templateId)
    {
        Title = title;
        Type = type;
        TemplateId = templateId;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Type;
        yield return TemplateId;
    }
}