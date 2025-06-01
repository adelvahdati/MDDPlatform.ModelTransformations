using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class SetRelationalDimension : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("aea985a8-89b7-414c-959e-a769fb2017b0");
    public Guid InputModel {get;set;}
    public string Element {get;set;}
    public string RelationNameExpression {get;set;}
    public string RelationTargetExpression {get;set;}

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(SetRelationalDimension.PatternId,nameof(SetRelationalDimension),"Object2Object","Set Relational Dimension");
        return builder.AddField(nameof(InputModel),"Input Model :", FieldType.InputModel)
                .AddField(nameof(Element),"Element : ",FieldType.InputType)
                .AddField(nameof(RelationNameExpression),"Relation Name Expression :",FieldType.InputTypeExpression)
                .AddField(nameof(RelationTargetExpression),"Relation Target Expressions :",FieldType.InputTypeExpression)
                .Build();
    }
}
public class SetRelationalDimensionHandler : ICommandHandler<SetRelationalDimension>
{
    private readonly IDomainModelService _domainModelService;

    public SetRelationalDimensionHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(SetRelationalDimension command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(SetRelationalDimension command)
    {
        await _domainModelService.SetRelationalDimensionAsync(command);        
    }
}
