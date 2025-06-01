using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Entities;
using TaskStatus = MDDPlatform.ModelTransformations.Core.Enums.TaskStatus;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class TaskInstanceDocument : BaseEntity<Guid>
{    
    public string Title {get;  set;}
    public TaskType Type {get;  set;}
    public TaskStatus Status {get; set;}
    public List<TaskAttributeDocument> Attributes { get;  set; }
    public Guid TemplateId {get;set;}

    public TaskInstanceDocument(Guid id, string title, TaskType type, TaskStatus status, List<TaskAttributeDocument> attributes, Guid templateId)
    {
        Id = id;
        Title = title;
        Type = type;
        Status = status;
        Attributes = attributes;
        TemplateId = templateId;
    }
    public static TaskInstanceDocument CreateFrom(TaskInstance taskInstance)
    {
        var attributes = taskInstance.Attributes.Select(attribute=> TaskAttributeDocument.CreateFrom(attribute)).ToList();
        return new TaskInstanceDocument(taskInstance.Id,taskInstance.Title,taskInstance.Type,taskInstance.Status,attributes,taskInstance.TemplateId);
    }
    public TaskInstance ToTaskInstance()
    {
        if(Type == TaskType.ManualTask)
            return ManualTask.Load(Id,Title,Status,TemplateId);
        else if(Type == TaskType.PatternInstanceExecution)
        {
            var attributes = Attributes.Select(attrDto=>attrDto.ToTaskAttribute()).ToList();
            return ExecutableTask.Load(Id,Title,Status,attributes,TemplateId);
        }
        else if(Type == TaskType.ScriptExecution)
            throw new NotImplementedException();
        else
            throw new Exception("Task type is not supported");            
    }

}