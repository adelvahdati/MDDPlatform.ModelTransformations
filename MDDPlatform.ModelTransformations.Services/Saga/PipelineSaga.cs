namespace MDDPlatform.ModelTransformations.Services.Saga;
public class PipelineSaga : BaseSaga
{
    private PipelineSaga(Guid coordinationId, Guid stepId,SagaStatus status) 
        : base(coordinationId, stepId, SagaType.Pipeline,status)
    {
    }

    private PipelineSaga(Guid id, Guid coordinationId, Guid stepId,SagaStatus status) 
        : base(id, coordinationId, stepId,SagaType.Pipeline,status)
    {
    }

    public static PipelineSaga Create(Guid pipelineId , Guid stageId)
    {
        return new PipelineSaga(pipelineId,stageId,SagaStatus.Pending);
    }
    public static PipelineSaga Load(Guid id,Guid pipelineId, Guid stageId,SagaStatus status)
    {
        return new PipelineSaga(id,pipelineId,stageId,status);
    }
}