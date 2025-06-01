using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetPatternInstancesQuery : IQuery<List<PatternInstanceDto>>
{
    public Guid PatternId {get;set;}
    public GetPatternInstancesQuery(Guid patternId)
    {
        PatternId = patternId;
    }
}
public class GetPatternInstancesQueryHandler : IQueryHandler<GetPatternInstancesQuery, List<PatternInstanceDto>>
{
    private readonly IPatternInstanceRepository _patternInstanceRepository;

    public GetPatternInstancesQueryHandler(IPatternInstanceRepository patternInstanceRepository)
    {
        _patternInstanceRepository = patternInstanceRepository;
    }

    public List<PatternInstanceDto> Handle(GetPatternInstancesQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PatternInstanceDto>> HandleAsync(GetPatternInstancesQuery query)
    {
        var patternInstances = await _patternInstanceRepository.GetPatternInstancesAsync(query.PatternId);

        return patternInstances.Select(instance=> PatternInstanceDto.CreateFrom(instance)).ToList();
    }
}
