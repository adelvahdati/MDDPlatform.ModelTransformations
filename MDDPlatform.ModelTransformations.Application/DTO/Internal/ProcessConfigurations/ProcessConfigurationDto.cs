using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class ProcessConfigurationDto
{
    public Guid Id {get;set;}
    public Guid ProcessId {get;set;}
	public string Title {get; set;}
    public List<TaskConfigurationDto> TaskConfigurations {get;set;}

    public ProcessConfigurationDto(Guid id, Guid processId, string title, List<TaskConfigurationDto> taskConfigurations)
    {
        Id = id;
        ProcessId = processId;
        Title = title;
        TaskConfigurations = taskConfigurations;
    }

    public static ProcessConfigurationDto CreateFrom(ProcessConfiguration configuration)
    {
        var taskConfigurations = configuration.TaskConfigurations.Select(config=> TaskConfigurationDto.CreateFrom(config)).ToList();
        return new(configuration.Id,configuration.ProcessId,configuration.Title,taskConfigurations);
    }
}