using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IPatternRepository
{
    Task CreatePatternAsync(Pattern pattern);
    Task ReplacePatternAsync(Pattern pattern);
    Task DeletePatternAsync(Guid patternId);
    Task<Pattern?> GetPatternAsync(Guid id);
    Task<List<Pattern>> GetPatternsAsync();
}