using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class MapOneToOne : ModelTransformationRequest, ITransformationPattern
{
        public static Guid PatternId => Guid.Parse("b0f02367-c1db-4d36-8c5c-9f03983440a5");
        public Guid InputModel { get; set;}
        public string Source {get;set;}
        public Guid OutputModel { get; set;}
        public string Destination {get;set;}

    public MapOneToOne(Guid inputModel, string source, Guid outputModel, string destination)
    {
        InputModel = inputModel;
        Source = source;
        OutputModel = outputModel;
        Destination = destination;
    }
    public MapOneToOne()
    {
        InputModel = Guid.Empty;
        Source = string.Empty;
        OutputModel = Guid.Empty;
        Destination = string.Empty;
    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("b0f02367-c1db-4d36-8c5c-9f03983440a5"),nameof(MapOneToOne),"Object2Object","Create Mapping Between Two Types");
        return builder.AddField(nameof(InputModel),"Input Model :", FieldType.InputModel)
                .AddField(nameof(Source),"Source : ",FieldType.InputType)
                .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                .AddField(nameof(Destination),"Destination :",FieldType.OutputType)
                .Build();
    }
}
public class MapOneToOneHandler : ICommandHandler<MapOneToOne>
{
    private readonly IDomainModelService _domainModelService;

    public MapOneToOneHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MapOneToOne command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MapOneToOne command)
    {
        await _domainModelService.MapOneToOneAsync(command);
    }
}
