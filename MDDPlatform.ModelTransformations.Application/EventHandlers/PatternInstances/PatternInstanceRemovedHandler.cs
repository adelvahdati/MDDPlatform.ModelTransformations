using MDDPlatform.Messages.Events;
using MDDPlatform.ModelTransformations.Application.ReadModels.Repositories;
using MDDPlatform.ModelTransformations.Core.Events;

namespace MDDPlatform.ModelTransformations.Application.EventHandlers;
public class PatternInstanceRemovedHandler : IEventHandler<PatternInstanceRemoved>
{
    private readonly IPatternInstanceInfoRepository _patternInstanceInfoRepository;

    public PatternInstanceRemovedHandler(IPatternInstanceInfoRepository patternInstanceInfoRepository)
    {
        this._patternInstanceInfoRepository = patternInstanceInfoRepository;
    }

    public void Handle(PatternInstanceRemoved @event)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(PatternInstanceRemoved @event)
    {
        await _patternInstanceInfoRepository.DeletePatternInstanceInfoAsync(@event.PatternInstanceId);
    }
}
