using MDDPlatform.ModelTransformations.Core.Enums;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IProcessNotificationService
{
    Task TaskIsExecutingAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status);
    Task TaskIsDoneAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status);
    Task TaskIsFailedAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status);

}