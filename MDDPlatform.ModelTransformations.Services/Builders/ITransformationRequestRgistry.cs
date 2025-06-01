using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Services.Builders;
public interface ITransformationRequestRegistry
{
    ModelTransformationRequest? GetRequestTemplate(string patternName);
}