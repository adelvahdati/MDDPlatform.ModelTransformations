using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IProcessExecutor
{
    Task ExecuteProcessAsync(ExecutableProcess executableProcess);
}