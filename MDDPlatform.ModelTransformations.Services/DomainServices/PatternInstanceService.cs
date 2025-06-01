using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Commands;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.DomainServices;
public class PatternInstanceService : IPatternInstanceService
{
    private readonly IPatternRepository _patternRepository;
    private readonly IPatternInstanceRepository _patternInstanceRepository;
    private readonly IMessageDispatcher _messageDispatcher;
    public PatternInstanceService(IPatternRepository patternRepository, IPatternInstanceRepository patternInstanceRepository, IMessageDispatcher messageDispatcher)
    {
        _patternRepository = patternRepository;
        _patternInstanceRepository = patternInstanceRepository;
        _messageDispatcher = messageDispatcher;
    }

    public async Task CreateInstanceAsync(Guid patternId, string instanceTitle, string instanceName, List<FieldValue> fieldValues, Guid problemDomainId)
    {

        var command = new CreatePatternInstance(patternId, instanceTitle,instanceName, fieldValues,problemDomainId);
        await _messageDispatcher.HandleAsync(command);
    }

    public async Task DeleteInstanceAsync(Guid instanceId)
    {
        var command = new DeletePatternInstance(instanceId);
        await _messageDispatcher.HandleAsync(command);
    }

    public async Task<PatternInstance?> GetInstanceAsync(Guid instanceId)
    {
        var patternInstance = await _patternInstanceRepository.GetInstanceAsync(instanceId);
        return patternInstance;
    }

    public async Task<List<PatternInstance>> ListPatternInstancesAsync(Guid patternId)
    {
        var patternInstances = await _patternInstanceRepository.GetPatternInstancesAsync(patternId);
        return patternInstances;
    }

    public async Task<List<PatternInstance>> ListProblemDomainPatternInstancesAsync(Guid problemDomainId)
    {
        var patternInstances = await _patternInstanceRepository.GetProblemDomainPatternInstancesAsync(problemDomainId);
        return patternInstances;

    }
}
