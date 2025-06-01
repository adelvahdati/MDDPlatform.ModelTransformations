using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetPatternQuery : IQuery<PatternDto?>
{
    public Guid PatternId {get;set;}

    public GetPatternQuery(Guid patternId)
    {
        PatternId = patternId;
    }
}
public class GetPatternQueryHandler : IQueryHandler<GetPatternQuery, PatternDto?>
{
    private readonly IPatternRepository _patternRepository;

    public GetPatternQueryHandler(IPatternRepository patternRepository)
    {
        _patternRepository = patternRepository;
    }

    public PatternDto? Handle(GetPatternQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<PatternDto?> HandleAsync(GetPatternQuery query)
    {
        var pattern = await _patternRepository.GetPatternAsync(query.PatternId);
        if(Equals(pattern, null))
            return null;
        
        return PatternDto.CreateFrom(pattern);
    }
}
