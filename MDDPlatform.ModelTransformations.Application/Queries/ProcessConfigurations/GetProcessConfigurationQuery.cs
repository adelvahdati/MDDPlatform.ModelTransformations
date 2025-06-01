using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetProcessConfigurationQuery : IQuery<ProcessConfigurationDto?>
{
    public Guid ConfiguarionId {get;set;}

    public GetProcessConfigurationQuery(Guid configuarionId)
    {
        ConfiguarionId = configuarionId;
    }    
}
public class GetProcessConfigurationQueryHandler : IQueryHandler<GetProcessConfigurationQuery, ProcessConfigurationDto?>
{
    private readonly IProcessConfigurationRepository _configurationRepository;

    public GetProcessConfigurationQueryHandler(IProcessConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public ProcessConfigurationDto? Handle(GetProcessConfigurationQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<ProcessConfigurationDto?> HandleAsync(GetProcessConfigurationQuery query)
    {
        var configuration = await _configurationRepository.GetAsync(query.ConfiguarionId);
        if(Equals(configuration,null))
            return null;
        return ProcessConfigurationDto.CreateFrom(configuration);
            
    }
}
