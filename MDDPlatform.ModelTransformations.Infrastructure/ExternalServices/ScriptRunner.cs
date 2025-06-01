using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.RestClients;

namespace MDDPlatform.ModelTransformations.Infrastructure.ExternalServices;
public class ScriptRunner : IScriptRunner
{
    private IRestClient _restclient;

    public ScriptRunner(HttpClient httpClient)
    {
        _restclient = new RestClient(httpClient);
    }


    public async Task RunScriptAsync(Guid domainModelId, List<IInstruction> instructions)
    {
        var Instructions = instructions.Select(ins=> Instruction.Load(ins.Code,ins.Arguments)).ToList();
        var url = "Script/Run";
        var body = new {
            DomainModelId = domainModelId,
            Instructions = Instructions,
            CoordinationId = Guid.Empty,
            StepId = Guid.Empty
        };
        await _restclient.PostAsync(url,body);
    }
}
