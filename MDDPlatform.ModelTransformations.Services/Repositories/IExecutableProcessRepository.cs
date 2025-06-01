using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IExecutableProcessRepository
{
    Task CreateAsync(ExecutableProcess executableProcess);
    Task UpdateAsync(ExecutableProcess executableProcess);
    Task<ExecutableProcess?> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}