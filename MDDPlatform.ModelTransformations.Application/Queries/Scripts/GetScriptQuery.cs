using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetScriptQuery : IQuery<ScriptDto?>
{
    public Guid ScriptId {get;set;}

    public GetScriptQuery(Guid scriptId)
    {
        ScriptId = scriptId;
    }
}
public class GetScriptQueryHandler : IQueryHandler<GetScriptQuery, ScriptDto?>
{
    private readonly IScriptRepository _scriptRepository;

    public GetScriptQueryHandler(IScriptRepository scriptRepository)
    {
        _scriptRepository = scriptRepository;
    }

    public ScriptDto Handle(GetScriptQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<ScriptDto?> HandleAsync(GetScriptQuery query)
    {
        var script = await _scriptRepository.GetScriptAsync(query.ScriptId);
        if(Equals(script,null))
            return null;
        
        return ScriptDto.CreateFrom(script);        
    }
}
