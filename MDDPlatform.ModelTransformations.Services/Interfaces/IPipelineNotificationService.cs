using MDDPlatform.ModelTransformations.Core.Enums;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IPipelineNotificationService
{
    Task NotifyPipelineStageFailed(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus);
    Task NotifyPipelineStageIsDone(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus);
    Task NotifyPipelineStageStarted(Guid pipelineId, Guid stageId,PipelineStatus pipelineStatus);
}
