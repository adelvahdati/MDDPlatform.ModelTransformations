
using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;

public class ListProcessConfigurationsQuery : IQuery<List<ProcessConfigurationDto>>{

}
public class ListProcessConfigurationsQueryHandler : IQueryHandler<ListProcessConfigurationsQuery, List<ProcessConfigurationDto>>
{
    private readonly IProcessConfigurationRepository _configurationRepository;

    public ListProcessConfigurationsQueryHandler(IProcessConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public List<ProcessConfigurationDto> Handle(ListProcessConfigurationsQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProcessConfigurationDto>> HandleAsync(ListProcessConfigurationsQuery query)
    {
        var processConfigurations =  await _configurationRepository.ListAsync();
        return processConfigurations.Select(processConfig=> ProcessConfigurationDto.CreateFrom(processConfig)).ToList();        
    }
}
