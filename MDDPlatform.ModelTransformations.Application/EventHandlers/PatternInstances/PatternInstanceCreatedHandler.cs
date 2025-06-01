using MDDPlatform.Messages.Events;
using MDDPlatform.ModelTransformations.Application.ReadModels;
using MDDPlatform.ModelTransformations.Application.ReadModels.Repositories;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Events;
using MDDPlatform.ModelTransformations.Services.Interfaces;

namespace MDDPlatform.ModelTransformations.Application.EventHandlers;
public class PatternInstanceCreatedHandler : IEventHandler<PatternInstanceCreated>
{
    private readonly IDomainService _domainService;
    private readonly IPatternService _patternService;
    private readonly IPatternInstanceService _patternInstanceService;
    private readonly IPatternInstanceInfoRepository _patternInstanceInfoRepository;

    public PatternInstanceCreatedHandler(IDomainService domainService, IPatternService patternService, IPatternInstanceService patternInstanceService, IPatternInstanceInfoRepository patternInstanceInfoRepository)
    {
        _domainService = domainService;
        _patternService = patternService;
        _patternInstanceService = patternInstanceService;
        _patternInstanceInfoRepository = patternInstanceInfoRepository;
    }

    public void Handle(PatternInstanceCreated @event)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(PatternInstanceCreated @event)
    {
        var pattern = await _patternService.GetPatternAsync(@event.PatternId);
        if(Equals(pattern,null))
            return;

        var patternInstance = await _patternInstanceService.GetInstanceAsync(@event.PatternInstanceId);
        if(Equals(patternInstance,null))
            return;

        var models = await _domainService.GetProblemDomainModelsAsync(@event.ProblemDomainId);
        if(Equals(models,null))
            return;
        
        var inputModels = models.Where(model=>@event.InputModelIds.Contains(model.Id)).Select(model=>ModelInfo.CreateFrom(model)).ToList();
        var outputModels = models.Where(model=>@event.OutputModelIds.Contains(model.Id)).Select(model=>ModelInfo.CreateFrom(model)).ToList();

        var patternInstanceInfo = new PatternInstanceInfo(@event.ProblemDomainId,@event.PatternId,@event.PatternInstanceId,pattern.Name,pattern.Category,patternInstance.Title,inputModels,outputModels);
        await _patternInstanceInfoRepository.CreatePatternInstanceInfoAsync(patternInstanceInfo);
    }
}
