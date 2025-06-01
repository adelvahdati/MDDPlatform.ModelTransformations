using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Events;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeletePatternInstance : ICommand{
    public Guid InstanceId {get;}

    public DeletePatternInstance(Guid instanceId)
    {
        this.InstanceId = instanceId;
    }
}
public class DeletePatternInstanceHandler : ICommandHandler<DeletePatternInstance>
{
    private readonly IPatternInstanceRepository _patternInstance;
    private readonly IMessageBroker _messageBroker;
    private readonly IEventMapper _eventMapper;

    public DeletePatternInstanceHandler(IPatternInstanceRepository patternInstance, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        this._patternInstance = patternInstance;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(DeletePatternInstance command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeletePatternInstance command)
    {
        await _patternInstance.DeleteInstanceAsync(command.InstanceId);
        var @event = new PatternInstanceRemoved(command.InstanceId);
        await _messageBroker.PublishAsync(_eventMapper.Map(@event));
    }
}