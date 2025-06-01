using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class UpdateProcessConfiguration : ICommand
{
    public Guid ProcessConfigurationId {get;set;}

    public UpdateProcessConfiguration(Guid processConfigurationId)
    {
        ProcessConfigurationId = processConfigurationId;
    }
}
public class UpdateProcessConfigurationHandler : ICommandHandler<UpdateProcessConfiguration>
{
    private readonly IProcessRepository _processRepository;
    private readonly IProcessConfigurationRepository _processConfigurationRepository;
    private readonly IExecutableProcessRepository _executableProcessRepository;

    public UpdateProcessConfigurationHandler(IProcessRepository processRepository, IProcessConfigurationRepository processConfigurationRepository, IExecutableProcessRepository executableProcessRepository)
    {
        _processRepository = processRepository;
        _processConfigurationRepository = processConfigurationRepository;
        _executableProcessRepository = executableProcessRepository;
    }

    public void Handle(UpdateProcessConfiguration command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(UpdateProcessConfiguration command)
    {
        var processConfiguration = await _processConfigurationRepository.GetAsync(command.ProcessConfigurationId);
        if(Equals(processConfiguration,null))
            throw new Exception("Process Configuration Not Found");
        
        var process = await _processRepository.GetProcessAsync(processConfiguration.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process Not Found");
        
        var workUnits = process.Phases.SelectMany(phase => phase.Activities)
                                        .SelectMany(activity=> activity.Tasks)
                                        .ToList();
        
        var aoutomaticTask = workUnits.Where(workUnit=>workUnit.Type != Core.Enums.TaskType.ManualTask)
                                        .ToList();
        

        var taskConfigurations = new List<TaskConfiguration>();

        foreach(var task in aoutomaticTask)
        {
            var taskParameters = task.Parameters.Select(param=> TaskParameterValue.Create(param.Name)).ToList();
            var taskConfiguration = new TaskConfiguration(task.Id,task.Title,taskParameters);
            taskConfigurations.Add(taskConfiguration);
        }

        var newProcessConfiguration = ProcessConfiguration.Load(processConfiguration.Id,processConfiguration.ProcessId,processConfiguration.Title,taskConfigurations);
        await _processConfigurationRepository.UpdateAsync(newProcessConfiguration);
        await _executableProcessRepository.DeleteAsync(processConfiguration.Id);
    }
}
