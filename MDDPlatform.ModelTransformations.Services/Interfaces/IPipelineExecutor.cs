using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IPipelineExecutor
{
    Task ExecutePipelineAsync(Pipeline pipeline);    
}