using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetDomainModelScriptsQuery : IQuery<List<ScriptDto>>
{
    public Guid DomainModelId { get; set; }

    public GetDomainModelScriptsQuery(Guid domainModelId)
    {
        DomainModelId = domainModelId;
    }
}
public class GetDomainModelScriptsQueryHandler : IQueryHandler<GetDomainModelScriptsQuery, List<ScriptDto>>
{
    private readonly IScriptRepository _scriptRepository;

    public GetDomainModelScriptsQueryHandler(IScriptRepository scriptRepository)
    {
        _scriptRepository = scriptRepository;
    }

    public List<ScriptDto> Handle(GetDomainModelScriptsQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ScriptDto>> HandleAsync(GetDomainModelScriptsQuery query)
    {
        var scripts = await _scriptRepository.ListScriptsAsync(query.DomainModelId);

        if(Equals(scripts,null))
            return new();
        
        return scripts.Select(sc=>ScriptDto.CreateFrom(sc)).ToList();        
    }
}
