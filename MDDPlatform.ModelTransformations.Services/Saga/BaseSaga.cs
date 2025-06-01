using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Services.Saga;
public abstract class BaseSaga : BaseEntity<Guid>
{
    public Guid CoordinationId {get; protected set;}
    public Guid StepId {get;protected set;}
    public SagaType Type {get;protected set;}
    public SagaStatus Status {get; protected set;}

    public Guid ExternalCoordinationId => Id;
    public Guid ExternalStepId => StepId;

    protected BaseSaga(Guid coordinationId, Guid stepId, SagaType type,SagaStatus status)
    {
        Id = Guid.NewGuid();
        CoordinationId = coordinationId;
        StepId = stepId;
        Type = type;
        Status = status;
    }
    protected BaseSaga(Guid id,Guid coordinationId, Guid stepId, SagaType type,SagaStatus status)
    {
        Id = id;
        CoordinationId = coordinationId;
        StepId = stepId;
        Type = type;
        Status =status ;
    }
    public void Done(){
        if(Status != SagaStatus.Pending)
            throw new Exception("Saga is not in the pending state");

        Status = SagaStatus.Done;
    }
    public void Failed(){
        if(Status != SagaStatus.Pending)
            throw new Exception("Saga is not in the pending state");

        Status = SagaStatus.Failed;
    }
}

public enum SagaType
{
    Process,
    Pipeline
}
public enum SagaStatus
{
    Pending,
    Done,
    Failed
}