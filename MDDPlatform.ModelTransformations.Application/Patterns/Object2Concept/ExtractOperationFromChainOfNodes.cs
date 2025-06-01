using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;

public class ExtractOperationFromChainOfNodes : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("86ab1c9c-4835-4eb9-80c5-0e331c87598c");
    public Guid InputModel { get;set;}
    public string FirstNode {get;set;}  // QueryHandler
    public string MiddleNode {get;set;} // Query
    public string LastNode {get;set;}   // QueryResult
    public string FirstToMiddleNodeRelation {get;set;}  // canHandle
    public string MiddleToLastNodeRelation {get;set;}   // return
    public string OperationNameExpression {get;set;}    // Handle
    public string OperationInputsExpression {get;set;}  // FirstNode.canHandle(Query.Concept)
    public string OperationOutputTypeExpression {get;set;}  // LastNode.ResultType
    public string OperationOutputMultiplicityExpression {get;set;}  // LastNode.Multiplicity
    public Guid OutputModel {get;set;}

    internal ExtractOperationFromChainOfNodes()
    {
        InputModel = Guid.Empty;
        FirstNode = string.Empty;
        MiddleNode = string.Empty;
        LastNode = string.Empty;
        FirstToMiddleNodeRelation = string.Empty;
        MiddleToLastNodeRelation =  string.Empty;
        OperationNameExpression =  string.Empty;
        OperationInputsExpression =  string.Empty;
        OperationOutputTypeExpression =  string.Empty;
        OperationOutputMultiplicityExpression =  string.Empty;
        OutputModel = Guid.Empty;

    }
    public ExtractOperationFromChainOfNodes(Guid inputModel, string firstNode, string middleNode, string lastNode, string firstToMiddleNodeRelation, string middleToLastNodeRelation, string operationNameExpression, string operationInputsExpression, string operationOutputTypeExpression, string operationOutputMultiplicityExpression, Guid outputModel)
    {
        InputModel = inputModel;
        FirstNode = firstNode;
        MiddleNode = middleNode;
        LastNode = lastNode;
        FirstToMiddleNodeRelation = firstToMiddleNodeRelation;
        MiddleToLastNodeRelation = middleToLastNodeRelation;
        OperationNameExpression = operationNameExpression;
        OperationInputsExpression = operationInputsExpression;
        OperationOutputTypeExpression = operationOutputTypeExpression;
        OperationOutputMultiplicityExpression = operationOutputMultiplicityExpression;
        OutputModel = outputModel;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("86ab1c9c-4835-4eb9-80c5-0e331c87598c"),nameof(ExtractOperationFromChainOfNodes),"Object2Concept","Extract operation from chain of nodes");

        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(FirstNode),"First Node :", FieldType.InputType)
                        .AddField(nameof(MiddleNode),"Middle Node :",FieldType.InputType)
                        .AddField(nameof(LastNode),"Last Node :",FieldType.InputType)
                        .AddField(nameof(FirstToMiddleNodeRelation),"First-to-Middle Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(MiddleToLastNodeRelation),"Middle-to-Last Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OperationNameExpression),"Operation Name Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationInputsExpression),"Operation Inputs Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationOutputTypeExpression),"Output Type Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationOutputMultiplicityExpression),"Output Multiplicity Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .Build();
    }
}
public class ExtractOperationFromChainOfNodesHandler : ICommandHandler<ExtractOperationFromChainOfNodes>
{
    private readonly IDomainModelService _domainModelService;

    public ExtractOperationFromChainOfNodesHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ExtractOperationFromChainOfNodes command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ExtractOperationFromChainOfNodes command)
    {
        await _domainModelService.ExtractOperationFromChainOfNodesAsync(command);
    }
}
