using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using TaskStatus = MDDPlatform.ModelTransformations.Core.Enums.TaskStatus;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class TaskInstanceDto
{
    public Guid Id {get;set;}
    public string Title {get;  set;}
    public TaskType Type {get;  set;}
    public TaskStatus Status {get; set;}
    public List<TaskAttributeDto> Attributes { get;  set; }
    public Guid TemplateId {get;set;}

    public TaskInstanceDto(Guid id,string title, TaskType type, TaskStatus status, List<TaskAttributeDto> attributes,Guid templateId)
    {
        Id = id;
        Title = title;
        Type = type;
        Status = status;
        Attributes = attributes;
        TemplateId = templateId;
    }

    public static TaskInstanceDto CreateFrom(TaskInstance taskInstance)
    {
        var attributes = taskInstance.Attributes.Select(attribute=> TaskAttributeDto.CreateFrom(attribute)).ToList();
        return new TaskInstanceDto(taskInstance.Id,taskInstance.Title,taskInstance.Type,taskInstance.Status,attributes,taskInstance.TemplateId);
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