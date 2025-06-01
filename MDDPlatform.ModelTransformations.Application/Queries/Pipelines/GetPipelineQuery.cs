using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

public class GetPipelineQuery : IQuery<PipelineDto?>
{
    public Guid PipelineId {get;set;}

    public GetPipelineQuery(Guid pipelineId)
    {
        PipelineId = pipelineId;
    }
}
public class GetPipelineQueryHandler : IQueryHandler<GetPipelineQuery, PipelineDto?>
{
    private readonly IPipelineRepository _pipelineRepository;

    public GetPipelineQueryHandler(IPipelineRepository pipelineRepository)
    {
        _pipelineRepository = pipelineRepository;
    }

    public PipelineDto? Handle(GetPipelineQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<PipelineDto?> HandleAsync(GetPipelineQuery query)
    {
        var pipeline =  await _pipelineRepository.GetPipelineAsync(query.PipelineId);
        if(Equals(pipeline, null))
            return null;
        
        return PipelineDto.CreateFrom(pipeline);
        
    }
}
