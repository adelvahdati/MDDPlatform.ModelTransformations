using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class ProcessConfigurationRepository : IProcessConfigurationRepository
{
    private IMongoRepository<ProcessConfigurationDocument,Guid> _repository;

    public ProcessConfigurationRepository(IMongoRepository<ProcessConfigurationDocument, Guid> repository)
    {
        this._repository = repository;
    }

    public async Task CreateAsync(ProcessConfiguration configuration)
    {
        await _repository.AddAsync(ProcessConfigurationDocument.CreateFrom(configuration));
    }

    public async Task<ProcessConfiguration> GetAsync(Guid processConfigurationId)
    {
        var processConfigDoc = await _repository.GetAsync(processConfigurationId);
        return processConfigDoc.ToProcessConfiguration();
    }

    public async Task<List<ProcessConfiguration>> ListAsync()
    {
        var processConfigDocs = await _repository.ListAsync();
        return processConfigDocs.Select(processConfigDoc=>processConfigDoc.ToProcessConfiguration()).ToList();
    }

    public async Task<List<ProcessConfiguration>> ListAsync(Guid processId)
    {
        var processConfigDocs = await _repository.ListAsync(processConfigDoc=> processConfigDoc.ProcessId == processId);
        return processConfigDocs.Select(processConfigDoc=>processConfigDoc.ToProcessConfiguration()).ToList();
    }

    public async Task UpdateAsync(ProcessConfiguration processConfiguration)
    {
        await _repository.UpdateAsync(ProcessConfigurationDocument.CreateFrom(processConfiguration));        
    }
}