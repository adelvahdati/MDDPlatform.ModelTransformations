using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IPatternInstanceRepository
{
    Task CreateInstanceAsync(PatternInstance instance);
    Task<PatternInstance?> GetInstanceAsync(Guid instanceId);
    Task<List<PatternInstance>> GetInstancesAsync();
    Task<List<PatternInstance>> GetPatternInstancesAsync(Guid paternId);
    Task<List<PatternInstance>> GetProblemDomainPatternInstancesAsync(Guid problemDomainId);
    Task DeleteInstanceAsync(Guid instanceId);
}