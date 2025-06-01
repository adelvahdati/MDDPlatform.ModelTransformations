using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;
using TaskStatus = MDDPlatform.ModelTransformations.Core.Enums.TaskStatus;

namespace MDDPlatform.ModelTransformations.Core.Entities;

public interface ITaskInstance
{
    Guid Id {get;}
    string Title { get; }
    TaskType Type { get; }
    TaskStatus Status { get; }
    List<TaskAttribute> Attributes { get; }
    Guid TemplateId { get; }
}

public abstract class TaskInstance : BaseEntity<Guid>, ITaskInstance
{
    public string Title { get; protected set; }
    public TaskType Type { get; protected set; }
    public TaskStatus Status { get; protected set; }
    public List<TaskAttribute> Attributes { get; protected set; }
    public Guid TemplateId { get; protected set; }


    protected TaskInstance(Guid id, string title, TaskType type, TaskStatus status)
    {
        Id = id;
        Title = title;
        Type = type;
        Status = status;
        Attributes = new();
        TemplateId = Guid.Empty;
    }
    protected TaskInstance(Guid id, string title, TaskType type, TaskStatus status, Guid templateId)
    {
        Id = id;
        Title = title;
        Type = type;
        Status = status;
        Attributes = new();
        TemplateId = templateId;
    }

    protected TaskInstance(Guid id, string title, TaskType type, TaskStatus status, List<TaskAttribute> attributes, Guid templateId)
    {
        Id = id;
        Title = title;
        Type = type;
        Status = status;
        Attributes = attributes;
        TemplateId = templateId;
    }

    internal abstract void Start();
    internal abstract void Reject();
    internal abstract void End();
    internal void Reset()
    {
        Status = TaskStatus.Ready;
    }
}