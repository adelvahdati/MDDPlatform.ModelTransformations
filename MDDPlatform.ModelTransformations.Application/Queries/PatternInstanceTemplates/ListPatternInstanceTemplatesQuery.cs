using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class ListPatternInstanceTemplatesQuery : IQuery<List<PatternInstanceTemplateDto>>{

}
public class ListPatternInstanceTemplatesQueryHandler : IQueryHandler<ListPatternInstanceTemplatesQuery, List<PatternInstanceTemplateDto>>
{
    private readonly IPatternInstanceTemplateRepository _repository;

    public ListPatternInstanceTemplatesQueryHandler(IPatternInstanceTemplateRepository repository)
    {
        _repository = repository;
    }

    public List<PatternInstanceTemplateDto> Handle(ListPatternInstanceTemplatesQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PatternInstanceTemplateDto>> HandleAsync(ListPatternInstanceTemplatesQuery query)
    {
        var templates = await _repository.ListPatternInstanceTemplatesAsync();
        return templates.Select(temp=>PatternInstanceTemplateDto.CreateFrom(temp)).ToList();        

    }
}
