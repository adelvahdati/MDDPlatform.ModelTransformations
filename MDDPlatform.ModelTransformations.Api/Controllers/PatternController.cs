using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Application.Queries;
using MDDPlatform.ModelTransformations.Application.ReadModels;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatternController : ControllerBase
{
    private readonly IPatternService _patternService;
    private readonly IPatternInstanceService _patternInstanceService;
    private readonly IMessageDispatcher _messageDispatcher;
    public PatternController(IPatternService patternService, IPatternInstanceService patternInstanceService, IMessageDispatcher messageDispatcher)
    {
        _patternService = patternService;
        _patternInstanceService = patternInstanceService;
        _messageDispatcher = messageDispatcher;
    }

    [HttpPost]
    public async Task CreatePattern(NewPatternDto pattern)
    {
        var fields = pattern.Fields.Select(fieldDto=> new Field(fieldDto.Name,fieldDto.Label,fieldDto.Type)).ToList();
        await _patternService.CreatePatternAsync(pattern.Name,pattern.Category,pattern.Description,fields);
    }
    [HttpDelete("{patternId}")]
    public async Task DeletePattern(Guid patternId){
        await _patternService.DeletePatternAsync(patternId);
    }


    [HttpPost("Instance")]
    public async Task CreateInstance(NewPatternInstanceDto instance)
    {
        var fieldValues = instance.FieldValues.Select(fieldValueDto=> new FieldValue(fieldValueDto.Name,fieldValueDto.Value)).ToList();
        await _patternInstanceService.CreateInstanceAsync(instance.PatternId,instance.Title,instance.Name,fieldValues,instance.ProblemDomainId);
    }
    [HttpDelete("Instance/{instanceId}")]
    public async Task DeleteInstance(Guid instanceId){
        await _patternInstanceService.DeleteInstanceAsync(instanceId);
    }

    [HttpGet("{patternId}")]
    public async Task<PatternDto?> GetPattern([FromRoute] Guid patternId){
        var pattern =  await _patternService.GetPatternAsync(patternId);
        if(Equals(pattern,null))
            return null;

        return PatternDto.CreateFrom(pattern);
    }
    [HttpGet]
    public async Task<List<PatternDto>> ListPatterns()
    {
        var patterns =  await _patternService.ListPatternsAsync();
        return patterns.Select(pattern=> PatternDto.CreateFrom(pattern)).ToList();
    }    
    [HttpGet("Instance/{instanceId}")]
    public async Task<PatternInstanceDto?> GetInstance([FromRoute] Guid instanceId){
        var patternInstance = await _patternInstanceService.GetInstanceAsync(instanceId);
        if(Equals(patternInstance,null))
            return null;
        return PatternInstanceDto.CreateFrom(patternInstance);
    }
    [HttpGet("{patternId}/Instances")]
    public async Task<List<PatternInstanceDto>> ListPatternInstances([FromRoute] Guid patternId){
        var patternInstances =  await _patternInstanceService.ListPatternInstancesAsync(patternId);
        return patternInstances.Select(instance=> PatternInstanceDto.CreateFrom(instance)).ToList();        
    }
    [HttpGet("ProblemDomain/{problemDomainId}/PatternInstances")]
    public async Task<List<PatternInstanceDto>> GetProblemDomainPatternInstances(Guid problemDomainId)
    {
        var patternInstances = await _patternInstanceService.ListProblemDomainPatternInstancesAsync(problemDomainId);
        return patternInstances.Select(instance=> PatternInstanceDto.CreateFrom(instance)).ToList();        
    }
    [HttpPost("FindPatternInstances")]
    public async Task<List<PatternInstanceInfo>> FindPatternInstances(FindPatternInstanceQuery query){
        return await _messageDispatcher.HandleAsync<List<PatternInstanceInfo>>(query);
    }

}