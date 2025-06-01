using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
public class CopyUpstreamNodeRelationToDownstreamNodeRelation : ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("b0eef210-777e-482c-bdd6-fb6baee81bce");    
    public Guid DownStreamModel { get; set; }
    public Guid UpStreamModel { get; set; }
    public string SourceNode { get; set; } // In downstream model
    public string DestinationNode { get; set; } // In upstream model
    public string SourceToDestinationRelationalDimension { get; set; }
    public string UpStreamNodeRelation { get; set; } // destination node relation
    public string DownStreamNodeRelation { get; set; } // source node relation

    public CopyUpstreamNodeRelationToDownstreamNodeRelation(Guid downStreamModel, Guid upStreamModel, string sourceNode, string destinationNode, string sourceToDestinationRelationalDimension, string upStreamNodeRelation, string downStreamNodeRelation)
    {
        DownStreamModel = downStreamModel;
        UpStreamModel = upStreamModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelationalDimension = sourceToDestinationRelationalDimension;
        UpStreamNodeRelation = upStreamNodeRelation;
        DownStreamNodeRelation = downStreamNodeRelation;
    }

    internal CopyUpstreamNodeRelationToDownstreamNodeRelation()
    {
        DownStreamModel = Guid.Empty;
        UpStreamModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelationalDimension = string.Empty;
        UpStreamNodeRelation = string.Empty;
        DownStreamNodeRelation = string.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("b0eef210-777e-482c-bdd6-fb6baee81bce"),nameof(CopyUpstreamNodeRelationToDownstreamNodeRelation),"RelationalDimension","Copy Upstream Node Relation To Downstream Node Relation");
        return builder.AddField(nameof(DownStreamModel),"Downstream Model :", FieldType.InputModel)
                        .AddField(nameof(UpStreamModel),"Upstream Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                        .AddField(nameof(DestinationNode),"Destination Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelationalDimension),"Source-to-Destination Relational Dimension :",FieldType.InputInstanceRelationalDimension)
                        .AddField(nameof(UpStreamNodeRelation),"Upstream Node Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(DownStreamNodeRelation),"Downstream Node Relation :",FieldType.InputTypeRelation)
                        .Build();
    }

}
public class CopyUpstreamNodeRelationToDownstreamNodeRelationHandler : ICommandHandler<CopyUpstreamNodeRelationToDownstreamNodeRelation>
{
    public void Handle(CopyUpstreamNodeRelationToDownstreamNodeRelation command)
    {
        throw new NotImplementedException();
    }

    public Task HandleAsync(CopyUpstreamNodeRelationToDownstreamNodeRelation command)
    {
        throw new NotImplementedException();
    }
}
