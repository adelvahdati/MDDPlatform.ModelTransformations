using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.ModelTransformations.Services.Saga;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class SagaRepository : ISagaRepository
{
    private IMongoRepository<SagaDocument,Guid> _repository;

    public SagaRepository(IMongoRepository<SagaDocument, Guid> repository)
    {
        this._repository = repository;
    }

    public async Task ClearAsync()
    {
        var Ids = _repository.GetQueryableCollection().ToList().Select(saga=>saga.Id).ToList();
        if(!Equals(Ids,null))
            await _repository.DeleteAsync(Ids);
    }

    public async Task CreateAsync(BaseSaga saga)
    {
        await _repository.AddAsync(SagaDocument.CreateFrom(saga));        
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);        
    }

    public async Task<BaseSaga?> GetAsync(Guid sagaId)
    {
        var sagaDoc = await _repository.GetAsync(sagaId);
        if(Equals(sagaDoc,null))
            return null;
        return sagaDoc.ToBaseSaga();
    }

    public async Task RemoveAllAsync(Guid coordinationId)
    {
        var sagas = await _repository.ListAsync(saga=>saga.CoordinationId == coordinationId);
        if(!Equals(sagas,null))
        {
            var Ids = sagas.Select(saga=>saga.Id).ToList();
            if(!Equals(Ids,null))
                await _repository.DeleteAsync(Ids);
        }

    }

    public async Task UpdateAsync(BaseSaga saga)
    {
        await _repository.UpdateAsync(SagaDocument.CreateFrom(saga)); 
    }
}
