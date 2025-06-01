using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
public class ReplaceRelationWithAction : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("5187d36d-5814-4276-80ff-ded6197a07d1");
    public Guid InputModel { get; set;}
    public string ConceptNode { get; set;}
    public string OperationNameProperty { get; set;}
    public string OperationOutputProperty { get; set;} // Task, Void, ""
    public string OperationInputsRelation {get;set;}
    public Guid OutputModel { get; set;}

    public ReplaceRelationWithAction(Guid inputModel, string conceptNode, string operationNameProperty, string operationOutputProperty, string operationInputsRelation, Guid outputModel)
    {
        InputModel = inputModel;
        ConceptNode = conceptNode;
        OperationNameProperty = operationNameProperty;
        OperationOutputProperty = operationOutputProperty;
        OperationInputsRelation = operationInputsRelation;
        OutputModel = outputModel;
    }
    internal ReplaceRelationWithAction()
    {
        InputModel = Guid.Empty;
        OutputModel = Guid.Empty;
        ConceptNode = string.Empty;
        OperationNameProperty = string.Empty;
        OperationOutputProperty = string.Empty;
        OperationInputsRelation = string.Empty;
    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("5187d36d-5814-4276-80ff-ded6197a07d1"),nameof(ReplaceRelationWithAction),"Object2Concept","Replace Relation With Action");

        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(ConceptNode),"Concept Node :", FieldType.InputType)
                        .AddField(nameof(OperationNameProperty),"Operation Name :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationOutputProperty),"Operation Output :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationInputsRelation),"Operation Inputs Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .Build();
    }
}
public class ReplaceRelationWithActionHandler : ICommandHandler<ReplaceRelationWithAction>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithActionHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithAction command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithAction command)
    {
        await _domainModelService.ReplaceRelationWithActionAsync(command);
    }
}
