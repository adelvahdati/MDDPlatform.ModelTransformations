using MDDPlatform.ModelTransformations.Core.Enums;
using TaskStatus = MDDPlatform.ModelTransformations.Core.Enums.TaskStatus;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class ManualTask : TaskInstance
{
    internal ManualTask(Guid id,string title) 
        : base(id,title, TaskType.ManualTask, TaskStatus.Ready)
    {
    }
    internal ManualTask(Guid id,string title,TaskStatus status) 
        : base(id,title, TaskType.ManualTask, status)
    {
    }
    internal ManualTask(Guid id,string title,TaskStatus status,Guid templateId)
        : base(id,title,TaskType.ManualTask,status,templateId)
    {

    }
    public static ManualTask CreateInstance(WorkUnit workUnit)
    {
        if(workUnit.Type != TaskType.ManualTask)
            throw new Exception("Invalid WorkUnit Type : workUnit is not maual task");

        return new ManualTask(workUnit.Id,workUnit.Title);
    }

    public static TaskInstance Load(Guid id, string title, TaskStatus status, Guid templateId)
    {
        return new ManualTask(id,title,status,templateId);
    }

    internal override void End()
    {
        Status = TaskStatus.Done;
    }

    internal override void Reject()
    {
        Status = TaskStatus.Failed;
    }

    internal override void Start()
    {
        Status = TaskStatus.Start;
    }
}