using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
public class MapObjectPropertyToConceptAttribute : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("5ea5bee6-b888-4159-a790-11ac991a2df0");
    public Guid InputModel {get;set;}
    public string TypeOfInstance {get;set;}
    public Guid  OutputModel {get;set;}

    public MapObjectPropertyToConceptAttribute(Guid inputModel, string typeOfInstance, Guid outputModel)
    {
        this.InputModel = inputModel;
        this.TypeOfInstance = typeOfInstance;
        this.OutputModel = outputModel;
    }
    public MapObjectPropertyToConceptAttribute(){
        InputModel = Guid.Empty;
        TypeOfInstance = string.Empty;
        OutputModel = Guid.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(MapObjectPropertyToConceptAttribute.PatternId,nameof(MapObjectPropertyToConceptAttribute),"Object2Concept","Map DomainObject Properties to DomainConcept Attributes");
        return builder.AddField(nameof(InputModel),"Input model",FieldType.InputModel)
                .AddField(nameof(TypeOfInstance),"Type of instance",FieldType.InputType)
                .AddField(nameof(OutputModel),"Output model",FieldType.OutputModel)
                .Build();
    }
}

public class MapObjectPropertyToConceptAttributeHandler : ICommandHandler<MapObjectPropertyToConceptAttribute>
{
    private readonly IDomainModelService _domainModelService;

    public MapObjectPropertyToConceptAttributeHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MapObjectPropertyToConceptAttribute command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MapObjectPropertyToConceptAttribute command)
    {
        await _domainModelService.MapObjectPropertyToConceptAttributeAsync(command);
    }
}
