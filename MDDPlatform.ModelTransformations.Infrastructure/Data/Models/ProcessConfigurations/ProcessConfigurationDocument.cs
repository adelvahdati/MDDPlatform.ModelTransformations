using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class ProcessConfigurationDocument : BaseEntity<Guid>
{
    public Guid ProcessId {get;  set;}
    public string Title {get;  set;}
    public List<TaskConfigurationDocument> TaskConfigurations {get;set;}

    public ProcessConfigurationDocument(Guid id,Guid processId, string title, List<TaskConfigurationDocument> taskConfigurations)
    {
        Id = id;
        this.ProcessId = processId;
        this.Title = title;
        this.TaskConfigurations = taskConfigurations;
    }

    public static ProcessConfigurationDocument CreateFrom(ProcessConfiguration processConfiguration)
    {
        List<TaskConfigurationDocument> taskConfigurations = processConfiguration.TaskConfigurations.Select(taskConfig=> TaskConfigurationDocument.CreateFrom(taskConfig)).ToList();    
        return new(processConfiguration.Id,processConfiguration.ProcessId,processConfiguration.Title,taskConfigurations);
    }

    public ProcessConfiguration ToProcessConfiguration()
    {
        var taskConfiguraions = TaskConfigurations.Select(taskConfigDoc=>taskConfigDoc.ToTaskConfiguration()).ToList();
        return ProcessConfiguration.Load(Id,ProcessId,Title,taskConfiguraions);
    }
}