using MDDPlatform.ModelTransformations.Services.Saga;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class SagaDocument : BaseEntity<Guid>
{
    public Guid CoordinationId {get;  set;}
    public Guid StepId {get; set;}
    public SagaType Type {get; set;}
    public SagaStatus Status {get;  set;}

    public SagaDocument(Guid id,Guid coordinationId, Guid stepId, SagaType type, SagaStatus status)
    {
        Id = id;
        CoordinationId = coordinationId;
        StepId = stepId;
        Type = type;
        Status = status;
    }

    public static SagaDocument CreateFrom(BaseSaga saga){
        return new SagaDocument(saga.Id,saga.CoordinationId,saga.StepId,saga.Type,saga.Status);
    }

    public BaseSaga ToBaseSaga(){
        if(Type == SagaType.Pipeline)
            return PipelineSaga.Load(Id,CoordinationId,StepId,Status);
        else if(Type == SagaType.Process)
            return ProcessSaga.Load(Id,CoordinationId,StepId,Status);
        else
            throw new Exception("Invalid Saga type");
    }
}