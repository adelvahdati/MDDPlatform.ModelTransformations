using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class ProcessRepository : IProcessRepository
{
    private IMongoRepository<ProcessDocument,Guid> _repository;
    public ProcessRepository(IMongoRepository<ProcessDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreateProcessAsync(Process process)
    {
        await _repository.AddAsync(ProcessDocument.CreateFrom(process));
    }

    public async Task DeleteProcessAsync(Guid processId)
    {
        await _repository.DeleteAsync(processId);
    }

    public async Task<Process> GetProcessAsync(Guid processId)
    {
        var processDocument = await _repository.GetAsync(processId);
        return processDocument.ToProcess();
    }

    public async Task<List<Process>> ListProcessesAsync()
    {
        var processes = await _repository.ListAsync();
        return processes.Select(processDoc=>processDoc.ToProcess()).ToList();
    }

    public async Task ReplaceProcessAsync(Process process)
    {
        await _repository.InsertOrReplaceAsync(ProcessDocument.CreateFrom(process));
    }

    public async Task UpdateProcessAsync(Process process)
    {
        var processDoc = ProcessDocument.CreateFrom(process);
        await _repository.UpdateAsync(processDoc);
    }
}