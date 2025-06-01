using MDDPlatform.ModelTransformations.Application.DTO.External;

namespace MDDPlatform.ModelTransformations.Application.Services.External;
public interface IDomainService
{
    Task<List<ModelDto>?> GetProblemDomainModelsAsync(Guid problemDomainId);
}