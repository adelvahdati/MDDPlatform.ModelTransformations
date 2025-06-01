using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
public class MergeUpstreamNodeWithDownStreamNode : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId =>Guid.Parse("7c87b1be-a50d-4798-9345-920f9085cc9b");    
    public Guid DownStreamModel { get; set; }
    public Guid UpStreamModel { get; set; }
    public string DownStreamNode { get; set; } // In downstream model
    public string RelationalDimension { get; set; }

    public bool CopyUpstreamNodeProperty {get;set;}
    public bool CopyUpsteramNodeOperation {get;set;}
    public bool CopyDownstreamNodeProperty {get;set;}
    public bool CopyDownstreamNodeOperation {get;set;}
    public Guid OutputModel {get;set;}

    public MergeUpstreamNodeWithDownStreamNode(Guid downStreamModel, Guid upStreamModel, string downStreamNode, string relationalDimension, bool copyUpstreamNodeProperty, bool copyUpsteramNodeOperation, bool copyDownstreamNodeProperty, bool copyDownstreamNodeOperation, Guid outputModel)
    {
        DownStreamModel = downStreamModel;
        UpStreamModel = upStreamModel;
        DownStreamNode = downStreamNode;
        RelationalDimension = relationalDimension;
        CopyUpstreamNodeProperty = copyUpstreamNodeProperty;
        CopyUpsteramNodeOperation = copyUpsteramNodeOperation;
        CopyDownstreamNodeProperty = copyDownstreamNodeProperty;
        CopyDownstreamNodeOperation = copyDownstreamNodeOperation;
        OutputModel = outputModel;
    }
    public MergeUpstreamNodeWithDownStreamNode()
    {
        DownStreamModel = Guid.Empty;
        UpStreamModel = Guid.Empty;
        DownStreamNode = string.Empty;
        RelationalDimension = string.Empty;
        CopyUpstreamNodeProperty = false;
        CopyUpsteramNodeOperation = false;
        CopyDownstreamNodeProperty = false;
        CopyDownstreamNodeOperation = false;
        OutputModel = Guid.Empty;
    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("7c87b1be-a50d-4798-9345-920f9085cc9b"),nameof(MergeUpstreamNodeWithDownStreamNode),"RelationalDimension","Mereg Upstream Node With Downstream Node");
        return builder.AddField(nameof(DownStreamModel),"Downstream Model :", FieldType.InputModel)
                        .AddField(nameof(UpStreamModel),"Upstream Model :",FieldType.InputModel)
                        .AddField(nameof(DownStreamNode),"DownStream Node :",FieldType.InputType)
                        .AddField(nameof(RelationalDimension),"Relational Dimension : ",FieldType.String)
                        .AddField(nameof(CopyUpstreamNodeProperty),"Copy Upstream Node Property :",FieldType.Boolean)
                        .AddField(nameof(CopyUpsteramNodeOperation),"Copy Upsteram Node Operation :",FieldType.Boolean)
                        .AddField(nameof(CopyDownstreamNodeProperty),"Copy DownStream Node Property :",FieldType.Boolean)
                        .AddField(nameof(CopyDownstreamNodeOperation),"Copy DownStream Node Operation :",FieldType.Boolean)
                        .AddField(nameof(OutputModel),"Output Model :", FieldType.OutputModel)
                        .Build();
    }
}

public class MergeUpstreamNodeWithDownStreamNodeHandler : ICommandHandler<MergeUpstreamNodeWithDownStreamNode>
{
    private readonly IDomainModelService _domainModelService;

    public MergeUpstreamNodeWithDownStreamNodeHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MergeUpstreamNodeWithDownStreamNode command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MergeUpstreamNodeWithDownStreamNode command)
    {
        await _domainModelService.MergeUpstreamNodeWithDownStreamNodeAsync(command);
    }
}
