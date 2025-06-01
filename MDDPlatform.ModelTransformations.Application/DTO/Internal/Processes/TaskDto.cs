using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class TaskDto
{
    public Guid Id {get;set;}

    public string Title {get;set;}
    public Guid TaskTemplateId {get;set;}
    public TaskType Type {get;set;}
    public List<TaskParameterDto> Parameters {get;set;}
    public List<TaskAttributeDto> Attributes {get;set;}

    public TaskDto(Guid id, string title, Guid taskTemplateId, TaskType type, List<TaskParameterDto> parameters,List<TaskAttributeDto> attributes)
    {
        Id = id;
        Title = title;
        TaskTemplateId = taskTemplateId;
        Type = type;
        Parameters = parameters;
        Attributes = attributes;
    }

    public static TaskDto CreateFrom(WorkUnit task)
    {
        var parameters = task.Parameters.Select(param=>TaskParameterDto.CreateFrom(param)).ToList();
        var attributes = task.Attributes.Select(attribute=>TaskAttributeDto.CreateFrom(attribute)).ToList();
        return new TaskDto(task.Id,task.Title,task.TaskTemplateId,task.Type,parameters,attributes);
    }
}