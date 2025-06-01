using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreatePatternInstanceTemplate : ICommand
{
    public Guid PatternInstanceId {get;set;}    
    public string? TemplateName {get;set;}
    public string? TemplateTitle {get;set;}

    public CreatePatternInstanceTemplate(Guid patternInstanceId, string? templateName, string? templateTitle)
    {
        PatternInstanceId = patternInstanceId;
        TemplateName = templateName;
        TemplateTitle = templateTitle;
    }
}
public class CreatePatternInstanceComponentHandler : ICommandHandler<CreatePatternInstanceTemplate>
{
    private readonly IPatternInstanceTemplateRepository _patternInstancecomponentRepositpry;
    private readonly IPatternInstanceRepository _patternInstanceRepository;
    private readonly IPatternRepository _patternRepository;

    public CreatePatternInstanceComponentHandler(IPatternInstanceTemplateRepository patternInstancecomponentRepositpry, IPatternInstanceRepository patternInstanceRepository, IPatternRepository patternRepository)
    {
        _patternInstancecomponentRepositpry = patternInstancecomponentRepositpry;
        _patternInstanceRepository = patternInstanceRepository;
        _patternRepository = patternRepository;
    }

    public void Handle(CreatePatternInstanceTemplate command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreatePatternInstanceTemplate command)
    {
        var patternInstance = await _patternInstanceRepository.GetInstanceAsync(command.PatternInstanceId);
        if(Equals(patternInstance,null))
            throw new Exception("Pattern Instance Not Found");
        
        var pattern = await _patternRepository.GetPatternAsync(patternInstance.Template.PatternId);
        if(Equals(pattern,null))
            throw new Exception("Pattern Not Found");
        
        var template = PatternInstanceTemplate.CreateFrom(pattern,patternInstance,command.TemplateTitle,command.TemplateName);
        await _patternInstancecomponentRepositpry.CreateTemplateAsync(template);
    }
}
