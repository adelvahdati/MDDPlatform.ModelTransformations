using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class WorkUnit : BaseEntity<Guid>
{
    protected TaskType _type;
    protected List<TaskParameter> _parameters;
    protected List<TaskAttribute> _attributes;

    public string Title {get; protected set;}
    public Guid TaskTemplateId {get; protected set;}
    public TaskType Type => _type;
    public IReadOnlyList<TaskParameter> Parameters => _parameters;
    public IReadOnlyList<TaskAttribute> Attributes => _attributes;


    protected WorkUnit(TaskType type, string title,Guid taskTemplateId,List<TaskParameter> parameters, List<TaskAttribute> attributes)
    {
        Id = Guid.NewGuid();
        _type = type;
        Title = title;
        TaskTemplateId = taskTemplateId;
        _parameters = parameters;
        _attributes = attributes;
    }

    protected WorkUnit(Guid id, TaskType type, string title, Guid taskTemplateId, List<TaskParameter> parameters, List<TaskAttribute> attributes)
    {
        Id = id;
        _type = type;
        Title = title;
        TaskTemplateId = taskTemplateId;
        _parameters = parameters;
        _attributes = attributes;
    }

    public static WorkUnit CreateModelTransformationTask(string taskTitle, PatternInstanceTemplate taskTemplate)
    {
        var parameters = taskTemplate.Variables.Select(field=> TaskParameter.CreateFrom(field)).ToList();
        var attributes = taskTemplate.FieldValues.Select(fieldValue=> TaskAttribute.CreateFrom(fieldValue)).ToList();
        return new WorkUnit(TaskType.PatternInstanceExecution,
                            taskTitle,
                            taskTemplate.Id, 
                            parameters,
                            attributes);

    }
    public static WorkUnit CreateScriptExecutionTask(string taskTitle, CodeTemplate taskTemplate)
    {
        var parameters = taskTemplate.Variables.Select(field=> TaskParameter.CreateFrom(field)).ToList();
        var isntructionsAttribute = new TaskAttribute("Instructions",taskTemplate.ToJsonString());        
        var attributes = new List<TaskAttribute>();
        attributes.Add(isntructionsAttribute);
        return new WorkUnit(TaskType.ScriptExecution,
                            taskTitle,
                            taskTemplate.Id,
                            parameters,
                            attributes);
    }
    public static WorkUnit CreateManualTask(string taskTitle)
    {
        return new WorkUnit(TaskType.ManualTask,
                            taskTitle,
                            Guid.Empty,
                            new(),
                            new());
    }
    public static WorkUnit Load(Guid id,TaskType type, string title,Guid taskTemplateId,List<TaskParameter> parameters,List<TaskAttribute> attributes )
    {
        return new WorkUnit(id,type,title,taskTemplateId,parameters,attributes);
    }
    
}