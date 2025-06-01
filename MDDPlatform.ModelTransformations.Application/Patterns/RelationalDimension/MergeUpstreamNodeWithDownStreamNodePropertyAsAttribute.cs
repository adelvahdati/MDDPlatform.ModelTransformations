using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
public class MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("8364270a-a824-4952-9aad-db04755bd8b1");
    public Guid DownStreamModel { get; set; }
    public Guid UpStreamModel { get; set; }
    public string DownStreamNode { get; set; } // In downstream model
    public string RelationalDimension { get; set; }
    public Guid OutputModel {get;set;}
    public MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute(Guid downStreamModel, Guid upStreamModel, string downStreamNode, string relationalDimension, Guid outputModel)
    {
        DownStreamModel = downStreamModel;
        UpStreamModel = upStreamModel;
        DownStreamNode = downStreamNode;
        RelationalDimension = relationalDimension;
        OutputModel = outputModel;
    }
    public MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute()
    {
        DownStreamModel = Guid.Empty;
        UpStreamModel = Guid.Empty;
        DownStreamNode = string.Empty;
        RelationalDimension = string.Empty;
        OutputModel = Guid.Empty;
    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("8364270a-a824-4952-9aad-db04755bd8b1"),nameof(MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute),"RelationalDimension","Mereg Upstream Node With Downstream Node Properties As Attributes");
        return builder.AddField(nameof(DownStreamModel),"Downstream Model :", FieldType.InputModel)
                        .AddField(nameof(UpStreamModel),"Upstream Model :",FieldType.InputModel)
                        .AddField(nameof(DownStreamNode),"DownStream Node :",FieldType.InputType)
                        .AddField(nameof(RelationalDimension),"Relational Dimension : ",FieldType.String)
                        .AddField(nameof(OutputModel),"Output Model :", FieldType.OutputModel)
                        .Build();
    }
}

public class MergeUpstreamNodeWithDownStreamNodePropertyAsAttributeHandler : ICommandHandler<MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute>
{
    private readonly IDomainModelService _domainModelService;

    public MergeUpstreamNodeWithDownStreamNodePropertyAsAttributeHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute command)
    {
        await _domainModelService.MergeUpstreamNodeWithDownStreamNodePropertyAsAttributeAsync(command);
    }
}
