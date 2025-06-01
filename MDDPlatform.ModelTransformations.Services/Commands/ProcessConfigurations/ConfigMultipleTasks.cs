using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class ConfigMultipleTasks : ICommand
{
    public Guid ProcessConfigurationId {get;set;}
    public List<TaskConfig> TaskConfigs {get;set;}

    public ConfigMultipleTasks(Guid processConfigurationId, List<TaskConfig> taskConfigs)
    {
        ProcessConfigurationId = processConfigurationId;
        TaskConfigs = taskConfigs;
    }
}
public class ConfigMultipleTasksHandler : ICommandHandler<ConfigMultipleTasks>
{
    private readonly IProcessConfigurationRepository _processConfigurationRepository;

    public ConfigMultipleTasksHandler(IProcessConfigurationRepository processConfigurationRepository)
    {
        _processConfigurationRepository = processConfigurationRepository;
    }

    public void Handle(ConfigMultipleTasks command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ConfigMultipleTasks command)
    {
        ProcessConfiguration processConfiguration = await _processConfigurationRepository.GetAsync(command.ProcessConfigurationId);
        if(Equals(processConfiguration,null))
            throw new Exception("Process Configuration Not Found");

        foreach(var taskConfig in command.TaskConfigs)
        {
            var taskId = taskConfig.TaskId;
            foreach(var fieldValue in taskConfig.ParameterValues)
            {
                processConfiguration.ConfigTaskParameter(taskId,fieldValue.Name,fieldValue.Value);
            }
        }
        await _processConfigurationRepository.UpdateAsync(processConfiguration);
    }
}
