using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.DomainServices;
public class PatternService : IPatternService
{
    private readonly IPatternRepository _patternRepository;

    public PatternService(IPatternRepository patternRepository)
    {
        _patternRepository = patternRepository;
    }

    public async Task CreatePatternAsync(string name, string category, string? description, List<Field> fields)
    {
        Pattern patten = Pattern.Create(name,category,description,fields);
        await _patternRepository.CreatePatternAsync(patten);
    }

    public async Task DeletePatternAsync(Guid patternId)
    {
        await _patternRepository.DeletePatternAsync(patternId);
    }

    public async Task<Pattern?> GetPatternAsync(Guid patternId)
    {
        var pattern = await _patternRepository.GetPatternAsync(patternId);
        return pattern;
    }

    public async Task<List<Pattern>> ListPatternsAsync()
    {
        var patterns = await _patternRepository.GetPatternsAsync();
        return patterns;
    }
}