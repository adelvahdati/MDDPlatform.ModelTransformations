using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class TaskConfigurationDto
{
    public Guid Id {get;set;}
    public string TaskTitle {get; set;}
    public List<TaskParameterValueDto> ParameterValues {get;set;}

    public TaskConfigurationDto(Guid id, string taskTitle, List<TaskParameterValueDto> parameterValues)
    {
        Id = id;
        TaskTitle = taskTitle;
        ParameterValues = parameterValues;
    }

    public static TaskConfigurationDto CreateFrom(TaskConfiguration configuration)
    {
        var parameters = configuration.ParameterValues.Select(param=>TaskParameterValueDto.CreateFrom(param)).ToList();
        return new(configuration.Id,configuration.TaskTitle,parameters);        
    }
}