using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetPatternSpecificTemplateQuery : IQuery<List<PatternInstanceTemplateDto>>
{
    public GetPatternSpecificTemplateQuery(Guid patternId)
    {
        PatternId = patternId;
    }

    public Guid PatternId {get;set;}
    
}
public class GetPatternSpecifcTemplateQueryHandler : IQueryHandler<GetPatternSpecificTemplateQuery, List<PatternInstanceTemplateDto>>
{
    private readonly IPatternInstanceTemplateRepository _repository;

    public GetPatternSpecifcTemplateQueryHandler(IPatternInstanceTemplateRepository repository)
    {
        _repository = repository;
    }

    public List<PatternInstanceTemplateDto> Handle(GetPatternSpecificTemplateQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PatternInstanceTemplateDto>> HandleAsync(GetPatternSpecificTemplateQuery query)
    {
        var templates = await _repository.GetPatternSpecificTemplatesAsync(query.PatternId);
        return templates.Select(temp=>PatternInstanceTemplateDto.CreateFrom(temp)).ToList();        
    }
}
