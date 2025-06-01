using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class PatternInstanceTemplateRepository : IPatternInstanceTemplateRepository
{
    private IMongoRepository<PatternInstanceTemplateDocument,Guid> _repository;

    public PatternInstanceTemplateRepository(IMongoRepository<PatternInstanceTemplateDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreateTemplateAsync(PatternInstanceTemplate template)
    {
        await _repository.AddAsync(PatternInstanceTemplateDocument.CreateFrom(template));
    }

    public async Task<List<PatternInstanceTemplate>> GetPatternSpecificTemplatesAsync(Guid patternId)
    {
        var templateDocs = await _repository.ListAsync(templateDoc=> templateDoc.PatternId == patternId);
        return templateDocs.Select(tempDoc=>tempDoc.ToPatternInstanceTemplate()).ToList();
    }

    public async Task<PatternInstanceTemplate?> GetSimilarTemplateAsync(PatternInstanceTemplate taskTemplate)
    {
        var templateDocs = await _repository.ListAsync(templateDoc=> templateDoc.PatternId == taskTemplate.PatternId &&
                                                                        templateDoc.PatternName == taskTemplate.PatternName &&
                                                                        templateDoc.PatternCategory == taskTemplate.PatternCategory);

        return templateDocs.Select(tempDoc=>tempDoc.ToPatternInstanceTemplate())
                            .ToList()
                            .FirstOrDefault(template=> template.IsSimilarTo(taskTemplate));
    }

    public async Task<PatternInstanceTemplate> GetTemplateAsync(Guid templateId)
    {
        var templateDocument =  await _repository.GetAsync(templateId);
        return templateDocument.ToPatternInstanceTemplate();
    }

    public async Task<List<PatternInstanceTemplate>> ListPatternInstanceTemplatesAsync()
    {
        var templateDocs = await _repository.ListAsync();
        return templateDocs.Select(tempDoc=>tempDoc.ToPatternInstanceTemplate()).ToList();
    }

    public async Task ReplacePatternInstanceTemplateAsync(PatternInstanceTemplate template)
    {
        await _repository.InsertOrReplaceAsync(PatternInstanceTemplateDocument.CreateFrom(template));
    }
}