using MDDPlatform.ModelTransformations.Api.Hubs;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace MDDPlatform.ModelTransformations.Api.Services;
public class PipelineNotificationService : IPipelineNotificationService
{
    private IHubContext<PipelineHub> _pipelineHub;

    public PipelineNotificationService(IHubContext<PipelineHub> pipelineHub)
    {
        _pipelineHub = pipelineHub;
    }

    public async Task NotifyPipelineStageFailed(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus)
    {
        await _pipelineHub.Clients.All.SendAsync("PipelineStageFailed",pipelineId,stageId,pipelineStatus) ;
    }

    public async Task NotifyPipelineStageIsDone(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus)
    {
        await _pipelineHub.Clients.All.SendAsync("PipelineStageIsDone",pipelineId,stageId,pipelineStatus) ;
    }

    public async Task NotifyPipelineStageStarted(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus)
    {        
        await _pipelineHub.Clients.All.SendAsync("PipelineStageStarted",pipelineId,stageId,pipelineStatus) ;
    }
}