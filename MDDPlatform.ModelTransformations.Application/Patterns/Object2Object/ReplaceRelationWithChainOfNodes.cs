using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class ReplaceRelationWithChainOfNodes : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId =>Guid.Parse("a556975d-51c4-4d55-a261-f76229f92482");
    public Guid InputModel {get;set;}
    public string SourceNode {get;set;}    
    public string DestinationNode {get;set;}
    public string SourceToDestinationRelation {get;set;}
    public Guid OutputModel {get;set;}
    public string FirstNode {get;set;}
    public string MiddleNode {get;set;}
    public string LastNode {get;set;}
    
    public string FirstToMiddleNodeRelation {get;set;}
    public string MiddleToLastNodeRelation {get;set;}
    
    public string FirstNodeInstanceExpression { get; set; }
    public string MiddleNodeInstanceExpression {get;set;}
    public string LastNodeInstanceExpression {get;set;}

    public ReplaceRelationWithChainOfNodes(Guid inputModel, string sourceNode, string destinationNode, string sourceToDestinationRelation, Guid outputModel, string firstNode, string middleNode, string lastNode, string firstToMiddleNodeRelation, string middleToLastNodeRelation, string firstNodeInstanceExpression, string middleNodeInstanceExpression, string lastNodeInstanceExpression)
    {
        InputModel = inputModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelation = sourceToDestinationRelation;
        OutputModel = outputModel;
        FirstNode = firstNode;
        MiddleNode = middleNode;
        LastNode = lastNode;
        FirstToMiddleNodeRelation = firstToMiddleNodeRelation;
        MiddleToLastNodeRelation = middleToLastNodeRelation;
        FirstNodeInstanceExpression = firstNodeInstanceExpression;
        MiddleNodeInstanceExpression = middleNodeInstanceExpression;
        LastNodeInstanceExpression = lastNodeInstanceExpression;
    }
    internal ReplaceRelationWithChainOfNodes(){
        InputModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelation = string.Empty;
        OutputModel = Guid.Empty;
        FirstNode = string.Empty;
        MiddleNode = string.Empty;
        LastNode = string.Empty;
        FirstToMiddleNodeRelation = string.Empty;
        MiddleToLastNodeRelation = string.Empty;
        FirstNodeInstanceExpression = string.Empty;
        MiddleNodeInstanceExpression = string.Empty;
        LastNodeInstanceExpression = string.Empty;

    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("a556975d-51c4-4d55-a261-f76229f92482"),nameof(ReplaceRelationWithChainOfNodes),"Object2Object","Replace Relation With Chain Of Nodes");
        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                        .AddField(nameof(DestinationNode),"Destination Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelation),"Source-to-Destination Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .AddField(nameof(FirstNode),"First Node :", FieldType.OutputType)
                        .AddField(nameof(MiddleNode),"Middle Node :", FieldType.OutputType)
                        .AddField(nameof(LastNode), "Last Node :",FieldType.OutputType)
                        .AddField(nameof(FirstToMiddleNodeRelation),"First-to-Middle Node Relation :", FieldType.OutputTypeRelation)
                        .AddField(nameof(MiddleToLastNodeRelation),"Middle-to-Last Node Relation :", FieldType.OutputTypeRelation)
                        .AddField(nameof(FirstNodeInstanceExpression),"Fist Node Instance Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(MiddleNodeInstanceExpression),"Middle Node Instance Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(LastNodeInstanceExpression),"Last Node Instance Expression :",FieldType.InputTypeExpression)
                        .Build();
    }
}
public class ReplaceRelationWithChainOfNodesHandler : ICommandHandler<ReplaceRelationWithChainOfNodes>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithChainOfNodesHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithChainOfNodes command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithChainOfNodes command)
    {
        await _domainModelService.ReplaceRelationWithChainOfNodesAsync(command);
    }
}