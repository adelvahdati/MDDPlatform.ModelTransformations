using MDDPlatform.ModelTransformations.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransformationController : ControllerBase
{
    private readonly ITransformationService _transformationService;

    public TransformationController(ITransformationService transformationService)
    {
        _transformationService = transformationService;
    }

    [HttpPost("PatternInstances/{instanceId}")]
    public async Task ExecutePatternInstance([FromRoute] Guid instanceId){
        await _transformationService.ExecutePatternInstanceAsync(instanceId);
    }
}