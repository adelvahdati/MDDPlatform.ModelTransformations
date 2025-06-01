using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface ITransformationService
{
    Task ExecutePatternInstanceAsync(Guid instanceId);
    Task ExecutePatternInstanceAsync(string patternName,List<FieldValue> fieldValues);
    Task ExecutePatternInstanceAsync(string patternName,List<FieldValue> fieldValues,Guid coordinationId,Guid stepId);
}