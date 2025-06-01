using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetProblemDomainPipelinesQuery : IQuery<List<PipelineDto>>
{
    public Guid ProblemDomainId {get;set;}

    public GetProblemDomainPipelinesQuery(Guid problemDomainId)    
    {
        this.ProblemDomainId = problemDomainId;
    }
}
public class GetProblemDomainPipelinesQueryHandler : IQueryHandler<GetProblemDomainPipelinesQuery, List<PipelineDto>>
{
    private readonly IPipelineRepository _pipelineRepository;

    public GetProblemDomainPipelinesQueryHandler(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    public List<PipelineDto> Handle(GetProblemDomainPipelinesQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PipelineDto>> HandleAsync(GetProblemDomainPipelinesQuery query)
    {
        var pipelines = await _pipelineRepository.GetPipelinesAsync(query.ProblemDomainId);

        if(Equals(pipelines,null))
            return new();
        
        return pipelines.Select(pipeline => PipelineDto.CreateFrom(pipeline)).ToList();
    }
}
