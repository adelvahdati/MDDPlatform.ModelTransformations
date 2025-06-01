using MDDPlatform.ModelTransformations.Application.DTO.External.DomainModels;
using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.RestClients;

namespace MDDPlatform.ModelTransformations.Infrastructure.ExternalServices;
public class DomainModelReader : IDomainModelReader
{
    private IRestClient _restclient;

    public DomainModelReader(HttpClient httpClient)
    {
        _restclient = new RestClient(httpClient);        
    }

    public async Task<DomainModelElementsDto?> GetDomainModelElementsAsync(Guid domainModelId)
    {
        string url = string.Format("DomainModel/{0}/Elements",domainModelId);
        return await _restclient.GetAsync<DomainModelElementsDto?>(url);

    }

    public async Task<List<DomainObjectDto>?> GetDomainObjectsAsync(Guid domainModelId, string objectType)
    {
        var url=string.Format("DomainModel/{0}/DomainObjetcs/{1}",domainModelId,objectType);
        return await _restclient.GetAsync<List<DomainObjectDto>?>(url);
    }
}
