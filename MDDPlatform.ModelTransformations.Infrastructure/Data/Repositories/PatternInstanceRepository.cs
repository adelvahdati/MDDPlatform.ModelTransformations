using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class PatternInstanceRepository : IPatternInstanceRepository
{
    private IMongoRepository<PatternInstanceDocument,Guid> _repository;

    public PatternInstanceRepository(IMongoRepository<PatternInstanceDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreateInstanceAsync(PatternInstance instance)
    {
        await _repository.AddAsync(PatternInstanceDocument.CreateFrom(instance));
    }

    public async Task DeleteInstanceAsync(Guid instanceId)
    {
        await _repository.DeleteAsync(instanceId);
    }

    public async Task<List<PatternInstance>> GetPatternInstancesAsync(Guid paternId)
    {
        var instances =  await _repository.ListAsync(patternInstance=>patternInstance.Template.PatternId == paternId);
        return instances.Select(patternInstanceDoc=>patternInstanceDoc.ToPatternInstance()).ToList();
    }

    public async Task<List<PatternInstance>> GetInstancesAsync()
    {
        var instances = await _repository.ListAsync();
        return instances.Select(patternInstanceDoc=>patternInstanceDoc.ToPatternInstance()).ToList();
    }

    public async Task<PatternInstance?> GetInstanceAsync(Guid id)
    {
        var instanceDoc = await _repository.GetAsync(id);
        if(Equals(instanceDoc,null))
            return null;
        return instanceDoc.ToPatternInstance();
    }

    public async Task<List<PatternInstance>> GetProblemDomainPatternInstancesAsync(Guid problemDomainId)
    {
        var instances = await _repository.ListAsync(patternInstanceDoc => patternInstanceDoc.ProblemDomainId == problemDomainId);
        return instances.Select(patternInstanceDoc=>patternInstanceDoc.ToPatternInstance()).ToList();
    }
}