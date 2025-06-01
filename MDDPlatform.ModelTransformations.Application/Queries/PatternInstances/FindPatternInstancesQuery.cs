using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Common;
using MDDPlatform.ModelTransformations.Application.ReadModels;
using MDDPlatform.ModelTransformations.Application.ReadModels.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class FindPatternInstanceQuery : IQuery<List<PatternInstanceInfo>>
{
    public FilterDto<Guid> FilterByProblemDomain { get; set; }
    public FilterDto<Guid> FilterByInputMetaModel { get; set; }
    public FilterDto<Guid> FilterByOutputMetamodel { get; set; }
    public FilterDto<string> FilterByInputModelType { get; set; }
    public FilterDto<string> FilterByOutputModelType { get; set; }

    public FindPatternInstanceQuery(FilterDto<Guid> filterByProblemDomain, FilterDto<Guid> filterByInputMetaModel, FilterDto<Guid> filterByOutputMetamodel, FilterDto<string> filterByInputModelType, FilterDto<string> filterByOutputModelType)
    {
        FilterByProblemDomain = filterByProblemDomain;
        FilterByInputMetaModel = filterByInputMetaModel;
        FilterByOutputMetamodel = filterByOutputMetamodel;
        FilterByInputModelType = filterByInputModelType;
        FilterByOutputModelType = filterByOutputModelType;
    }
}
public class FindPatternInstanceQueryHandler : IQueryHandler<FindPatternInstanceQuery, List<PatternInstanceInfo>>
{
    private readonly IPatternInstanceInfoRepository _patternInstanceInfoRepository;

    public FindPatternInstanceQueryHandler(IPatternInstanceInfoRepository patternInstanceInfoRepository)
    {
        _patternInstanceInfoRepository = patternInstanceInfoRepository;
    }

    public List<PatternInstanceInfo> Handle(FindPatternInstanceQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PatternInstanceInfo>> HandleAsync(FindPatternInstanceQuery query)
    {
        return await _patternInstanceInfoRepository.FindPatternInstancesAsync(query);
    }
}
