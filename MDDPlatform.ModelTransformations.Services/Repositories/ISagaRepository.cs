using MDDPlatform.ModelTransformations.Services.Saga;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface ISagaRepository
{
    Task CreateAsync(BaseSaga saga);
    Task UpdateAsync(BaseSaga saga);
    Task DeleteAsync(Guid id);
    Task<BaseSaga?> GetAsync(Guid sagaId);
    Task ClearAsync();
    Task RemoveAllAsync(Guid coordinationId);
}