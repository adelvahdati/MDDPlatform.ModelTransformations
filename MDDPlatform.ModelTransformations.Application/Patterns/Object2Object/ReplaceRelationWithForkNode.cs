using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
/* 
Example :
    Input Model : CRAC metamodel
    SourceNode : Command
    DestinationNode : Event
    SourceToDestinationRelation : publishFact
    ----------------------------------------
    Output Model : CQRS metamodel
    ForkNode : CommandHandler
    ForkNodeInstanceName : SourceNode.Name
    ForkNodeInstanceNamePrefix : ""
    ForkNodeInstanceNamePostfix : "Handler"
    ForkToSourceRelation : canHandle
    ForkToDestinationRelation : canPublish
*/

public class ReplaceRelationWithForkNode : ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("920f5120-cdac-4bb1-a40c-edcf9aa347ec");
    public Guid InputModel { get; set;}
    public string SourceNode { get; set;}
    public string DestinationNode { get; set;}
    public string SourceToDestinationRelation { get; set;}
    public Guid OutputModel { get; set;}
    public string ForkNode { get; set;}
    public string ForkToSourceRelation { get; set;}
    public string ForkToDestinationRelation { get; set;}
    public string ForkNodeInstanceName { get; set;}
    public string ForkNodeInstanceNamePrefix { get; set;}
    public string ForkNodeInstanceNamePostfix { get; set;}

    public ReplaceRelationWithForkNode(Guid inputModel, string sourceNode, string destinationNode, string sourceToDestinationRelation, Guid outputModel, string forkNode, string forkToSourceRelation, string forkToDestinationRelation, string forkNodeInstanceName, string forkNodeInstanceNamePrefix, string forkNodeInstanceNamePostfix)
    {
        InputModel = inputModel;
        SourceNode = sourceNode;
        DestinationNode = destinationNode;
        SourceToDestinationRelation = sourceToDestinationRelation;
        OutputModel = outputModel;
        ForkNode = forkNode;
        ForkToSourceRelation = forkToSourceRelation;
        ForkToDestinationRelation = forkToDestinationRelation;
        ForkNodeInstanceName = forkNodeInstanceName;
        ForkNodeInstanceNamePrefix = forkNodeInstanceNamePrefix;
        ForkNodeInstanceNamePostfix = forkNodeInstanceNamePostfix;
    }

    internal ReplaceRelationWithForkNode()
    {
        InputModel = Guid.Empty;
        SourceNode = string.Empty;
        DestinationNode = string.Empty;
        SourceToDestinationRelation = string.Empty;
        OutputModel = Guid.Empty;
        ForkNode = string.Empty;
        ForkToSourceRelation = string.Empty;
        ForkToDestinationRelation = string.Empty;
        ForkNodeInstanceName = string.Empty;
        ForkNodeInstanceNamePrefix = string.Empty;
        ForkNodeInstanceNamePostfix = string.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("920f5120-cdac-4bb1-a40c-edcf9aa347ec"),nameof(ReplaceRelationWithForkNode),"Object2Object","Replace Relation With Fork Node");
        return builder.AddField(nameof(InputModel),"Input Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                        .AddField(nameof(DestinationNode),"Destination Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelation),"Source-to-Destination Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .AddField(nameof(ForkNode),"Fork Node :",FieldType.OutputType)
                        .AddField(nameof(ForkToSourceRelation),"Fork-to-Source Relation :",FieldType.OutputTypeRelation)
                        .AddField(nameof(ForkToDestinationRelation),"Fork-to-Destination Relation", FieldType.OutputTypeRelation)
                        .AddField(nameof(ForkNodeInstanceName),"Fork Node Instance Name :",FieldType.InputTypeExpression)
                        .AddField(nameof(ForkNodeInstanceNamePrefix),"Instance Name Prefix :",FieldType.Constant)
                        .AddField(nameof(ForkNodeInstanceNamePostfix),"Instance Name Postfix :",FieldType.Constant)
                        .Build();
    }
}
public class ReplaceRelationWithForkNodeHandler : ICommandHandler<ReplaceRelationWithForkNode>
{
    private readonly IDomainModelService _domainModelService;

    public ReplaceRelationWithForkNodeHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ReplaceRelationWithForkNode command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ReplaceRelationWithForkNode command)
    {
        await _domainModelService.ReplaceRelationWithForkNodeAsync(command);
    }
}
