using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetScriptsQuery : IQuery<List<ScriptDto>>
{

}
public class GetScriptsQueryHandler : IQueryHandler<GetScriptsQuery, List<ScriptDto>>
{
    private readonly IScriptRepository _scriptRepository;

    public GetScriptsQueryHandler(IScriptRepository scriptRepository)
    {
        _scriptRepository = scriptRepository;
    }

    public List<ScriptDto> Handle(GetScriptsQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ScriptDto>> HandleAsync(GetScriptsQuery query)
    {
        var scripts = await _scriptRepository.ListScriptsAsync();
        if(Equals(scripts,null))
            return new();
        
        return scripts.Select(sc=>ScriptDto.CreateFrom(sc)).ToList();        
    }
}