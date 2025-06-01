using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
public class CopyUpstreamNodePropertyToDownstreamNodeRelation : ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("169734f9-9079-4b9c-b6fa-17c720c3153b");
    public Guid DownStreamModel { get; set; }
    public Guid UpStreamModel { get; set; }
    public string SourceNode { get; set; } // In downstream model
    public string DestinationNode { get; set; } // In upstream model
    public string SourceToDestinationRelationalDimension { get; set; }
    public string RelationName { get; set; } // In downstream model : source node relation

    public CopyUpstreamNodePropertyToDownstreamNodeRelation(Guid downStreamModel, Guid upStreamModel, string sourceNode, string destinationNode, string sourceToDestinationRelationalDimension, string relationName)
    {
        DownStreamModel = downStreamModel;
        UpStreamModel = upStreamModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelationalDimension = sourceToDestinationRelationalDimension;
        RelationName = relationName;
    }

    public CopyUpstreamNodePropertyToDownstreamNodeRelation()
    {
        DownStreamModel = Guid.Empty;
        UpStreamModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelationalDimension = string.Empty;
        RelationName = string.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("169734f9-9079-4b9c-b6fa-17c720c3153b"),nameof(CopyUpstreamNodePropertyToDownstreamNodeRelation),"RelationalDimension","Copy Upstream node property to downstream node relation");
        return builder.AddField(nameof(DownStreamModel),"DownStream Model :" , FieldType.InputModel)
                        .AddField(nameof(UpStreamModel),"UpStream Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                        .AddField(nameof(DestinationNode),"Destination Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelationalDimension),"Source-to-Destination Relational Dimension :",FieldType.InputInstanceRelationalDimension)
                        .AddField(nameof(RelationName),"Relatin Name :", FieldType.InputTypeRelation)
                        .Build();
    }
}
public class CopyUpstreamNodePropertyToDownstreamNodeRelationHandler : ICommandHandler<CopyUpstreamNodePropertyToDownstreamNodeRelation>
{
    private readonly IDomainModelService _domainModelService;

    public CopyUpstreamNodePropertyToDownstreamNodeRelationHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(CopyUpstreamNodePropertyToDownstreamNodeRelation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CopyUpstreamNodePropertyToDownstreamNodeRelation command)
    {
        await _domainModelService.CopyUpstreamNodePropertyToDownstreamNodeRelationAsync(command);
    }
}
