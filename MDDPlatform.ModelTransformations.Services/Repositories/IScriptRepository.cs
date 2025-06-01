using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IScriptRepository
{
    Task CreateScriptAsync(Script script);
    Task UpdateScriptAsync(Script script);
    Task DeleteScriptAsync(Guid scriptId);
    Task<Script?> GetScriptAsync(Guid scriptId);
    Task<List<Script>> ListScriptsAsync();
    Task<List<Script>?> ListScriptsAsync(Guid domainModelId);
}