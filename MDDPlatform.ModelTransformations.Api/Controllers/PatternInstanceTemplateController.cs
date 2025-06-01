
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Commands;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PatternInstanceTemplateController : ControllerBase
{
    private readonly IPatternInstanceTemplateService _templateService;

    public PatternInstanceTemplateController(IPatternInstanceTemplateService templateService)
    {
        _templateService = templateService;
    }

    [HttpPost]
    public async Task CreatePatternInstanceTemplate(CreatePatternInstanceTemplate command){
        await _templateService.CreatePatternInstanceTemplateAsync(command.PatternInstanceId,command.TemplateTitle,command.TemplateName);
    }

    [HttpGet("{patternInstanceTemplateId}")]
    public async Task<PatternInstanceTemplateDto?> GetPatternInstanceTemplate(Guid patternInstanceTemplateId)
    {        
        var template =  await _templateService.GetPatternInstanceTemplateAsync(patternInstanceTemplateId)    ;
        if(Equals(template,null))
            return null;
        
        return PatternInstanceTemplateDto.CreateFrom(template);
    }
    [HttpGet]
    public async Task<List<PatternInstanceTemplateDto>> ListPatternInstances()
    {
        var templates =  await _templateService.ListPatternInstanceTemplatesAsync();
        return templates.Select(template=>PatternInstanceTemplateDto.CreateFrom(template)).ToList();
    }
    [HttpGet("Pattern/{patternId}")]
    public async Task<List<PatternInstanceTemplateDto>> GetPatternSpecificTemplate(Guid patternId){
        var templates =  await _templateService.GetPatternSpecificTemplateAsync(patternId);
        return templates.Select(template=>PatternInstanceTemplateDto.CreateFrom(template)).ToList();
    }
}