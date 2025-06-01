using System.Text.Json;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Patterns.Common;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class MapOneToOneWithProperties : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("cf698987-17db-4cff-b4f1-9c405e881a92");
    public Guid InputModel { get; set;}
    public string Source {get;set;}
    public Guid OutputModel { get; set;}
    public string Destination {get;set;}
    public string MappingExpressions {get;set;}

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("cf698987-17db-4cff-b4f1-9c405e881a92"),nameof(MapOneToOneWithProperties),"Object2Object","Map Two Types (Projection)");
        return builder.AddField(nameof(InputModel),"Input Model :", FieldType.InputModel)
                .AddField(nameof(Source),"Source : ",FieldType.InputType)
                .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                .AddField(nameof(Destination),"Destination :",FieldType.OutputType)
                .AddField(nameof(MappingExpressions),"Mapping Expressions :",FieldType.OutputTypePropertyValue)
                .Build();
    }
}
public class MapOneToOneWithPropertiesHandler : ICommandHandler<MapOneToOneWithProperties>
{
    private readonly IDomainModelService _domainModelService;

    public MapOneToOneWithPropertiesHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MapOneToOneWithProperties command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MapOneToOneWithProperties command)
    {
        var jsonValueExpression = command.MappingExpressions;
        List<MemberValueExpression>? valueExpressions;
        try
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.PropertyNameCaseInsensitive = true;
            valueExpressions = JsonSerializer.Deserialize<List<MemberValueExpression>>(jsonValueExpression,serializerOptions);
            if(valueExpressions == null)
                valueExpressions = new();

            await _domainModelService.MapOneToOneWithPropertiesAsync(command.InputModel,command.Source,command.OutputModel,command.Destination,valueExpressions,command.CoordinationId,command.StepId);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"MapOneToOneWithProperties Exception : {ex.Message}");
        }
    }
}
