using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Entities;
using TaskStatus = MDDPlatform.ModelTransformations.Core.Enums.TaskStatus;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class ExecutableProcess : BaseEntity<Guid>
{    
    private List<TaskInstance> _taskInstances;
    public Guid ProcessId {get; private set;}
    public Guid ProcessConfigurationId => Id;
    public ProcessExecutionStatus Status => GetProcessStatus();

    public IReadOnlyList<TaskInstance> TaskInstances => _taskInstances;

    private ExecutableProcess(Guid processId, Guid processConfigurationId,List<TaskInstance> taskInstances)
    {
        ProcessId = processId;
        Id = processConfigurationId;
        _taskInstances = taskInstances;
    }
    public static ExecutableProcess Load(Guid id,Guid processId,List<TaskInstance> taskInstances)
    {
        return new(processId,id,taskInstances);
    }
    public static ExecutableProcess Create(Process process , ProcessConfiguration processConfiguration)
    {
        if(!processConfiguration.IsConfigured)
            throw new Exception("Process is not configured");

        var workUnits = process.WorkUnits;
        var taskInstances = new List<TaskInstance>();        

        foreach (var workUnit in workUnits)
        {
            if(workUnit.Type == TaskType.ManualTask){
                var taskInstance = ManualTask.CreateInstance(workUnit);
                taskInstances.Add(taskInstance);            
            }
            else if(workUnit.Type == TaskType.PatternInstanceExecution)
            {
                var taskConfiguration = processConfiguration.GetTaskConfiguration(workUnit.Id);
                if(Equals(taskConfiguration,null))
                    throw new Exception($"Task configuration for TaskId={workUnit.Id} not found");
                
                var taskInstance = ExecutableTask.CreateInstance(workUnit,taskConfiguration);
                taskInstances.Add(taskInstance); 
            }
            else if(workUnit.Type == TaskType.ScriptExecution)
            {
                throw new NotImplementedException();
            }
            else
                throw new Exception("WorkUnit is not supported");                       
        }
        return new ExecutableProcess(process.Id,processConfiguration.Id,taskInstances);
    }

    public ITaskInstance? NextTask()
    {
        TaskInstance? instance;
        instance = _taskInstances.Where(task=>task.Status == TaskStatus.Failed).FirstOrDefault();
        if(!Equals(instance,null))
            throw new Exception($"Task Failed.(title : {instance.Title})");

        instance = _taskInstances.Where(task=>task.Status == TaskStatus.Start).FirstOrDefault();
        if(!Equals(instance,null))
            throw new Exception($"{instance.Title} (TaskId : {instance.Id}) is started and not yet finished");

        instance = _taskInstances.Where(task=>task.Status == TaskStatus.Ready).FirstOrDefault();
        return instance;
    }

    private ProcessExecutionStatus GetProcessStatus()
    {
        if(_taskInstances.Any(task=>task.Status == TaskStatus.Failed))
            return ProcessExecutionStatus.Failed;
        
        if(_taskInstances.All(task=> task.Status == TaskStatus.Done))
            return ProcessExecutionStatus.Done;

        if(_taskInstances.All(task=> task.Status == TaskStatus.Ready))
            return ProcessExecutionStatus.Ready;

        var task = _taskInstances.Where(instance=>instance.Status !=TaskStatus.Done && instance.Status!=TaskStatus.Failed).FirstOrDefault();
        if(!Equals(task,null) && task.Type == TaskType.ManualTask && task.Status !=TaskStatus.Done)
            return ProcessExecutionStatus.Pending;
        
        return ProcessExecutionStatus.InProgress;        
    }

    public void StartTask(Guid id)
    {
        var taskInstance = TaskInstances.FirstOrDefault(task=> task.Id == id);
        if(Equals(taskInstance,null))
            throw new Exception("Start Task Exception : Task Not Found");
        
        taskInstance.Start();
    }
    public void RejectTask(Guid id)
    {
        var taskInstance = TaskInstances.FirstOrDefault(task=> task.Id == id);
        if(Equals(taskInstance,null))
            throw new Exception("Reject Task Exception : Task Not Found");

        taskInstance.Reject();
    }
    public void ResetTask(Guid id)
    {
        var taskInstance = TaskInstances.FirstOrDefault(task=> task.Id == id);
        if(Equals(taskInstance,null))
            throw new Exception("Reset Task Exception : Task Not Found");
        
        taskInstance.Reset();        
    }
    public void EndTask(Guid id)
    {
        var taskInstance = TaskInstances.FirstOrDefault(task=> task.Id == id);
        if(Equals(taskInstance,null))
            throw new Exception("End Task Exception : Task Not Found");
        
        taskInstance.End();
    }
    public void ResetProcess()
    {
        foreach(var task in _taskInstances){
            task.Reset();
        }
    }

    public void HandleManualTask(Guid taskId)
    {
        var taskInstance = TaskInstances.FirstOrDefault(task=> task.Id == taskId);
        if(Equals(taskInstance,null))
            throw new Exception("Hanlde Manual Task Exception : Manual Task Not Found");
        
        if(taskInstance.Type != TaskType.ManualTask)
            throw new Exception("Hanlde Manual Task Exception : Task is not manual");
        
        taskInstance.End();
    }
}