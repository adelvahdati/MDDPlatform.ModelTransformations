using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
public class MergerDomainObjectModels : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId =>Guid.Parse("1edb869c-d616-4600-b68b-09cb795ca22b");
    public Guid FirstModel {get;set;}
    public Guid SecondModel {get;set;}
    public Guid OutputModel {get;set;}

    public MergerDomainObjectModels(Guid firstModel, Guid secondModel, Guid outputModel)
    {
        FirstModel = firstModel;
        SecondModel = secondModel;
        OutputModel = outputModel;
    }
    public MergerDomainObjectModels(){
        FirstModel = Guid.Empty;
        SecondModel = Guid.Empty;
        OutputModel = Guid.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(MergerDomainObjectModels.PatternId,nameof(MergerDomainObjectModels),"Object2Object","Merge Domain Objects Model");
        return builder.AddField(nameof(FirstModel),"First Model :",FieldType.InputModel)
                        .AddField(nameof(SecondModel),"Second Model :",FieldType.InputModel)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .Build();
    }
}
public class MergerDomainObjectModelsHandler : ICommandHandler<MergerDomainObjectModels>
{
    private readonly IDomainModelService _domainModelService;

    public MergerDomainObjectModelsHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(MergerDomainObjectModels command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(MergerDomainObjectModels command)
    {
        await _domainModelService.MergerDomainObjectModelsAsync(command);
    }
}
