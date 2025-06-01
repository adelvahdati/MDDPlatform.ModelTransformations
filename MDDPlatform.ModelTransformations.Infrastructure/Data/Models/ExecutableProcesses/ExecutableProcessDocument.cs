using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class ExecutableProcessDocument : BaseEntity<Guid>{
    public Guid ProcessId {get;set;}    
    public Guid ProcessConfigurationId => Id;
    public ProcessExecutionStatus Status {get;set;}
    public List<TaskInstanceDocument> TaskInstances {get;set;}

    public ExecutableProcessDocument(Guid id,Guid processId, ProcessExecutionStatus status, List<TaskInstanceDocument> taskInstances)
    {
        Id = id;
        ProcessId = processId;
        Status = status;
        TaskInstances = taskInstances;
    }
    public static ExecutableProcessDocument CreateFrom(ExecutableProcess executableProcess)
    {
        var taskInstances = executableProcess.TaskInstances.Select(taskInstance=> TaskInstanceDocument.CreateFrom(taskInstance)).ToList();

        return new ExecutableProcessDocument(executableProcess.Id,executableProcess.ProcessId,executableProcess.Status,taskInstances);
    }
    public ExecutableProcess ToExecutableProcess(){
        var taskInstances = TaskInstances.Select(taskInstanceDto=>taskInstanceDto.ToTaskInstance()).ToList();
        return ExecutableProcess.Load(Id,ProcessId,taskInstances);
    }

}