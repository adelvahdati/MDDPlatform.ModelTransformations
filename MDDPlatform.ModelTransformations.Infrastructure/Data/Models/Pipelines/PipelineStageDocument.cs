using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;

public class PipelineStageDocument
{
    public Guid Id {get;set;}
    public string Title { get;  set; }
    public Guid TaskId { get;  set; }
    public StageType Type { get;  set; }
    public StageStatus Status { get;  set; }
    public long SequenceNumber {get;  set;}

    public PipelineStageDocument(Guid id,string title, Guid taskId, StageType type, StageStatus status, long sequenceNumber)
    {
        Id = id;
        Title = title;
        TaskId = taskId;
        Type = type;
        Status = status;
        SequenceNumber = sequenceNumber;
    }

    public static PipelineStageDocument CreateFrom(PipelineStage stage)
    {
        return new PipelineStageDocument(stage.Id,stage.Title,stage.TaskId,stage.Type,stage.Status,stage.SequenceNumber);
    }
    public static PipelineStageDocument CreateFrom(IPipelineStage stage)
    {
        return new PipelineStageDocument(stage.Id,stage.Title,stage.TaskId,stage.Type,stage.Status,stage.SequenceNumber);
    }

    public PipelineStage ToPipelineStage()
    {
        return PipelineStage.LoadStage(Id,Title,TaskId,Type,Status,SequenceNumber);
    }
}