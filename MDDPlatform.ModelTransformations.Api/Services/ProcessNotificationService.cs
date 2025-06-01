using MDDPlatform.ModelTransformations.Api.Hubs;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace MDDPlatform.ModelTransformations.Api.Services;
public class ProcessNotificationService : IProcessNotificationService
{
    private IHubContext<ProcessHub> _processHub;

    public ProcessNotificationService(IHubContext<ProcessHub> processHub)
    {
        _processHub = processHub;
    }

    public async Task TaskIsDoneAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status)
    {
        await _processHub.Clients.All.SendAsync("TaskIsDone", executableProcessId, taskInstanceId,status);
    }

    public async Task TaskIsExecutingAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status)
    {
        await _processHub.Clients.All.SendAsync("TaskIsExecuting", executableProcessId, taskInstanceId,status);
    }

    public async Task TaskIsFailedAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status)
    {
        await _processHub.Clients.All.SendAsync("TaskIsFailed", executableProcessId, taskInstanceId,status);
    }
}
