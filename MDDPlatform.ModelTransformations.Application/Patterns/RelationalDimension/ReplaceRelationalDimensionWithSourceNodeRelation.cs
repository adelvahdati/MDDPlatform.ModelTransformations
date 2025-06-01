using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
/*
Example : 
    DownstreemModel : Controller model
    UpstreamModel : BaseConcept (Built-in)

    SourceNode : Controller.Concept
    DestinationNode : Command.Concept

    SourceToDestinationRelationalDimension : isDispatcherOf
    RelationName : dispatchCommand
    RelationTarget : Command.Concept 
    ----------------------------------------
    By default output model is equal to down stream model and change apply to it

*/

public class ReplaceRelationalDimensionWithSourceNodeRelation : ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("70961d39-bd3c-4ec5-a0a7-8f515464c3e1");    
    public Guid DownStreamModel { get; set;}
    public Guid UpStreamModel { get; set;}
    public string SourceNode { get; set;} // In downstream model
    public string DestinationNode { get; set;} // In upstream model
    public string SourceToDestinationRelationalDimension { get; set;}
    public string RelationName { get; set;} // In downstream model : source node relation
    public string RelationTarget { get; set;} // In downstream model : source node relation target

    public ReplaceRelationalDimensionWithSourceNodeRelation(Guid downStreamModel, Guid upStreamModel, string sourceNode, string destinationNode, string sourceToDestinationRelationalDimension, string relationName, string relationTarget)
    {
        DownStreamModel = downStreamModel;
        UpStreamModel = upStreamModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelationalDimension = sourceToDestinationRelationalDimension;
        RelationName = relationName;
        RelationTarget = relationTarget;
    }

    public ReplaceRelationalDimensionWithSourceNodeRelation()
    {
        DownStreamModel = Guid.Empty;
        UpStreamModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelationalDimension = string.Empty;
        RelationName = string.Empty;
        RelationTarget = string.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder build = PatternBuilder.Create(Guid.Parse("70961d39-bd3c-4ec5-a0a7-8f515464c3e1"),nameof(ReplaceRelationalDimensionWithSourceNodeRelation),"RelationalDimension","Replace relational dimension with source node relation");
        return build.AddField(nameof(DownStreamModel),"Downstream Model :",FieldType.InputModel)
                    .AddField(nameof(UpStreamModel),"Upsteram Model :",FieldType.InputModel)
                    .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                    .AddField(nameof(DestinationNode),"Destination Node :", FieldType.InputType)
                    .AddField(nameof(SourceToDestinationRelationalDimension),"Source-to-Destination Relational Dimension :",FieldType.InputInstanceRelationalDimension)
                    .AddField(nameof(RelationName),"Relation Name :",FieldType.InputTypeRelation)
                    .AddField(nameof(RelationTarget),"Relation Target Type :",FieldType.InputType)
                    .Build();
    }
}
public class ReplaceRelationalDimensionWithSourceNodeRelationHandler : ICommandHandler<ReplaceRelationalDimensionWithSourceNodeRelation>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationalDimensionWithSourceNodeRelationHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationalDimensionWithSourceNodeRelation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationalDimensionWithSourceNodeRelation command)
    {
        await _domainModelService.ReplaceRelationalDimensionWithSourceNodeRelationAsync(command);
    }
}
