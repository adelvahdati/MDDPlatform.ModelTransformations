using System.Runtime.InteropServices;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
public class SetHigherDimensionRelation : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId  => Guid.Parse("6634fbe3-541e-4100-b8d1-1473bf3fcf5d");
    public string UpstreamConcept {get;set;}    // Command.Concept,Event.Concept,CommandHandler.Concept,EventHandler.Concept
    public string DownstreamConcept {get;set;}  // BaseClass.Concept
    public string RelationNameExpression {get;set;} // represent
    public string RelationTargetExpression {get;set;} // UpstreamConcept.Name+.+UpstreamConcept._Type
    public Guid UpstreamModel {get;set;}
    public Guid DownstreamModel {get;set;}

    public SetHigherDimensionRelation(string upstreamConcept, string downstreamConcept, string relationNameExpression, string relationTargetExpression, Guid upstreamModel, Guid downstreamModel)
    {
        UpstreamConcept = upstreamConcept;
        DownstreamConcept = downstreamConcept;
        RelationNameExpression = relationNameExpression;
        RelationTargetExpression = relationTargetExpression;
        UpstreamModel = upstreamModel;
        DownstreamModel = downstreamModel;
    }
    public SetHigherDimensionRelation()
    {
        UpstreamConcept = string.Empty;
        DownstreamConcept = string.Empty;
        RelationNameExpression = string.Empty;
        RelationTargetExpression = string.Empty;
        UpstreamModel = Guid.Empty;
        DownstreamModel = Guid.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder build = PatternBuilder.Create(SetHigherDimensionRelation.PatternId,nameof(SetHigherDimensionRelation),"RelationalDimension","Set Higher Dimension Relation");
        return build.AddField(nameof(UpstreamModel),"Upstream Model :",FieldType.InputModel)
                    .AddField(nameof(DownstreamModel),"Downstream Model :",FieldType.OutputModel)
                    .AddField(nameof(UpstreamConcept),"Upstream Concept :",FieldType.InputType)
                    .AddField(nameof(DownstreamConcept),"DownstreamConcept :",FieldType.OutputType)
                    .AddField(nameof(RelationNameExpression),"Relation Name Expression :",FieldType.InputTypeExpression)
                    .AddField(nameof(RelationTargetExpression),"Relation Target Expression :", FieldType.InputTypeExpression)
                    .Build();
    }
}
public class SetHigherDimensionRelationHandler : ICommandHandler<SetHigherDimensionRelation>
{
    private readonly IDomainModelService _domainModelService;

    public SetHigherDimensionRelationHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(SetHigherDimensionRelation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(SetHigherDimensionRelation command)
    {
        Console.WriteLine("Start  SetHigherDimensionRelation Handling");
        await _domainModelService.SetHigherDimensionRelationAsync(command);
    }
}