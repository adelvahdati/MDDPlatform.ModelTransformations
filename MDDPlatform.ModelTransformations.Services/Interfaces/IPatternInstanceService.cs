using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IPatternInstanceService
{
    Task CreateInstanceAsync (Guid patternId, string instanceTitle, string instanceName, List<FieldValue> fieldValues,Guid problemDomainId);
    Task DeleteInstanceAsync(Guid instanceId);
    Task<PatternInstance?> GetInstanceAsync(Guid instanceId);
    Task<List<PatternInstance>> ListPatternInstancesAsync(Guid patternId);
    Task<List<PatternInstance>> ListProblemDomainPatternInstancesAsync(Guid problemDomainId);

}