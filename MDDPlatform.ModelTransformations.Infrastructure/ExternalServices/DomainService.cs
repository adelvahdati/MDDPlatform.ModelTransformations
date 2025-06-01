using MDDPlatform.ModelTransformations.Application.DTO.External;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.RestClients;

namespace MDDPlatform.ModelTransformations.Infrastructure.ExternalServices;
public class DomainService : IDomainService
{
    private IRestClient _restclient;

    public DomainService(HttpClient httpClient)
    {
        _restclient = new RestClient(httpClient);
    }

    public async Task<List<ModelDto>?> GetProblemDomainModelsAsync(Guid problemDomainId)
    {
        var url = string.Format("Domain/ProblemDomainModels/{0}",problemDomainId);
        return await _restclient.GetAsync<List<ModelDto>>(url);
    }
}
