using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetInstanceQuery : IQuery<PatternInstanceDto?>
{
    public Guid InstanceId {get;set;}

    public GetInstanceQuery(Guid instanceId)
    {
        InstanceId = instanceId;
    }
}
public class GetInstanceQueryHandler : IQueryHandler<GetInstanceQuery, PatternInstanceDto?>
{
    private readonly IPatternInstanceRepository _patternInstanceRepository;

    public GetInstanceQueryHandler(IPatternInstanceRepository patternInstanceRepository)
    {
        _patternInstanceRepository = patternInstanceRepository;
    }

    public PatternInstanceDto? Handle(GetInstanceQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<PatternInstanceDto?> HandleAsync(GetInstanceQuery query)
    {
        var patternInstance = await _patternInstanceRepository.GetInstanceAsync(query.InstanceId);
        if(Equals(patternInstance,null))
            return null;
        
        return PatternInstanceDto.CreateFrom(patternInstance);
    }
}
