using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class ExecutableProcessDto
{
    public Guid Id {get;set;}
    public Guid ProcessId {get;set;}    
    public Guid ProcessConfigurationId => Id;
    public ProcessExecutionStatus Status {get;set;}
    public List<TaskInstanceDto> TaskInstances {get;set;}

    public ExecutableProcessDto(Guid id, Guid processId, ProcessExecutionStatus status, List<TaskInstanceDto> taskInstances)
    {
        Id = id;
        ProcessId = processId;
        Status = status;
        TaskInstances = taskInstances;
    }

    public static ExecutableProcessDto CreateFrom(ExecutableProcess executableProcess)
    {
        var taskInstances = executableProcess.TaskInstances.Select(taskInstance=> TaskInstanceDto.CreateFrom(taskInstance)).ToList();

        return new ExecutableProcessDto(executableProcess.Id,executableProcess.ProcessId,executableProcess.Status,taskInstances);
    }
    public ExecutableProcess ToExecutableProcess(){
        var taskInstances = TaskInstances.Select(taskInstanceDto=>taskInstanceDto.ToTaskInstance()).ToList();
        return ExecutableProcess.Load(Id,ProcessId,taskInstances);
    }

}