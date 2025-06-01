using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Application.Queries;
using MDDPlatform.ModelTransformations.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PipelineController : ControllerBase
{
    private readonly IMessageDispatcher _messageDispatcher;

    public PipelineController(IMessageDispatcher messageDispatcher)
    {
        _messageDispatcher = messageDispatcher;
    }
    [HttpPost]
    public async Task CreatePipeline([FromBody] CreatePipeline command )
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Update")]
    public async Task UpdatePipeline([FromBody]UpdatePipeline command){
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpDelete("{pipelineId}")]
    public async Task DeletePipeline([FromRoute] Guid pipelineId)
    {
        var command = new DeletePipeline(pipelineId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{pipelineId}/Execute")]
    public async Task ExecutePipeline([FromRoute] Guid pipelineId )
    {
        ExecutePipeline command = new ExecutePipeline(pipelineId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{pipelineId}/Reset")]
    public async Task ResetPipeline([FromRoute] Guid pipelineId )
    {
        ResetPipeline command = new ResetPipeline(pipelineId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{pipelineId}/ManualStage/Add")]
    public async Task AddManualStage (AddManualStage command){
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{pipelineId}/AutomatedStage/Add")]
    public async Task AddAutomatedStage (AddAutomatedStage command){
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{pipelineId}/ManualStage/Run")]
    public async Task RunManualStage (RunManualStage command){
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpGet]
    public async Task<List<PipelineDto>> GetPipelines()
    {
        var query = new GetPipelinesQuery();
        return await _messageDispatcher.HandleAsync<List<PipelineDto>>(query);
    }
    [HttpGet("{pipelineId}")]
    public async Task<PipelineDto?> GetPipeline(Guid pipelineId)
    {
        var query = new GetPipelineQuery(pipelineId);
        return await _messageDispatcher.HandleAsync<PipelineDto?>(query);
    }
    [HttpGet("ProblemDomain/{problemDomainId}")]
    public async Task<List<PipelineDto>> GetProblemDomainPipelines(Guid problemDomainId)
    {
        var query = new GetProblemDomainPipelinesQuery(problemDomainId);
        return await _messageDispatcher.HandleAsync<List<PipelineDto>>(query);
    }
}