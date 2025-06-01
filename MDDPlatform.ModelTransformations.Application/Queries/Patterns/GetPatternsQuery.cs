using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetPatternsQuery : IQuery<List<PatternDto>>
{

}
public class GetPatternsQueryHandler : IQueryHandler<GetPatternsQuery, List<PatternDto>>
{
    private readonly IPatternRepository _patternRepository;

    public GetPatternsQueryHandler(IPatternRepository patternRepository)
    {
        _patternRepository = patternRepository;
    }

    public List<PatternDto> Handle(GetPatternsQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PatternDto>> HandleAsync(GetPatternsQuery query)
    {
        var patterns = await _patternRepository.GetPatternsAsync();
        return patterns.Select(pattern=>PatternDto.CreateFrom(pattern)).ToList();
    }
}
