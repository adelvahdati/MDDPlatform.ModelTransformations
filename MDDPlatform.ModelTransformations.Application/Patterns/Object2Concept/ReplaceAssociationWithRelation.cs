using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
public class ReplaceAssociationWithRelation : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("cac84ede-9514-4cef-80ee-193ec4814f9a");
    public Guid InputModel {get;set;}
    public string SourceNode {get;set;} // Concept node
    public string DestinationNode {get;set;} // Association node
    public string SourceToDestinationRelation { get;set;}
    public string RelationNameProperty {get;set;}
    public string RelationTargetProperty {get;set;}
    public string MultiplicityProperty {get;set;}
    public Guid OutputModel {get;set;}

    public ReplaceAssociationWithRelation(Guid inputModel, string sourceNode, string destinationNode, string sourceToDestinationRelation, string relationNameProperty, string relationTargetProperty, string multiplicityProperty, Guid outputModel)
    {
        InputModel = inputModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelation = sourceToDestinationRelation;
        RelationNameProperty = relationNameProperty;
        RelationTargetProperty = relationTargetProperty;
        MultiplicityProperty = multiplicityProperty;
        OutputModel = outputModel;
    }
    internal ReplaceAssociationWithRelation()
    {
        InputModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelation = string.Empty;
        RelationNameProperty = string.Empty;
        RelationTargetProperty = string.Empty;
        MultiplicityProperty = string.Empty;
        OutputModel = Guid.Empty;

    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("cac84ede-9514-4cef-80ee-193ec4814f9a"),nameof(ReplaceAssociationWithRelation),"Object2Concept","Replace Association With Relation");

        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :", FieldType.InputType)
                        .AddField(nameof(DestinationNode),"Destination Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelation),"Source-to-Destination Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(RelationNameProperty),"Relation Name Property :",FieldType.InputTypeProperty)
                        .AddField(nameof(RelationTargetProperty),"Relation Target Property :",FieldType.InputTypeProperty)
                        .AddField(nameof(MultiplicityProperty),"Multiplicity Property :",FieldType.InputTypeProperty)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .Build();
    }
}
public class ReplaceAssociationWithRelationHandler : ICommandHandler<ReplaceAssociationWithRelation>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceAssociationWithRelationHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceAssociationWithRelation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceAssociationWithRelation command)
    {        
        await _domainModelService.ReplaceAssociationWithRelationAsync(command);        
    }
}
