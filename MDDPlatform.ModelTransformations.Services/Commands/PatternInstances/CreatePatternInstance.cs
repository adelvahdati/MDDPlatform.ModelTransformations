using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Events;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreatePatternInstance : ICommand
{
    public Guid ProblemDomainId {get;set;}
    public Guid PatternId {get;set;}
    public string InstanceTitle {get;set;}
    public string InstanceName {get;set;}
    public List<FieldValue> FieldValues {get;set;}

    public CreatePatternInstance(Guid patternId, string instanceTitle, string instanceName, List<FieldValue> fieldValues,Guid problemDomainId)
    {
        PatternId = patternId;
        InstanceTitle = instanceTitle;
        InstanceName = instanceName;
        FieldValues = fieldValues;
        ProblemDomainId = problemDomainId;
    }
}
public class CreatePatternInstanceHandler : ICommandHandler<CreatePatternInstance>
{
    private readonly IPatternRepository _patternRepository;
    private readonly IPatternInstanceRepository _patternInstanceRepository;

    private readonly IMessageBroker _messageBroker;
    private readonly IEventMapper _eventMapper;

    public CreatePatternInstanceHandler(IPatternRepository patternRepository, IPatternInstanceRepository patternInstanceRepository, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        _patternRepository = patternRepository;
        _patternInstanceRepository = patternInstanceRepository;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(CreatePatternInstance command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreatePatternInstance command)
    {
        Pattern? pattern = await _patternRepository.GetPatternAsync(command.PatternId);
        if(Equals(pattern, null))
            throw new Exception("The pattern is not valid for creating an instance");
        
        PatternInstance instance = pattern.CreateInstance(command.InstanceTitle,command.InstanceName,command.FieldValues,command.ProblemDomainId);
        await _patternInstanceRepository.CreateInstanceAsync(instance);
        
        var @event = PatternInstanceCreated.Create(pattern,instance);
        await _messageBroker.PublishAsync(_eventMapper.Map(@event));
    }
}
