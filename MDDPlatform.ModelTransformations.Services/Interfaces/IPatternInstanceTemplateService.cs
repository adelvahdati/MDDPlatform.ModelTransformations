using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IPatternInstanceTemplateService
{
    Task CreatePatternInstanceTemplateAsync(Guid instanceId,string? title,string? name);
    Task<PatternInstanceTemplate?> GetPatternInstanceTemplateAsync(Guid patternInstanceTemplateId);
    Task<List<PatternInstanceTemplate>> GetPatternSpecificTemplateAsync(Guid PatternId);
    Task<List<PatternInstanceTemplate>> ListPatternInstanceTemplatesAsync();

}