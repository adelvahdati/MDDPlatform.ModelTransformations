using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;

public class ReplaceRelationWithConceptAttribute : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("6139df3a-0926-4d39-a4df-0226acee5ae8");
    public Guid InputModel {get;set;}
    public string SourceNode {get;set;}
    public string DestinationNode {get;set;}
    public string SourceToDestinationRelation {get;set;}
    public string AttributeNameExpression {get;set;}
    public string AttributeValueExpression {get;set;}
    public Guid OutputModel {get;set;}

    public ReplaceRelationWithConceptAttribute(Guid inputModel, string sourceNode, string destinationNode, string sourceToDestinationRelation, string attributeNameExpression, string attributeValueExpression, Guid outputModel)
    {
        InputModel = inputModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelation = sourceToDestinationRelation;
        AttributeNameExpression = attributeNameExpression;
        AttributeValueExpression = attributeValueExpression;
        OutputModel = outputModel;
    }
    public ReplaceRelationWithConceptAttribute(){
        InputModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelation = string.Empty;
        AttributeNameExpression = string.Empty;
        AttributeValueExpression = string.Empty;
        OutputModel = Guid.Empty;

    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("6139df3a-0926-4d39-a4df-0226acee5ae8"),nameof(ReplaceRelationWithConceptAttribute),"Object2Concept","Replace Relation With Concept Attribute");

        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :", FieldType.InputType)
                        .AddField(nameof(DestinationNode),"Destination Name :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelation),"Source-To-Destination Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(AttributeNameExpression),"Attribute Name Expression :",FieldType.InputTypeExpression)
                        .AddField(nameof(AttributeValueExpression),"Attribute Value Expression",FieldType.InputTypeExpression)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .Build();
    }
}
public class ReplaceRelationWithConceptAttributeHanlder : ICommandHandler<ReplaceRelationWithConceptAttribute>
{

    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithConceptAttributeHanlder(IDomainModelService domainModelService)
    {
        this._domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithConceptAttribute command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithConceptAttribute command)
    {
        await _domainModelService.ReplaceRelationWithConceptAttributeAsync(command);
    }
}
