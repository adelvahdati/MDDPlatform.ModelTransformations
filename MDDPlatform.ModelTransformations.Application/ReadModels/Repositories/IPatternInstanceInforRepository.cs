using MDDPlatform.ModelTransformations.Application.Queries;

namespace MDDPlatform.ModelTransformations.Application.ReadModels.Repositories;
public interface IPatternInstanceInfoRepository
{
    Task CreatePatternInstanceInfoAsync(PatternInstanceInfo info);
    Task DeletePatternInstanceInfoAsync(Guid patternInstanceId);
    Task<List<PatternInstanceInfo>> FindPatternInstancesAsync(FindPatternInstanceQuery query);
}