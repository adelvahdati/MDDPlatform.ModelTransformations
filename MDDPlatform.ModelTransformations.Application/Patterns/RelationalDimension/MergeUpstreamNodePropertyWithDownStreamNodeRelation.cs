using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
public class MergeUpstreamNodePropertyWithDownStreamNodeRelation :  ModelTransformationRequest,ITransformationPattern
{
    public static Guid PatternId =>Guid.Parse("bca7ded3-b074-4b58-9874-fb3e120e74c7");    
    public Guid DownStreamModel { get; set; }
    public Guid UpStreamModel { get; set; }
    public string SourceNode { get; set; } // In downstream model
    public string SourceToDestinationRelationalDimension { get; set; }
    public string SourceNodeRelationName {get;set;}
    public Guid OutputModel {get;set;}

    public MergeUpstreamNodePropertyWithDownStreamNodeRelation(Guid downStreamModel, Guid upStreamModel, string sourceNode, string sourceToDestinationRelationalDimension, string sourceNodeRelationName, Guid outputModel)
    {
        DownStreamModel = downStreamModel;
        UpStreamModel = upStreamModel;
        SourceNode = sourceNode;
        SourceToDestinationRelationalDimension = sourceToDestinationRelationalDimension;
        SourceNodeRelationName = sourceNodeRelationName;
        OutputModel = outputModel;
    }


    public MergeUpstreamNodePropertyWithDownStreamNodeRelation()
    {
        DownStreamModel = Guid.Empty;
        UpStreamModel = Guid.Empty;
        SourceNode = string.Empty;
        SourceToDestinationRelationalDimension = string.Empty;
        SourceNodeRelationName = string.Empty;
        OutputModel = Guid.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("bca7ded3-b074-4b58-9874-fb3e120e74c7"),nameof(MergeUpstreamNodePropertyWithDownStreamNodeRelation),"RelationalDimension","Mereg Upstream Node Property To Downstream Node Relation");
        return builder.AddField(nameof(DownStreamModel),"Downstream Model :", FieldType.InputModel)
                        .AddField(nameof(UpStreamModel),"Upstream Model :",FieldType.InputModel)
                        .AddField(nameof(SourceNode),"Source Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelationalDimension),"Source-to-Destination Relational Dimension :",FieldType.InputInstanceRelationalDimension)
                        .AddField(nameof(SourceNodeRelationName),"Source Node Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(OutputModel),"Output Model :", FieldType.OutputModel)
                        .Build();
    }
}
public class MergeUpstreamNodePropertyWithDownStreamNodeRelationHandler : ICommandHandler<MergeUpstreamNodePropertyWithDownStreamNodeRelation>
{
    private readonly IDomainModelService _domainModelService;

    public MergeUpstreamNodePropertyWithDownStreamNodeRelationHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MergeUpstreamNodePropertyWithDownStreamNodeRelation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MergeUpstreamNodePropertyWithDownStreamNodeRelation command)
    {
        await _domainModelService.MergeUpstreamNodePropertyWithDownStreamNodeRelationAsync(command);
    }
}
