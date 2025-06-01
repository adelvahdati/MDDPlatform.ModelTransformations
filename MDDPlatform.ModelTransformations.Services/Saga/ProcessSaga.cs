namespace MDDPlatform.ModelTransformations.Services.Saga;
public class ProcessSaga : BaseSaga
{
    private ProcessSaga(Guid coordinationId, Guid stepId,SagaStatus status) 
        : base(coordinationId, stepId, SagaType.Process,status)
    {
    }

    private ProcessSaga(Guid id, Guid coordinationId, Guid stepId,SagaStatus status) 
        : base(id, coordinationId, stepId,SagaType.Process,status)
    {
    }

    public static ProcessSaga Create(Guid executableProcessId , Guid taskId)
    {
        return new ProcessSaga(executableProcessId,taskId,SagaStatus.Pending);
    }
    public static ProcessSaga Load(Guid id,Guid executableProcessId, Guid taskId,SagaStatus status){
        return new ProcessSaga(id,executableProcessId,taskId,status);
    }
}