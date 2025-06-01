using MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.RestClients;

namespace MDDPlatform.ModelTransformations.Infrastructure.ExternalServices;
public class DomainModelWriter : IDomainModelWriter
{
    private IRestClient _restclient;

    public DomainModelWriter(HttpClient httpClient)
    {
        _restclient = new RestClient(httpClient);        
    }


    public async Task TryCreateOrUpdateInstanceAsync(CreateOrUpdateInstanceRequest request)
    {
        var url = "DomainModel/DomainObject/CreateOrUpdateProperties";
        await _restclient.PostAsync(url,request);

    }


    public async Task TryCreateOrUpdateInstancesAsync(CreateOrUpdateInstancesRequest request)
    {
        var url = "DomainModel/DomainObject/CreateOrUpdateInstances";
        await _restclient.PostAsync(url,request);

    }


    public async Task TrySetRelationTargetInstancesAsync(SetRelationTargetInstanceRequest request)
    {
        var url = "DomainModel/DomainObject/SetRelationTargetInstances";
        await _restclient.PostAsync(url,request);

    }
}