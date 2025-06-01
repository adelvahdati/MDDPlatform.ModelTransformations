using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
public class ReplaceRelationWithOperationAttributes : ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("2673cc13-0d04-4f4a-b2b2-3255ea5ea5ab");
    public Guid InputModel { get; set;}
    public string ConceptNode { get; set;}
    public string OperationNode { get; set;}
    public string OperationNameProperty { get; set;}
    public string OperationOutputProperty { get; set;}
    public string ConceptToOperationRelation { get; set;}
    public string OperationToInputParametersRelation { get; set;}
    public Guid OutputModel { get; set;}

    public ReplaceRelationWithOperationAttributes(Guid inputModel, string conceptNode, string operationNode, string operationNameProperty, string operationOutputProperty, string conceptToOperationRelation, string operationToInputParametersRelation, Guid outputModel)
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

    internal ReplaceRelationWithOperationAttributes()
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
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("2673cc13-0d04-4f4a-b2b2-3255ea5ea5ab"),nameof(ReplaceRelationWithOperationAttributes),"Object2Concept","Replace Relation With Operation & Operation Attributes");

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
public class ReplaceRelationWithOperationAttributesHandler : ICommandHandler<ReplaceRelationWithOperationAttributes>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithOperationAttributesHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithOperationAttributes command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithOperationAttributes command)
    {
        await _domainModelService.ReplaceRelationWithOperationAttributesAsync(command);
    }
}
