using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IPipelineRepository
{
    Task CreatePipelineAsync(Pipeline pipeline);
    Task<Pipeline?> GetPipelineAsync(Guid pipelineId);
    Task<List<Pipeline>> GetPipelinesAsync();
    Task<List<Pipeline>> GetPipelinesAsync(Guid problemDomainId);
    Task UpdatePipelineAsync(Pipeline pipeline);
    Task DeletePipelineAsync(Pipeline pipeline);
}