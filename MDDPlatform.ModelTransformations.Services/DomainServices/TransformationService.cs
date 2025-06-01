using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Builders;
using MDDPlatform.ModelTransformations.Services.Commands;
using MDDPlatform.ModelTransformations.Services.Interfaces;

namespace MDDPlatform.ModelTransformations.Services.DomainServices;
public class TransformationService : ITransformationService
{
    private readonly ITransformationRequestBuilder _requestBuilder;
    private IMessageDispatcher _messageDispatcher;
    private IPatternInstanceService _patternInstanceService;

    public TransformationService(ITransformationRequestBuilder requestBuilder, IMessageDispatcher messageDispatcher, IPatternInstanceService patternInstanceService)
    {
        _requestBuilder = requestBuilder;
        _messageDispatcher = messageDispatcher;
        _patternInstanceService = patternInstanceService;
    }

    public async Task ExecutePatternInstanceAsync(string patternName, List<FieldValue> fieldValues)
    {
        ModelTransformationRequest request = _requestBuilder.BuildRequest(patternName,fieldValues);
        await _messageDispatcher.HandleAsync(request);
    }

    public async Task ExecutePatternInstanceAsync(string patternName, List<FieldValue> fieldValues, Guid coordinationId, Guid stepId)
    {
        ModelTransformationRequest request = _requestBuilder.BuildRequest(patternName,fieldValues,coordinationId,stepId);
        await _messageDispatcher.HandleAsync(request);
    }

    public async Task ExecutePatternInstanceAsync(Guid instanceId)
    {
        var patternInstance = await _patternInstanceService.GetInstanceAsync(instanceId);
        if(Equals(patternInstance,null))
            throw new Exception("Transformation Service Exception : Pattern instance not found");
        
        var patternName = patternInstance.Template.PatternName;
        var fieldValues = patternInstance.FieldValues.ToList();

        ModelTransformationRequest request = _requestBuilder.BuildRequest(patternName,fieldValues);
        await _messageDispatcher.HandleAsync(request);
    }
}
