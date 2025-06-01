using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
public class ReplaceRelationWithOperation : ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("04a3edc6-04a8-43eb-8742-2422fbc9f188");
    public Guid InputModel { get; set;}
    public string ConceptNode { get; set;}
    public string OperationNode { get; set;}
    public string OperationNameProperty { get; set;}
    public string OperationOutputProperty { get; set;}
    public string ConceptToOperationRelation { get; set;}
    public string OperationToInputParametersRelation { get; set;}
    public Guid OutputModel { get; set;}

    public ReplaceRelationWithOperation(Guid inputModel, string conceptNode, string operationNode, string operationNameProperty, string operationOutputProperty, string conceptToOperationRelation, string operationToInputParametersRelation, Guid outputModel)
    {
        InputModel = inputModel;
        ConceptNode = conceptNode;
        OperationNode = operationNode;
        OperationNameProperty = operationNameProperty;
        OperationOutputProperty = operationOutputProperty;
        ConceptToOperationRelation = conceptToOperationRelation;
        OperationToInputParametersRelation = operationToInputParametersRelation;
        OutputModel = outputModel;
    }

    internal ReplaceRelationWithOperation()
    {
        InputModel = Guid.Empty;
        ConceptNode =string.Empty;
        OperationNode = string.Empty;
        OperationNameProperty = string.Empty;
        OperationOutputProperty = string.Empty;
        ConceptToOperationRelation = string.Empty;
        OperationToInputParametersRelation = string.Empty;
        OutputModel = Guid.Empty;

    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("04a3edc6-04a8-43eb-8742-2422fbc9f188"),nameof(ReplaceRelationWithOperation),"Object2Concept","Replace Relation With Operation");

        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(ConceptNode),"Concept Node :", FieldType.InputType)
                        .AddField(nameof(OperationNode),"Operation Node :",FieldType.InputType)
                        .AddField(nameof(OperationNameProperty),"Operation Name Property :",FieldType.InputTypeExpression)
                        .AddField(nameof(OperationOutputProperty),"Operation Output Property :",FieldType.InputTypeExpression)
                        .AddField(nameof(ConceptToOperationRelation),"Concept-to-Operation Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OperationToInputParametersRelation),"Operation-to-InputParameter Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .Build();
    }
}
public class ReplaceRelationWithOperationHandler : ICommandHandler<ReplaceRelationWithOperation>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithOperationHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithOperation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithOperation command)
    {
        await _domainModelService.ReplaceRelationWithOperationAsync(command);
    }
}
