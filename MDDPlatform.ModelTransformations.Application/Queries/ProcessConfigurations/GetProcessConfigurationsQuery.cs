using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetProcessConfigurationsQuery : IQuery<List<ProcessConfigurationDto>>
{
    public Guid ProcessId {get;set;}

    public GetProcessConfigurationsQuery(Guid processId)
    {
        ProcessId = processId;
    }
}
public class GetProcessConfigurationsQueryHandler : IQueryHandler<GetProcessConfigurationsQuery, List<ProcessConfigurationDto>>
{
    private readonly IProcessConfigurationRepository _configurationRepository;

    public GetProcessConfigurationsQueryHandler(IProcessConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public List<ProcessConfigurationDto> Handle(GetProcessConfigurationsQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProcessConfigurationDto>> HandleAsync(GetProcessConfigurationsQuery query)
    {
        List<ProcessConfiguration> configurations = await _configurationRepository.ListAsync(query.ProcessId);
        return configurations.Select(config=>ProcessConfigurationDto.CreateFrom(config)).ToList();        
    }
}
