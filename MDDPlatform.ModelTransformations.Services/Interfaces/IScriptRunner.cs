using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Services.Interfaces;
public interface IScriptRunner
{
    Task RunScriptAsync(Guid domainModelId, List<IInstruction> instructions);
}