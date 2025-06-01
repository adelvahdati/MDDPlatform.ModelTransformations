using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class WorkUnitDocument : BaseEntity<Guid>
{
    public string Title {get;set;}
    public Guid TaskTemplateId {get;set;}
    public TaskType Type {get;set;}

    public List<TaskParameterDocument> Parameters {get;set;}
    public List<TaskAttributeDocument> Attributes {get;set;}


    public WorkUnitDocument(Guid id,string title, Guid taskTemplateId, TaskType type, List<TaskParameterDocument> parameters,List<TaskAttributeDocument> attributes)
    {
        Id = id;
        Title = title;
        TaskTemplateId = taskTemplateId;
        Type = type;
        Parameters = parameters;
        Attributes = attributes;        
    }

    public static WorkUnitDocument CreateFrom(WorkUnit task)
    {
        var parameters = task.Parameters.Select(param=> TaskParameterDocument.CreateFrom(param)).ToList();
        var attributes = task.Attributes.Select(attribute=> TaskAttributeDocument.CreateFrom(attribute)).ToList();
        return new WorkUnitDocument(
                        task.Id,
                        task.Title,
                        task.TaskTemplateId,
                        task.Type,
                        parameters,
                        attributes);
    }
    public WorkUnit ToWorkUnit()
    {
        var parameters = Parameters.Select(param=> param.ToTaskParameter()).ToList();
        var attributes = Attributes.Select(attrDoc=>attrDoc.ToTaskAttribute()).ToList();
        return WorkUnit.Load(Id,Type,Title,TaskTemplateId,parameters,attributes);    
    }

    internal void UpdateAttributes(List<FieldValueDocument> fieldValues)
    {
        Attributes = fieldValues.Select(fieldVlue=> new TaskAttributeDocument(fieldVlue.Name,fieldVlue.Value)).ToList();
        
    }
}