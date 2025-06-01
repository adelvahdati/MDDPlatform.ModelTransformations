using MDDPlatform.ModelTransformations.Core.Enums;
using Microsoft.AspNetCore.SignalR;

namespace MDDPlatform.ModelTransformations.Api.Hubs;
public class ProcessHub : Hub
{
    public async Task TaskIsExecutingAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status)
    {
        await Clients.All.SendAsync("TaskIsExecuting", executableProcessId, taskInstanceId,status);
    }
    public async Task TaskIsDoneAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status)
    {
        await Clients.All.SendAsync("TaskIsDone", executableProcessId, taskInstanceId,status);
    }
    public async Task TaskIsFailedAsync(Guid executableProcessId, Guid taskInstanceId, ProcessExecutionStatus status)
    {
        await Clients.All.SendAsync("TaskIsFailed", executableProcessId, taskInstanceId,status);
    }

}