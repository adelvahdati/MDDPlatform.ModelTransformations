using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Application.Queries;
using MDDPlatform.ModelTransformations.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ProcessConfigurationController : ControllerBase
{
    private IMessageDispatcher _messageDispatcher;

    public ProcessConfigurationController(IMessageDispatcher messageDispatcher)
    {
        _messageDispatcher = messageDispatcher;
    }

    [HttpPost]
    public async Task CreateProcessConfiguration(CreateProcessConfiguration command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Update/{processConfigurationId}")]
    public async Task UpdateProcessConfiguration(Guid processConfigurationId){
        var command = new UpdateProcessConfiguration(processConfigurationId);
        await _messageDispatcher.HandleAsync(command);
    }

    [HttpPost("Task")]
    public async Task ConfigTask(ConfigTask command){
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("MultipleTask")]
    public async Task ConfigMultipleTasks(ConfigMultipleTasks command){
        await _messageDispatcher.HandleAsync(command);
    }

    [HttpGet("{processConfigurationId}")]
    public async Task<ProcessConfigurationDto?> GetProcessConfiguration(Guid processConfigurationId)
    {
        var query = new GetProcessConfigurationQuery(processConfigurationId);
        return await _messageDispatcher.HandleAsync<ProcessConfigurationDto?>(query);
    }
    [HttpGet]
    public async Task<List<ProcessConfigurationDto>> ListProcessConfiguration()
    {
        var query = new ListProcessConfigurationsQuery();
        return await _messageDispatcher.HandleAsync<List<ProcessConfigurationDto>>(query);
    }
    [HttpGet("Process/{processId}")]
    public async Task<List<ProcessConfigurationDto>> ListProcessConfiguration(Guid processId)
    {
        var query = new GetProcessConfigurationsQuery(processId);
        return await _messageDispatcher.HandleAsync<List<ProcessConfigurationDto>>(query);
    }
}
