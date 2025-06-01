using MDDPlatform.ModelTransformations.Application.Patterns;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders.PatternTemplates;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders.Processes;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders;
public class DataSeeder : IDataSeeder
{
    private readonly IPatternRepository _patternRepository;
    private readonly IPatternInstanceTemplateRepository _patternInstanceTemplateRepository;
    private readonly IProcessRepository _processRepository;
    private readonly IPatternInstanceTemplateRgistry _templateRegistry;

    public DataSeeder(IPatternRepository patternRepository, IPatternInstanceTemplateRepository patternInstanceTemplateRepository, IProcessRepository processRepository, IPatternInstanceTemplateRgistry templateRegistry)
    {
        _patternRepository = patternRepository;
        _patternInstanceTemplateRepository = patternInstanceTemplateRepository;
        _processRepository = processRepository;
        _templateRegistry = templateRegistry;
    }

    public async Task SeedPatternsAsync()
    {
        List<Pattern> patterns = new List<Pattern>();
        patterns.AddPatterns();
        foreach (var pattern in patterns)
        {
            await _patternRepository.ReplacePatternAsync(pattern);
        }
    }

    public async Task SeedPatternInstanceTemplatesAsync()
    {
        // List<PatternInstanceTemplate> templates = new();
        // templates.AddPatternInstanceTemplates();

        var templates = _templateRegistry.List();
        foreach(var template in templates)
        {
            await _patternInstanceTemplateRepository.ReplacePatternInstanceTemplateAsync(template);
        }        

    }

    public async Task SeedProcessAsync()
    {
        await SeedMDDProcessAsync();
        await SeedCodeGenerationProcessAsync();
    }

    private async Task SeedMDDProcessAsync(){
        Process process = Process.Create(Guid.Parse("60d6254c-263a-480d-bc2e-ca58f929cc53"),"Model-Driven Development Process");
        process.AddInitialPhase();
        process.AddCIMConstructionPhase(_templateRegistry);
        process.AddPIMConstructionPhase(_templateRegistry);
        process.AddPSMConstructionPhase(_templateRegistry);
        process.AddCodeGenerationPhase(_templateRegistry);

        await _processRepository.ReplaceProcessAsync(process);
    }
    private async Task SeedCodeGenerationProcessAsync()
    {
        Process process = Process.Create(Guid.Parse("3f38e68d-3e85-4a16-9eed-4f82d3cdbecf"),"C# Code Generation Process");
        process.AddCSharpCodeGenerationPhase(_templateRegistry);

        await _processRepository.ReplaceProcessAsync(process);
    }
}
