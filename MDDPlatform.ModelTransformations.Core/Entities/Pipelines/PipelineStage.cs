using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;

public interface IPipelineStage
{
    Guid Id {get;}
    string Title { get; }
    Guid TaskId { get; }
    StageType Type { get; }
    StageStatus Status { get; }
    long SequenceNumber {get;}
}

public class PipelineStage : BaseEntity<Guid>, IPipelineStage
{
    public string Title { get; private set; }
    public Guid TaskId { get; private set; }
    public StageType Type { get; private set; }
    public StageStatus Status { get; private set; }
    public long SequenceNumber {get; private set;}

    private PipelineStage(string title, Guid taskId, StageType type, StageStatus status, long sequenceNumber)
    {
        Id = Guid.NewGuid();
        Title = title;
        TaskId = taskId;
        Type = type;
        Status = status;
        SequenceNumber = sequenceNumber;
    }
    private PipelineStage(string title, Guid taskId, StageType type)
    {
        Id = Guid.NewGuid();
        Title = title;
        TaskId = taskId;
        Type = type;
        Status = StageStatus.Ready;
        SequenceNumber = DateTime.UtcNow.Ticks;
    }
    private PipelineStage(Guid id, string title, Guid taskId, StageType type, StageStatus status, long sequenceNumber)
    {
        Id = id;
        Title = title;
        TaskId = taskId;
        Type = type;
        Status = status;
        SequenceNumber = sequenceNumber;
    }
    public static PipelineStage CreateStage(string title,StageType type,Guid taskId =default(Guid))
    {
        Guid tId = Guid.NewGuid();
        if(taskId != default(Guid))
            tId = taskId;

        return new PipelineStage(title,tId,type);
    }
    public static PipelineStage CreateManualStage(string title,Guid taskId =default(Guid))
    {
        Guid tId = Guid.NewGuid();
        if(taskId != default(Guid))
            tId = taskId;

        return new PipelineStage(title,tId,StageType.Manual);        
    }
    public static PipelineStage CreateAutomaticStage(string title, Guid taskId)
    {
        return new PipelineStage(title,taskId,StageType.Automatic);                
    }
    public static PipelineStage LoadStage(Guid id, string title, Guid taskId, StageType type, StageStatus status, long sequenceNumber)
    {
        return new(id,title,taskId,type,status,sequenceNumber);        
    }
    public void Start()
    {
        if(Type == StageType.Automatic && Status!=StageStatus.Ready)
            throw new Exception("Stage is executed previousely");
        
        Status = StageStatus.Start;
    }
    public void End()
    {
        if(Type == StageType.Automatic && Status == StageStatus.Ready)
            throw new Exception("Stage is not executed yet");

        if(Type == StageType.Automatic && Status == StageStatus.Failed)
            throw new Exception("Stage is failed. If you want to run it again, you should reset the stage before running again");

        Status = StageStatus.Done;
    }
    public void Reject()
    {
        if(Type == StageType.Automatic && Status == StageStatus.Ready)
            throw new Exception("Stage is not executed yet");

        if(Type == StageType.Automatic && Status == StageStatus.Done)
            throw new Exception("Stage is done. you can't change the status");

        Status = StageStatus.Failed;
    }
    public void Reset()
    {
        Status = StageStatus.Ready;
    }
}