using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class PatternRepository : IPatternRepository
{
    private IMongoRepository<PatternDocumnet,Guid> _repository;

    public PatternRepository(IMongoRepository<PatternDocumnet, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreatePatternAsync(Pattern pattern)
    {
        await _repository.AddAsync(PatternDocumnet.CreateFrom(pattern));
    }

    public async Task DeletePatternAsync(Guid patternId)
    {
        await _repository.DeleteAsync(patternId);
    }

    public async Task<Pattern?> GetPatternAsync(Guid id)
    {
        PatternDocumnet patternDocumnet = await _repository.GetAsync(id);
        if(Equals(patternDocumnet,null))
            return null;
        return patternDocumnet.ToPattern();
    }

    public async Task<List<Pattern>> GetPatternsAsync()
    {
        var patternDocs = await _repository.ListAsync();
        var patterns = patternDocs.Select(patternDoc=> patternDoc.ToPattern()).ToList();
        return patterns;
    }
    public async Task ReplacePatternAsync(Pattern pattern)
    {
        await _repository.InsertOrReplaceAsync(PatternDocumnet.CreateFrom(pattern));
    }
}
