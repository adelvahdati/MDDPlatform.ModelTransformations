using System.Text.Json;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Patterns.Common;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class MapOneToTwo : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("9f808c58-4558-4396-b8c5-88343c61e09b");

    public Guid InputModel { get; set;}
    public string Source {get;set;}

    public string FirstDestination {get;set;}
    public string SecondDestination {get;set;}
    public string FirstToSecondRelationName {get;set;}


    public string FirstDestinationInstanceNameExpression {get;set;}
    public string FirstDestinationMappingExpression {get;set;}

    public string SecondDestinationInstanceNameExpression {get;set;}
    public string SecondDestinationMappingExpression {get;set;}


    public Guid OutputModel { get; set;}

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(MapOneToTwo.PatternId,nameof(MapOneToTwo),"Object2Object","Map One Type to two types with properties");
        return builder.AddField(nameof(InputModel),"Input Model :", FieldType.InputModel)
                .AddField(nameof(Source),"Source : ",FieldType.InputType)
                .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                .AddField(nameof(FirstDestination),"First Destination :",FieldType.OutputType)
                .AddField(nameof(SecondDestination),"Second Destination :",FieldType.OutputType)
                .AddField(nameof(FirstToSecondRelationName),"First-to-Second Relation Name :",FieldType.OutputTypeRelation)
                .AddField(nameof(FirstDestinationInstanceNameExpression),"First Destination Instance Name Expression", FieldType.InputTypeExpression)
                .AddField(nameof(FirstDestinationMappingExpression),"First Destination Mapping Expressions :",FieldType.OutputTypePropertyValue)
                .AddField(nameof(SecondDestinationInstanceNameExpression),"Second Destination Instance Name Expression", FieldType.InputTypeExpression)
                .AddField(nameof(SecondDestinationMappingExpression),"Second Destination Mapping Expressions :",FieldType.OutputTypePropertyValue)
                .Build();
    }
}

public class MapOneToTwoHandler : ICommandHandler<MapOneToTwo>
{
    private readonly IDomainModelService _domainModelService;

    public MapOneToTwoHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MapOneToTwo command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MapOneToTwo command)
    {
        var jsonFirstDestinationValueExpression = command.FirstDestinationMappingExpression;
        List<MemberValueExpression>? firstDestinationValueExpression;

        var jsonSecondDestinationValueExpression = command.SecondDestinationMappingExpression;
        List<MemberValueExpression>? secondDestinationValueExpression;

        try
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.PropertyNameCaseInsensitive = true;

            firstDestinationValueExpression = JsonSerializer.Deserialize<List<MemberValueExpression>>(jsonFirstDestinationValueExpression,serializerOptions);
            if(firstDestinationValueExpression == null)
                firstDestinationValueExpression = new();

            secondDestinationValueExpression = JsonSerializer.Deserialize<List<MemberValueExpression>>(jsonSecondDestinationValueExpression,serializerOptions);
            if(secondDestinationValueExpression == null)
                secondDestinationValueExpression = new();

            var request = new MapOneToTwoRequest(
                                command.InputModel,
                                command.Source,
                                command.FirstDestination,
                                command.FirstDestinationInstanceNameExpression,
                                command.SecondDestination,
                                command.SecondDestinationInstanceNameExpression,
                                command.FirstToSecondRelationName,
                                firstDestinationValueExpression,
                                secondDestinationValueExpression,
                                command.OutputModel,
                                command.CoordinationId,                                
                                command.StepId);
                                
            await _domainModelService.MapOneToTwoAsync(request);;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"MapOneToOneWithProperties Exception : {ex.Message}");
        }
    }
}
