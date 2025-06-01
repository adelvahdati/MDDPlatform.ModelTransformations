using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using TaskStatus = MDDPlatform.ModelTransformations.Core.Enums.TaskStatus;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class ExecutableTask : TaskInstance
{

    internal ExecutableTask(Guid id,string title, List<TaskAttribute> attributes,Guid templateId) 
        : base(id,title, TaskType.PatternInstanceExecution, TaskStatus.Ready,attributes,templateId)
    {
    }
    internal ExecutableTask(Guid id,string title,TaskStatus status,List<TaskAttribute> attributes,Guid templateId) 
        : base(id,title,TaskType.PatternInstanceExecution,status,attributes,templateId)
    {

    }

    public static ExecutableTask Load(Guid id,string title,TaskStatus status,List<TaskAttribute> attributes,Guid templateId){
        return new ExecutableTask(id,title,status,attributes,templateId);
    }
    public static ExecutableTask CreateInstance(WorkUnit workUnit,TaskConfiguration taskConfiguration)
    {
        if(workUnit.Type != TaskType.PatternInstanceExecution)
            throw new Exception("Invalid WorkUnit Type : work unit is not pattern instance execution");
        
        if(Equals(taskConfiguration,null))
            throw new Exception("Task configuration should not be null");

        if(!taskConfiguration.IsConfigured)
            throw new Exception("Task is not configured");
        
        var taskAttributes = workUnit.Attributes.ToList();
        var configValues = taskConfiguration.ParameterValues.Select(paramValue=>TaskAttribute.CreateFrom(paramValue)).ToList();
        taskAttributes.AddRange(configValues);

        var templateId = workUnit.TaskTemplateId;

        return new ExecutableTask(workUnit.Id,workUnit.Title,taskAttributes,templateId);
    }

    internal override void Start()
    {
        if(Status!=TaskStatus.Ready)
            throw new Exception("Task is executed previousely");
        
        Status = TaskStatus.Start;
    }

    internal override void Reject()
    {
        if(Status == TaskStatus.Ready)
            throw new Exception("Task is not executed yet");

        if(Status == TaskStatus.Done)
            throw new Exception("Task is done. you can't change the status");
        
        Status = TaskStatus.Failed;
    }

    internal override void End()
    {
        if(Status == TaskStatus.Ready)
            throw new Exception("Task is not executed yet");

        if(Status == TaskStatus.Failed)
            throw new Exception("Task is failed. If you want to run it again, you should reset the stage before running again");

        Status = TaskStatus.Done;
    }
}