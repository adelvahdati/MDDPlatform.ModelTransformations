using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetPipelinesQuery : IQuery<List<PipelineDto>>
{

}
public class GetPipelinesQueryHandler : IQueryHandler<GetPipelinesQuery, List<PipelineDto>>
{
    private readonly IPipelineRepository _pipelineRepository;

    public GetPipelinesQueryHandler(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    public List<PipelineDto> Handle(GetPipelinesQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PipelineDto>> HandleAsync(GetPipelinesQuery query)
    {
        var piplines = await _pipelineRepository.GetPipelinesAsync();
        if(Equals(piplines,null))
            return new();
        
        return piplines.Select(pipeline => PipelineDto.CreateFrom(pipeline)).ToList();
    }
}
