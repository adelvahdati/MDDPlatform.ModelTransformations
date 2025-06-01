using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IPatternService
{
    Task CreatePatternAsync(string name,string category, string? description, List<Field> fields);
    Task DeletePatternAsync(Guid patternId);
    Task<Pattern?> GetPatternAsync(Guid patternId);
    Task<List<Pattern>> ListPatternsAsync();
}