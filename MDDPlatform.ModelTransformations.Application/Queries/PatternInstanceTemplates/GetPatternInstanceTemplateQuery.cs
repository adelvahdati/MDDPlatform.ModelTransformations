using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetPatternInstanceTemplateQuery : IQuery<PatternInstanceTemplateDto?>
{
    public Guid PatternInstanceTemplateId {get;set;}

    public GetPatternInstanceTemplateQuery(Guid patternInstanceTemplateId)
    {
        PatternInstanceTemplateId = patternInstanceTemplateId;
    }
}
public class GetPatternInstanceTemplateQueryHandler : IQueryHandler<GetPatternInstanceTemplateQuery, PatternInstanceTemplateDto?>
{
    private readonly IPatternInstanceTemplateRepository _repository;

    public GetPatternInstanceTemplateQueryHandler(IPatternInstanceTemplateRepository repository)
    {
        _repository = repository;
    }

    public PatternInstanceTemplateDto? Handle(GetPatternInstanceTemplateQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<PatternInstanceTemplateDto?> HandleAsync(GetPatternInstanceTemplateQuery query)
    {
        var patternInstanceTemplate = await _repository.GetTemplateAsync(query.PatternInstanceTemplateId);
        if(Equals(patternInstanceTemplate,null))
            return null;
        
        return PatternInstanceTemplateDto.CreateFrom(patternInstanceTemplate);
    }
}
