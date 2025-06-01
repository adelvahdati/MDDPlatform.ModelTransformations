using MDDPlatform.ModelTransformations.Api.CodeGenerators;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace MDDPlatform.ModelTransformations.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CodeGeneratorController : ControllerBase 
{
    private readonly ICodeGenerator _codeGenerator;
    private readonly ITemplateFileManager _templateManager;

    public CodeGeneratorController(ICodeGenerator codeGenerator, ITemplateFileManager templateManager)
    {
        _codeGenerator = codeGenerator;
        _templateManager = templateManager;
    }

    [HttpPost("archive")]
    public async Task Acrhive(ArchiveProjectCodeRequest request)
    {
        await _codeGenerator.CreateProjectAsync(
                                request.DomainModelId,
                                request.FileConcept,
                                request.FileNameProperty,
                                request.FileContentProperty,
                                request.FileExtensionProperty,
                                request.RelativePathProperty);
    }
    [HttpGet("download/{domainModelId}")]
    public ActionResult Download(Guid domainModelId){
        var archiveDirectory = _codeGenerator.GetArchiveDirectory();
        var filePath = Path.GetFullPath(archiveDirectory);        
        var fileName = _codeGenerator.GetProjectZipFileName(domainModelId);
        IFileProvider provider = new PhysicalFileProvider(filePath);
        IFileInfo fileInfo = provider.GetFileInfo(fileName);
        if(fileInfo.Exists){
            var readStream = fileInfo.CreateReadStream();
            return File(readStream, "application/zip", fileName);
        }

        return NoContent();        
    }

    [HttpGet("template")]
    public async Task<string> GetTemplate()
    {
        return await _templateManager.GetFileContentAsync("EmptyProject","EmptyProject.csproj");
    }   
}
