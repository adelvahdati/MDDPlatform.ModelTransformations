using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Services.Builders;
public interface ITransformationRequestBuilder
{
    ModelTransformationRequest BuildRequest(string patternName, List<FieldValue> fieldValues);
    ModelTransformationRequest BuildRequest(string patternName,List<FieldValue> fieldValues,Guid coordinationId,Guid stepId);

}