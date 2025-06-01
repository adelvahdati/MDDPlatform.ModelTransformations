using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateProcessConfiguration : ICommand
{
    public Guid ProcessId {get;set;}
    public string Title {get;set;}

    public CreateProcessConfiguration(Guid processId, string title)
    {
        ProcessId = processId;
        Title = title;
    }
}
public class CreateProcessConfigurationHandler : ICommandHandler<CreateProcessConfiguration>
{
    private readonly IProcessRepository _processRepository;
    private readonly IProcessConfigurationRepository _processConfigurationRepository;

    public CreateProcessConfigurationHandler(IProcessRepository processRepository, IProcessConfigurationRepository processConfigurationRepository)
    {
        _processRepository = processRepository;
        _processConfigurationRepository = processConfigurationRepository;
    }

    public void Handle(CreateProcessConfiguration command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateProcessConfiguration command)
    {
        Process process =  await _processRepository.GetProcessAsync(command.ProcessId);
        if(Equals(process,null))
            throw new Exception("Process not found");
        
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
        var processConfiguration =  ProcessConfiguration.Create(command.ProcessId,command.Title,taskConfigurations);

        await _processConfigurationRepository.CreateAsync(processConfiguration);
    }
}
