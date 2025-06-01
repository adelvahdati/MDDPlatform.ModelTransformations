using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Repositories;
public interface IProcessConfigurationRepository{
    Task CreateAsync(ProcessConfiguration configuration);
    Task<ProcessConfiguration> GetAsync(Guid processConfigurationId);
    Task<List<ProcessConfiguration>> ListAsync(Guid processId);
    Task<List<ProcessConfiguration>> ListAsync();
    Task UpdateAsync(ProcessConfiguration processConfiguration);
}
