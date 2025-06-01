using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
public class ExtractOperationFromOneToOneToManyRelation : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("2841df95-effa-4b03-880a-1c4c9c6e3dd0");

    public Guid InputModel { get;set;}
    public string FirstNode {get;set;}  // BaseClass.Concept
    public string MiddleNode {get;set;} // Operation.Concept
    public string LastNode {get;set;}   // Parameter.Concept
    public string FirstToMiddleNodeRelation {get;set;}  // hasOperation
    public string MiddleToLastNodeRelation {get;set;}   // hasInput
    public string OperationNameExpression {get;set;}    // MiddleNode.OperationName
    public string OperationInputNameExpression {get;set;}  // LastNode.ParameterName
    public string OperationInputTypeExpression {get;set;}  // LastNode.ParameterType
    public string OperationOutputTypeExpression {get;set;}  // MiddleNode.OperationOutput
    public Guid OutputModel {get;set;}

    public ExtractOperationFromOneToOneToManyRelation(Guid inputModel, string firstNode, string middleNode, string lastNode, string firstToMiddleNodeRelation, string middleToLastNodeRelation, string operationNameExpression, string operationInputNameExpression, string operationInputTypeExpression, string operationOutputTypeExpression, Guid outputModel)
    {
        InputModel = inputModel;
        FirstNode = firstNode;
        MiddleNode = middleNode;
        LastNode = lastNode;
        FirstToMiddleNodeRelation = firstToMiddleNodeRelation;
        MiddleToLastNodeRelation = middleToLastNodeRelation;
        OperationNameExpression = operationNameExpression;
        OperationInputNameExpression = operationInputNameExpression;
        OperationInputTypeExpression = operationInputTypeExpression;
        OperationOutputTypeExpression = operationOutputTypeExpression;
        OutputModel = outputModel;
    }
    public ExtractOperationFromOneToOneToManyRelation(){
        InputModel = Guid.Empty;
        FirstNode = string.Empty;
        MiddleNode = string.Empty;
        LastNode = string.Empty;
        FirstToMiddleNodeRelation = string.Empty;
        MiddleToLastNodeRelation = string.Empty;
        OperationNameExpression = string.Empty;
        OperationInputNameExpression = string.Empty;
        OperationInputTypeExpression = string.Empty;
        OperationOutputTypeExpression = string.Empty;
        OutputModel = Guid.Empty;

    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(ExtractOperationFromOneToOneToManyRelation.PatternId,nameof(ExtractOperationFromOneToOneToManyRelation),"Object2Concept","Extract Operation From One To One To Many Relations");

        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(FirstNode),"First Node :", FieldType.InputType)
                        .AddField(nameof(MiddleNode),"Middle Node :",FieldType.InputType)
                        .AddField(nameof(LastNode),"Last Node :",FieldType.InputType)
                        .AddField(nameof(FirstToMiddleNodeRelation),"First-to-Middle Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(MiddleToLastNodeRelation),"Middle-to-Last Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .AddField(nameof(OperationNameExpression),"Operation Name Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationInputNameExpression),"Operation Input Name Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationInputTypeExpression),"Operation Input Type Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationOutputTypeExpression),"Operation Output Type Expression :",FieldType.InputTypeExpression)
                        .Build();
    }
}
public class ExtractOperationFromOneToOneToManyRelationHandler : ICommandHandler<ExtractOperationFromOneToOneToManyRelation>
{
    private readonly IDomainModelService _domainModelService;

    public ExtractOperationFromOneToOneToManyRelationHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ExtractOperationFromOneToOneToManyRelation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ExtractOperationFromOneToOneToManyRelation command)
    {
        await _domainModelService.ExtractOperationFromOneToOneToManyRelationAsync(command);
    }
}
