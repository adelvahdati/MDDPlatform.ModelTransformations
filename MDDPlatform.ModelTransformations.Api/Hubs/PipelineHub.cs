using MDDPlatform.ModelTransformations.Core.Enums;
using Microsoft.AspNetCore.SignalR;

namespace MDDPlatform.ModelTransformations.Api.Hubs;


public class PipelineHub : Hub
{
    public async Task NotifyPipelineStageStarted(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus)
    {
        await Clients.All.SendAsync("PipelineStageStarted", pipelineId, stageId,pipelineStatus);
    }
    public async Task NotifyPipelineStageIsDone(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus)
    {
        await Clients.All.SendAsync("PipelineStageIsDone", pipelineId, stageId,pipelineStatus);
    }
    public async Task NotifyPipelineStageFailed(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus)
    {
        await Clients.All.SendAsync("PipelineStageFailed", pipelineId, stageId,pipelineStatus);
    }
}