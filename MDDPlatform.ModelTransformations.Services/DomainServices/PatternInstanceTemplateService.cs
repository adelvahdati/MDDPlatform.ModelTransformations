using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.DomainServices;
public class PatternInstanceTemplateService : IPatternInstanceTemplateService
{
    private readonly IPatternInstanceTemplateRepository _patternInstanceTemplateRepositpry;
    private readonly IPatternInstanceRepository _patternInstanceRepository;
    private readonly IPatternRepository _patternRepository;

    public PatternInstanceTemplateService(IPatternInstanceTemplateRepository patternInstanceTemplateRepositpry, IPatternInstanceRepository patternInstanceRepository, IPatternRepository patternRepository)
    {
        _patternInstanceTemplateRepositpry = patternInstanceTemplateRepositpry;
        _patternInstanceRepository = patternInstanceRepository;
        _patternRepository = patternRepository;
    }

    public async Task CreatePatternInstanceTemplateAsync(Guid instanceId, string? title, string? name)
    {
        var patternInstance = await _patternInstanceRepository.GetInstanceAsync(instanceId);
        if(Equals(patternInstance,null))
            throw new Exception("Pattern Instance Not Found");
        
        var pattern = await _patternRepository.GetPatternAsync(patternInstance.Template.PatternId);
        if(Equals(pattern,null))
            throw new Exception("Pattern Not Found");
        
        var template = PatternInstanceTemplate.CreateFrom(pattern,patternInstance,title,name);
        await _patternInstanceTemplateRepositpry.CreateTemplateAsync(template);
    }

    public async Task<PatternInstanceTemplate?> GetPatternInstanceTemplateAsync(Guid patternInstanceTemplateId)
    {
        var patternInstanceTemplate = await _patternInstanceTemplateRepositpry.GetTemplateAsync(patternInstanceTemplateId);
        return patternInstanceTemplate;
    }

    public async Task<List<PatternInstanceTemplate>> GetPatternSpecificTemplateAsync(Guid PatternId)
    {
        var templates = await _patternInstanceTemplateRepositpry.GetPatternSpecificTemplatesAsync(PatternId);
        return templates;
    }

    public async Task<List<PatternInstanceTemplate>> ListPatternInstanceTemplatesAsync()
    {
        var templates = await _patternInstanceTemplateRepositpry.ListPatternInstanceTemplatesAsync();
        return templates;
    }
}
