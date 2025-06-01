using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
/* 
Example :
    Input Model : CIM Metamodel
    SourceNode : *
    DestinationNode : StringValueObject
    SourceToDestinationRelation : hasProperty
    Output Model : BaseConcept (Built-in)
    ProeprtyName : DestinationNode.Name     
    PropertyType : DestinationNode.Type      
*/

public class ReplaceRelationWithGenericProperty : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("211b0b93-9044-4f93-94ff-cff393ef5f39");
    public Guid InputModel {get;set;}
    public string SourceNode {get;set;}
    public string DestinationNode {get;set;}
    public string SourceToDestinationRelation {get;set;}

    //Output
    public Guid OutputModel {get;set;}
    public string PropertyName {get;set;}
    public string PropertyType {get;set;}

    public ReplaceRelationWithGenericProperty(Guid inputModel, string sourceNode, string destinationNode, string sourceToDestinationRelation, Guid outputModel, string propertyName, string propertyType)
    {
        InputModel = inputModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelation = sourceToDestinationRelation;
        OutputModel = outputModel;
        PropertyName = propertyName;
        PropertyType = propertyType;
    }

    internal ReplaceRelationWithGenericProperty()
    {
        InputModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelation = string.Empty;
        OutputModel = Guid.Empty;
        PropertyName = string.Empty;
        PropertyType = string.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("211b0b93-9044-4f93-94ff-cff393ef5f39"),nameof(ReplaceRelationWithGenericProperty),"Object2Concept","Replace Relation With Generic Property");
        return builder.AddField(nameof(InputModel),"Input Model :", FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                        .AddField(nameof(DestinationNode),"Destination Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelation),"Source-to-Destination Relation",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .AddField(nameof(PropertyName),"Property Name :", FieldType.InputTypeExpression)
                        .AddField(nameof(PropertyType),"Property Type :" , FieldType.InputTypeExpression)
                        .Build();
    }
}
public class ReplaceRelationWithGenericPropertyHandler : ICommandHandler<ReplaceRelationWithGenericProperty>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithGenericPropertyHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithGenericProperty command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithGenericProperty command)
    {
        await _domainModelService.ReplaceRelationwithGenericPropertyAsync(command);
    }
}
