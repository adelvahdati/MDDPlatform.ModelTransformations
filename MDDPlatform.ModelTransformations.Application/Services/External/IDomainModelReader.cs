using MDDPlatform.ModelTransformations.Application.DTO.External.DomainModels;
using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;

namespace MDDPlatform.ModelTransformations.Application.Services.External;
public interface IDomainModelReader
{
    Task<DomainModelElementsDto?> GetDomainModelElementsAsync(Guid domainModelId);
    Task<List<DomainObjectDto>?> GetDomainObjectsAsync(Guid domainModelId, string objectType);
}