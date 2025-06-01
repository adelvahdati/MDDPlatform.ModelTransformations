using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreatePattern : ICommand
{
    public string Name {get; set;}
    public string Category {get;set;}
    public string? Description {get; set;}
    public List<Field> Fields {get;  set;}

    public CreatePattern(string name,string category, string? description, List<Field> fields)
    {
        Name = name;
        Category = category;
        Description = description;
        Fields = fields;
    }
}
public class CreatePatternHandler : ICommandHandler<CreatePattern>
{
    private readonly IPatternRepository _patternRepository;

    public CreatePatternHandler(IPatternRepository patternRepository)
    {
        _patternRepository = patternRepository;
    }

    public void Handle(CreatePattern command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreatePattern command)
    {
        Pattern patten = Pattern.Create(command.Name,command.Category,command.Description,command.Fields);
        await _patternRepository.CreatePatternAsync(patten);
    }
}
