using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class MapInstance : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("c77d073f-cc2f-45b1-9024-b2a318c4c94b");
    public Guid InputModel { get; set; }
    public Guid OutputModel { get; set; }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("c77d073f-cc2f-45b1-9024-b2a318c4c94b"), nameof(MapInstance), "Object2Object", "Map Instances");
        return builder.AddField(nameof(InputModel), "Input Model :", FieldType.InputModel)
                        .AddField(nameof(OutputModel), "Output Model :", FieldType.OutputModel)
                        .Build();
    }
}
public class MapInstanceHandler : ICommandHandler<MapInstance>
{
    private readonly IDomainModelService _domainModelService;

    public MapInstanceHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MapInstance command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MapInstance command)
    {
        await _domainModelService.MapInstanceAsync(command);
    }
}
