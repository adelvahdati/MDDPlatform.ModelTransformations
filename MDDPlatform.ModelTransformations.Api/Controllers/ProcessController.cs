using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Application.Queries;
using MDDPlatform.ModelTransformations.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ProcessController : ControllerBase
{
    private readonly IMessageDispatcher _messageDispatcher;
    public ProcessController(IMessageDispatcher messageDispatcher)
    {
        _messageDispatcher = messageDispatcher;        
    }
    [HttpGet]
    public async Task<List<ProcessDto>> ListProcesses()
    {
        var query = new ListProcessQuery();
        return await _messageDispatcher.HandleAsync<List<ProcessDto>>(query);
    }
    [HttpGet("{processId}")]
    public async Task<ProcessDto?> GetProcess(Guid processId)
    {
        var query = new GetProcessQuery(processId);
        return await _messageDispatcher.HandleAsync<ProcessDto?>(query);
    }
    [HttpGet("{processId}/Phases")]
    public async Task<List<PhaseDto>?> GetPhases(Guid processId)
    {
        var query = new GetPhasesQuery(processId);
        return await _messageDispatcher.HandleAsync<List<PhaseDto>?>(query);
    }
    [HttpGet("{processId}/Phase/{phaseId}")]
    public async Task<List<ActivityDto>?> GetActivities(Guid processId,Guid phaseId)
    {
        var query = new GetActivitiesQuery(processId,phaseId);
        return await _messageDispatcher.HandleAsync<List<ActivityDto>?>(query);
    }
    [HttpGet("{processId}/Phase/{phaseId}/Activity/{activityId}")]
    public async Task<List<TaskDto>?> GetTasks(Guid processId,Guid phaseId,Guid activityId)
    {
        var query = new GetTasksQuery(processId,phaseId,activityId);
        return await _messageDispatcher.HandleAsync<List<TaskDto>?>(query);
    }

    [HttpPost]
    public async Task CreateProcess([FromBody]CreateProcess command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Phase")]
    public async Task CreatePhase([FromBody]CreatePhase command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Phase/Activity")]
    public async Task CreateActivity([FromBody]CreateActivity command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Phase/Activity/Pipeline")]
    public async Task CreateActivityFromPipeline([FromBody] CreateActivityFromPipeline command){
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Phase/Activity/ManualTask")]
    public async Task CreateManualTask([FromBody]CreateManualTask command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Phase/Activity/PatternInstanceExecutionTask")]
    public async Task CreateTaskFromPatternInstanceTemplate([FromBody]CreateTaskFromPatternInstanceTemplate command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Phase/Activity/Task")]
    public async Task CreateTasks([FromBody] CreateTasks command)
    {
        await _messageDispatcher.HandleAsync(command);
    }

    [HttpDelete("{processId}")]
    public async Task DeleteProcess(Guid processId)
    {
        var command = new DeleteProcess(processId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpDelete("{processId}/Phase/{phaseId}")]
    public async Task DeletePhase(Guid processId,Guid phaseId)
    {
        var command = new DeletePhase(processId,phaseId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpDelete("{processId}/Phase/{phaseId}/Activity/{activityId}")]
    public async Task DeleteActivity(Guid processId,Guid phaseId,Guid activityId)
    {
        var command = new DeleteActivity(processId,phaseId,activityId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpDelete("{processId}/Phase/{phaseId}/Activity/{activityId}/Task/{taskId}")]
    public async Task DeleteTask(Guid processId,Guid phaseId,Guid activityId,Guid taskId)
    {
        var command = new DeleteTask(processId,phaseId,activityId,taskId);
        await _messageDispatcher.HandleAsync(command);
    }

}