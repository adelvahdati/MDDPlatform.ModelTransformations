using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class ExecutableProcessRepository : IExecutableProcessRepository
{
    private IMongoRepository<ExecutableProcessDocument,Guid> _repository;

    public ExecutableProcessRepository(IMongoRepository<ExecutableProcessDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(ExecutableProcess executableProcess)
    {
        await _repository.AddAsync(ExecutableProcessDocument.CreateFrom(executableProcess));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<ExecutableProcess?> GetAsync(Guid id)
    {
        var execProcessDoc = await _repository.GetAsync(id);
        return execProcessDoc?.ToExecutableProcess();
    }

    public async Task UpdateAsync(ExecutableProcess executableProcess)
    {
        await _repository.UpdateAsync(ExecutableProcessDocument.CreateFrom(executableProcess));
    }
}