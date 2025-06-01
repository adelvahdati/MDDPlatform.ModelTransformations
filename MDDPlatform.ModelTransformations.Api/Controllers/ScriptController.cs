using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Application.Queries;
using MDDPlatform.ModelTransformations.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ScriptController : ControllerBase
{
    private readonly IMessageDispatcher _messageDispatcher;

    public ScriptController(IMessageDispatcher messageDispatcher)
    {
        _messageDispatcher = messageDispatcher;
    }
    [HttpPost]
    public async Task CreateScript([FromBody] CreateScript command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Update")]
    public async Task UpdateScript([FromBody] UpdateScript command)
    {
        await _messageDispatcher.HandleAsync(command);
    }

    [HttpPost("Run/{scriptId}")]
    public async Task RunScript(Guid scriptId){
        RunScript command = new RunScript(scriptId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpDelete("{scriptId}")]
    public async Task DeleteScript(Guid scriptId)
    {
        var command = new DeleteScript(scriptId);
        await _messageDispatcher.HandleAsync(command);
    }

    [HttpGet("{scriptId}")]
    public async Task<ScriptDto?> GetScript(Guid scriptId)
    {
        var query = new GetScriptQuery(scriptId);
        return await _messageDispatcher.HandleAsync<ScriptDto?>(query);
    }
    [HttpGet]
    public async Task<List<ScriptDto>> GetScripts()
    {
        var query = new GetScriptsQuery();
        return await _messageDispatcher.HandleAsync<List<ScriptDto>>(query);
    }
    [HttpGet("List/{domainModelId}")]
    public async Task<List<ScriptDto>> ListDomainModelScripts(Guid domainModelId)
    {
        var query = new GetDomainModelScriptsQuery(domainModelId);
        return await _messageDispatcher.HandleAsync<List<ScriptDto>>(query);
    }


}