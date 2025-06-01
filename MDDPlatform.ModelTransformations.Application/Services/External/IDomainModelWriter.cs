using MDDPlatform.ModelTransformations.Application.DTO.External.Requests;

namespace MDDPlatform.ModelTransformations.Application.Services.External;
public interface IDomainModelWriter
{
    Task TryCreateOrUpdateInstancesAsync(CreateOrUpdateInstancesRequest request);
    Task TryCreateOrUpdateInstanceAsync(CreateOrUpdateInstanceRequest request);
    Task TrySetRelationTargetInstancesAsync(SetRelationTargetInstanceRequest request);
}