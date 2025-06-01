using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class TaskConfigurationDocument : BaseEntity<Guid>{
    public string TaskTitle {get;set;}

    public List<TaskParameterValueDocument> ParameterValues {get;set;}

    public TaskConfigurationDocument(Guid id, string taskTitle, List<TaskParameterValueDocument> parameterValues)
    {
        Id = id;
        TaskTitle = taskTitle;
        ParameterValues = parameterValues;
    }

    internal static TaskConfigurationDocument CreateFrom(TaskConfiguration taskConfig)
    {
        var parameters = taskConfig.ParameterValues.Select(param=> TaskParameterValueDocument.CreateFrom(param)).ToList();
        return new(taskConfig.Id,taskConfig.TaskTitle,parameters);
    }
    public TaskConfiguration ToTaskConfiguration()
    {
        var parameterValues = ParameterValues.Select(paramDoc=> paramDoc.ToTaskParameterValue()).ToList();

        return new TaskConfiguration(Id,TaskTitle,parameterValues);
    }
}