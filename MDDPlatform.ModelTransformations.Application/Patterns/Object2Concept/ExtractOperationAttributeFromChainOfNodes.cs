using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
public class ExtractOperationAttributeFromChainOfNodes : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("78fd51b3-5bc5-4cb2-8979-dca1b330257a");
    public Guid InputModel { get;set;}
    public string FirstNode {get;set;}  // BaseClass
    public string MiddleNode {get;set;} // Operation
    public string LastNode {get;set;}   // OperationBody
    public string FirstToMiddleNodeRelation {get;set;}  // hasOperation
    public string MiddleToLastNodeRelation {get;set;}   // hasBody
    public Guid OutputModel {get;set;}
    public string ConceptNameExpression {get;set;}  //FirstNode.Name
    public string ConceptTypeExpression {get;set;}  //FirstNode._Type
    public string OperationNameExpression{get;set;} // MiddleNode.Name
    public string AttributeNameExpression {get;set;}    // body
    public string AttributeValueExpression {get;set;}   // LastNode.Text

    public ExtractOperationAttributeFromChainOfNodes(Guid inputModel, string firstNode, string middleNode, string lastNode, string firstToMiddleNodeRelation, string middleToLastNodeRelation, Guid outputModel, string conceptNameExpression, string conceptTypeExpression, string operationNameExpression, string attributeNameExpression, string attributeValueExpression)
    {
        InputModel = inputModel;
        FirstNode = firstNode;
        MiddleNode = middleNode;
        LastNode = lastNode;
        FirstToMiddleNodeRelation = firstToMiddleNodeRelation;
        MiddleToLastNodeRelation = middleToLastNodeRelation;
        OutputModel = outputModel;
        ConceptNameExpression = conceptNameExpression;
        ConceptTypeExpression = conceptTypeExpression;
        OperationNameExpression = operationNameExpression;
        AttributeNameExpression = attributeNameExpression;
        AttributeValueExpression = attributeValueExpression;
    }
    public ExtractOperationAttributeFromChainOfNodes()
    {
        InputModel = Guid.Empty;
        FirstNode = string.Empty;
        MiddleNode = string.Empty;
        LastNode = string.Empty;
        FirstToMiddleNodeRelation = string.Empty;
        MiddleToLastNodeRelation = string.Empty;
        OutputModel = Guid.Empty;
        ConceptNameExpression = string.Empty;
        ConceptTypeExpression = string.Empty;
        OperationNameExpression = string.Empty;
        AttributeNameExpression = string.Empty;
        AttributeValueExpression = string.Empty;

    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(ExtractOperationAttributeFromChainOfNodes.PatternId,nameof(ExtractOperationAttributeFromChainOfNodes),"Object2Concept","Extract operation attributes from chain of nodes");

        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(FirstNode),"First Node :", FieldType.InputType)
                        .AddField(nameof(MiddleNode),"Middle Node :",FieldType.InputType)
                        .AddField(nameof(LastNode),"Last Node :",FieldType.InputType)
                        .AddField(nameof(FirstToMiddleNodeRelation),"First-to-Middle Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(MiddleToLastNodeRelation),"Middle-to-Last Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .AddField(nameof(ConceptNameExpression),"Concept Name Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(ConceptTypeExpression),"Concept Type Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationNameExpression),"Operation Name Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(AttributeNameExpression),"Attribute Name Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(AttributeValueExpression),"Attribute Value Expression :",FieldType.InputTypeExpression)
                        .Build();
    }

}
public class ExtractOperationAttributeFromChainOfNodesHandler : ICommandHandler<ExtractOperationAttributeFromChainOfNodes>
{
    private readonly IDomainModelService _domainModelService;

    public ExtractOperationAttributeFromChainOfNodesHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ExtractOperationAttributeFromChainOfNodes command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ExtractOperationAttributeFromChainOfNodes command)
    {
        await _domainModelService.ExtractOperationAttributeFromChainOfNodesAsync(command);
    }
}