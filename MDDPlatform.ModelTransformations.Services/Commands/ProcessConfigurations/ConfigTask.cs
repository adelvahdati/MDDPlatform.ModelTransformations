using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class ConfigTask : ICommand
{
    public Guid ProcessConfigurationId {get;set;}
    public Guid TaskId {get;set;}
    public List<FieldValue>  ParemeterValues {get;set;}

    public ConfigTask(Guid processConfigurationId, Guid taskId, List<FieldValue> paremeterValues)
    {
        ProcessConfigurationId = processConfigurationId;
        TaskId = taskId;
        ParemeterValues = paremeterValues;
    }
}
public class ConfigTaskHandler : ICommandHandler<ConfigTask>
{
    private readonly IProcessConfigurationRepository _processConfigurationRepository;

    public ConfigTaskHandler(IProcessConfigurationRepository processConfigurationRepository)
    {
        _processConfigurationRepository = processConfigurationRepository;
    }

    public void Handle(ConfigTask command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ConfigTask command)
    {
        ProcessConfiguration processConfiguration = await _processConfigurationRepository.GetAsync(command.ProcessConfigurationId);
        if(Equals(processConfiguration,null))
            throw new Exception("Process Configuration Not Found");
        
        foreach(var fieldValue in command.ParemeterValues)
        {
            processConfiguration.ConfigTaskParameter(command.TaskId,fieldValue.Name,fieldValue.Value);
        }

        await _processConfigurationRepository.UpdateAsync(processConfiguration);
    }
}
