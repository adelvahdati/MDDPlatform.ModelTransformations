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
    SourceNode : DomainConcept
    SourceToDestinationRelation : hasProperty
    Output Model : BaseConcept (Built-in)
    ---------------------------------------
    By default property name is relation target instance name &
                property type is relation target instance type

*/

public class ReplaceRelationWithProperty : ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("aa10440d-d799-4240-bc3d-a85743b9984d");
    public Guid InputModel { get; set;}
    public string SourceNode { get; set;}
    public string SourceToDestinationRelation { get; set;}
    public Guid OutputModel { get; set;}

    public ReplaceRelationWithProperty(Guid inputModel, string sourceNode, string sourceToDestinationRelation, Guid outputModel)
    {
        InputModel = inputModel;
        SourceNode = sourceNode;
        SourceToDestinationRelation = sourceToDestinationRelation;
        OutputModel = outputModel;
    }

    internal ReplaceRelationWithProperty()
    {
        InputModel = Guid.Empty;
        SourceNode = string.Empty;
        SourceToDestinationRelation = string.Empty;
        OutputModel = Guid.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("aa10440d-d799-4240-bc3d-a85743b9984d"),nameof(ReplaceRelationWithProperty),"Object2Concept","Replace Relation with Property");
        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelation),"Source-to-Destination Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .Build();
    }
}
public class ReplaceRelationWithPropertyHandler : ICommandHandler<ReplaceRelationWithProperty>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithPropertyHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithProperty command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithProperty command)
    {
        await _domainModelService.ReplaceRelationWithPropertyAsync(command);
    }
}
