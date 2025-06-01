using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IProcessRepository
{
    Task CreateProcessAsync(Process process);
    Task DeleteProcessAsync(Guid processId);
    Task<Process> GetProcessAsync(Guid processId);
    Task<List<Process>> ListProcessesAsync();
    Task ReplaceProcessAsync(Process process);
    Task UpdateProcessAsync(Process process);    
}