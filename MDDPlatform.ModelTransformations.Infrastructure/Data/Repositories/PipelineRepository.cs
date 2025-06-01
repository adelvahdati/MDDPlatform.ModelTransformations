using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class PipelineRepository : IPipelineRepository
{
    private IMongoRepository<PipelineDocument,Guid> _repository;

    public PipelineRepository(IMongoRepository<PipelineDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreatePipelineAsync(Pipeline pipeline)
    {
        await _repository.AddAsync(PipelineDocument.CreateFrom(pipeline));
    }

    public async Task DeletePipelineAsync(Pipeline pipeline)
    {
        await _repository.DeleteAsync(pipeline.Id);
    }

    public async Task<Pipeline?> GetPipelineAsync(Guid pipelineId)
    {
        PipelineDocument pipelineDocument = await _repository.GetAsync(pipelineId);
        return pipelineDocument.ToPipeline();
    }

    public async Task<List<Pipeline>> GetPipelinesAsync()
    {
        var pipelines = await _repository.ListAsync();
        return pipelines.Select(piplineDoc => piplineDoc.ToPipeline()).ToList();
    }

    public async Task<List<Pipeline>> GetPipelinesAsync(Guid problemDomainId)
    {
        var pipelines = await _repository.ListAsync(pipelineDoc=>pipelineDoc.ProblemDomainId == problemDomainId);
        return pipelines.Select(piplineDoc => piplineDoc.ToPipeline()).ToList();
    }

    public async Task UpdatePipelineAsync(Pipeline pipeline)
    {
        var pipelineDoc = PipelineDocument.CreateFrom(pipeline);
        await _repository.UpdateAsync(pipelineDoc);
    }
}
