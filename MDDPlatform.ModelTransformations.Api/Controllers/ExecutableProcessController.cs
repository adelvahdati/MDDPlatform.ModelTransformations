using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Application.Queries;
using MDDPlatform.ModelTransformations.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ExecutableProcessController : ControllerBase
{
    private readonly IMessageDispatcher _messageDispatcher;

    public ExecutableProcessController(IMessageDispatcher messageDispatcher)
    {
        _messageDispatcher = messageDispatcher;
    }

    [HttpPost]
    public async Task CreateExecutableProcess(CreateExecutableProcess command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{id}")]
    public async Task RunExectableProcess(Guid id)
    {
        ExecuteProcess command = new ExecuteProcess(id);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{id}/Reset")]
    public async Task ResetExecutableProcess(Guid id)
    {
        ResetExecutableProcess command = new ResetExecutableProcess(id);
        await _messageDispatcher.HandleAsync(command);
    }

    [HttpPost("{id}/ManualTask/{taskId}/Run")]
    public async Task RunManualTask(Guid id,Guid taskId)
    {
        var command = new RunManualTask(id,taskId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpGet("{id}")]
    public async Task<ExecutableProcessDto?> GetExecutableProcess(Guid id)
    {
        var query = new GetExecutableProcessQuery(id);
        return await _messageDispatcher.HandleAsync<ExecutableProcessDto?>(query);
    }
}
