using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class ProcessConfiguration : BaseEntity<Guid>
{
    private List<TaskConfiguration> _taskConfigurations;

    public Guid ProcessId {get; private set;}
    public string Title {get; private set;}
    public IReadOnlyList<TaskConfiguration> TaskConfigurations => _taskConfigurations;
    public bool IsConfigured => !_taskConfigurations.Any(taskConfiguration=> !taskConfiguration.IsConfigured);
    private ProcessConfiguration(Guid processId, string title , List<TaskConfiguration> taskConfigurations)
    {
        Id = Guid.NewGuid();
        Title = title;
        _taskConfigurations = taskConfigurations;
        ProcessId = processId;
    }
    private ProcessConfiguration(Guid id, Guid processId, string title ,List<TaskConfiguration> taskConfigurations)
    {
        Id = id;
        Title = title;
        _taskConfigurations = taskConfigurations;
        ProcessId = processId;
    }
    public static ProcessConfiguration Create(Guid processId, string title , List<TaskConfiguration> taskConfigurations){
        return new(processId,title,taskConfigurations);
    }
    public static ProcessConfiguration Load(Guid id, Guid processId, string title ,List<TaskConfiguration> taskConfigurations)
    {
        return new(id,processId,title,taskConfigurations);        
    }
    public void ConfigTaskParameter(Guid taskId, string name,string value)
    {
        var taskConfiguration = _taskConfigurations.Find(taskConfiguration => taskConfiguration.Id == taskId);
        if(Equals(taskConfiguration,null))
            throw new Exception("Task not found");
        
        taskConfiguration.ConfigParameter(name,value);        
    }

    public TaskConfiguration? GetTaskConfiguration(Guid id)
    {
        return _taskConfigurations.FirstOrDefault(taskConfiguration=>taskConfiguration.Id == id);
    }
}