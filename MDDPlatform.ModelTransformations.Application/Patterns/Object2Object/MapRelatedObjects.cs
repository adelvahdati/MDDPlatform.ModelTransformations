using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class MapRelatedObjects : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("dea546b9-8a61-40a1-bc58-c14b34eda99f");
    public Guid InputModel {get;set;}
    public string InputSource {get;set;}
    public string InputDestination {get;set;}
    public string InputSourceToDestinationRelation {get;set;}
    public Guid OutputModel {get;set;}
    public string OutputSource {get;set;}
    public string OutputDestination {get;set;}
    public string OutputSourceToDestinationRelation {get;set;}
    public string OutputSourceInstanceExpression {get;set;}
    public string OutputDestinationInstanceExpression {get;set;}

    public MapRelatedObjects(Guid inputModel, string inputSource, string inputDestination, string inputSourceToDestinationRelation, Guid outputModel, string outputSource, string outputDestination, string outputSourceToDestinationRelation, string outputSourceInstanceExpression, string outputDestinationInstanceExpression)
    {
        InputModel = inputModel;
        InputSource = inputSource;
        InputDestination = inputDestination;
        InputSourceToDestinationRelation = inputSourceToDestinationRelation;
        OutputModel = outputModel;
        OutputSource = outputSource;
        OutputDestination = outputDestination;
        OutputSourceToDestinationRelation = outputSourceToDestinationRelation;
        OutputSourceInstanceExpression = outputSourceInstanceExpression;
        OutputDestinationInstanceExpression = outputDestinationInstanceExpression;
    }
    internal MapRelatedObjects()
    {
        InputModel = Guid.Empty;
        InputSource = string.Empty;
        InputDestination = string.Empty;
        InputSourceToDestinationRelation = string.Empty;
        OutputModel = Guid.Empty;
        OutputSource = string.Empty;
        OutputDestination = string.Empty;
        OutputSourceToDestinationRelation = string.Empty;
        OutputSourceInstanceExpression = string.Empty;
        OutputDestinationInstanceExpression = string.Empty;
    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("dea546b9-8a61-40a1-bc58-c14b34eda99f"),nameof(MapRelatedObjects),"Object2Object","Map Related Objects");
        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(InputSource),"Input Source :",FieldType.InputType)
                        .AddField(nameof(InputDestination),"Input Destination :",FieldType.InputType)
                        .AddField(nameof(InputSourceToDestinationRelation),"Input Source-to-Destination Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .AddField(nameof(OutputSource),"Output Source :",FieldType.OutputType)
                        .AddField(nameof(OutputDestination),"Output Destination :",FieldType.OutputType)
                        .AddField(nameof(OutputSourceToDestinationRelation),"Output Source-to-Destination Relation", FieldType.OutputTypeRelation)
                        .AddField(nameof(OutputSourceInstanceExpression),"Output Source Instance Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OutputDestinationInstanceExpression),"Output Destination Instance Expression :",FieldType.InputTypeExpression)
                        .Build();
    }
}
public class MapRelatedObjectsHandler : ICommandHandler<MapRelatedObjects>
{
    private readonly IDomainModelService _domainModelService;

    public MapRelatedObjectsHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MapRelatedObjects command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MapRelatedObjects command)
    {
        await _domainModelService.MapRelatedObjectsAsync(command);
    }
}
