using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Services.Builders;
public class TransformationRequestBuilder : ITransformationRequestBuilder
{
    private readonly ITransformationRequestRegistry _requestRegistry;

    public TransformationRequestBuilder(ITransformationRequestRegistry requestRegistry)
    {
        _requestRegistry = requestRegistry;
    }

    public ModelTransformationRequest BuildRequest(string patternName, List<FieldValue> fieldValues)
    {
        var transformationRequest = _requestRegistry.GetRequestTemplate(patternName);
        if(Equals(transformationRequest,null))
            throw new Exception($"Transformation Request for {patternName} is not registered");
        
        return transformationRequest.Build(fieldValues);
    }

    public ModelTransformationRequest BuildRequest(string patternName, List<FieldValue> fieldValues, Guid coordinationId, Guid stepId)
    {
        var transformationRequest = _requestRegistry.GetRequestTemplate(patternName);
        if(Equals(transformationRequest,null))
            throw new Exception($"Transformation Request for {patternName} is not registered");
        
        return transformationRequest.Build(fieldValues,coordinationId,stepId);
    }
}
