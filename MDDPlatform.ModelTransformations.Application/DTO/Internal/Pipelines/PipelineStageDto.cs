using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;

namespace  MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class PipelineStageDto
{
    public Guid Id {get;set;}
    public string Title { get;  set; }
    public Guid TaskId { get;  set; }
    public StageType Type { get; set; }
    public StageStatus Status { get;  set; }
    public long SequenceNumber {get; set;}

    public PipelineStageDto(Guid id,string title, Guid taskId, StageType type, StageStatus status, long sequenceNumber)
    {
        Id = id;
        Title = title;
        TaskId = taskId;
        Type = type;
        Status = status;
        SequenceNumber = sequenceNumber;
    }
    public static PipelineStageDto CreateFrom(IPipelineStage stage)
    {
        return new PipelineStageDto(stage.Id,stage.Title,stage.TaskId,stage.Type,stage.Status,stage.SequenceNumber);
    }
}
