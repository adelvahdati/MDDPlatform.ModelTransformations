using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IPatternInstanceTemplateRepository
{
    Task CreateTemplateAsync(PatternInstanceTemplate template);
    Task<PatternInstanceTemplate> GetTemplateAsync(Guid templateId);
    Task<List<PatternInstanceTemplate>> ListPatternInstanceTemplatesAsync();
    Task<List<PatternInstanceTemplate>> GetPatternSpecificTemplatesAsync(Guid patternId);
    Task<PatternInstanceTemplate?> GetSimilarTemplateAsync(PatternInstanceTemplate taskTemplate);
    Task ReplacePatternInstanceTemplateAsync(PatternInstanceTemplate template);
}