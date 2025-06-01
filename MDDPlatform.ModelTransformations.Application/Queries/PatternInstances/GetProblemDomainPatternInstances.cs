using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;

public class GetProblemDomainPatternInstances : IQuery<List<PatternInstanceDto>>
{
    public Guid ProblemDomainId {get;set;}

    public GetProblemDomainPatternInstances(Guid problemDomainId)
    {
        this.ProblemDomainId = problemDomainId;
    }
}
public class GetProblemDomainPatternInstancesHandler : IQueryHandler<GetProblemDomainPatternInstances, List<PatternInstanceDto>>
{
    private readonly IPatternInstanceRepository _patternInstanceRepository;

    public GetProblemDomainPatternInstancesHandler(IPatternInstanceRepository patternInstanceRepository)
    {
        _patternInstanceRepository = patternInstanceRepository;
    }

    public List<PatternInstanceDto> Handle(GetProblemDomainPatternInstances query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PatternInstanceDto>> HandleAsync(GetProblemDomainPatternInstances query)
    {
        var patternInstances = await _patternInstanceRepository.GetProblemDomainPatternInstancesAsync(query.ProblemDomainId);
        return patternInstances.Select(instance=> PatternInstanceDto.CreateFrom(instance)).ToList();
    }
}
