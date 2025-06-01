using System.Linq.Expressions;
using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class ScriptRepository : IScriptRepository
{
    private IMongoRepository<ScriptDocument,Guid> _repository;

    public ScriptRepository(IMongoRepository<ScriptDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreateScriptAsync(Script script)
    {
        await _repository.AddAsync(ScriptDocument.CreateFrom(script));
    }

    public async Task DeleteScriptAsync(Guid scriptId)
    {
        await _repository.DeleteAsync(scriptId);
    }

    public async Task<Script?> GetScriptAsync(Guid scriptId)
    {
        var scriptDoc = await _repository.GetAsync(scriptId);
        if(Equals(scriptDoc,null))
            return null;
        
        return scriptDoc.ToScript();
    }

    public async Task<List<Script>> ListScriptsAsync()
    {
        var scriptsDoc = await _repository.ListAsync();
        return scriptsDoc.Select(scrDoc=>scrDoc.ToScript()).ToList();
    }

    public async Task<List<Script>?> ListScriptsAsync(Guid domainModelId)
    {
        Expression<Func<ScriptDocument,bool>> predicateExpression = scriptDocument => scriptDocument.DomainModelId == domainModelId;
        var scriptsDoc = await _repository.ListAsync(predicateExpression);
        if(scriptsDoc==null)
            return null;
        return scriptsDoc.Select(scrDoc=>scrDoc.ToScript()).ToList();
    }

    public async Task UpdateScriptAsync(Script script)
    {
        await _repository.UpdateAsync(ScriptDocument.CreateFrom(script));
    }
}
