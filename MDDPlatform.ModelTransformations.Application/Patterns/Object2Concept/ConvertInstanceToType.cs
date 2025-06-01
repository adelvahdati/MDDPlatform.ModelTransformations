using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
/*
    Example : Convert DomainObjects to DomainConcepts
        TypeOfInstance : type of DomainObject
        PreserverType : true -> new DomainConcept has the same type of DomainObject
                        false -> the type of new DomainConcept is Concept
        PreserverProperty : true -> new DomainConcept has the same property of DomainObject type
                            false -> The properties of DomainObject's type doese not transfer into new DomainConcept
        
        PreserveRelation & PreserverOperation is interpreted in the same way
    
    Conceret Example :
        Input Model : CRAC model
        TypeOfInstance : Command.Concept
        OutputModel : BaseConcept (Built-in)

    Transformation Result :
        PreserverType : true -> 'CreateOrder' concept of type 'Command.Concept'
                        false -> 'CreateOrder' concept of type 'Concept'

    -------------------------------------------------
    TypeOfInstance can be '*' that meanse convert everything
    TypeOfInstance can be sereral types separated by ','
        
*/

public class ConvertInstanceToType : ModelTransformationRequest, ITransformationPattern

{
    public static Guid PatternId => Guid.Parse("cb4efb0c-9c59-4e39-9506-ee285aa36a80");
    public Guid InputModel {get;set;}
    public string TypeOfInstance {get;set;}
    public Guid  OutputModel {get;set;}
    public bool PreserveType {get;set;}
    public bool PreserveProperties {get;set;}
    public bool PreserveRelations {get;set;}
    public bool PreserveOperations {get;set;}

    internal ConvertInstanceToType()
    {
        InputModel = Guid.Empty;
        TypeOfInstance = string.Empty;
        OutputModel = Guid.Empty;
        PreserveType = false;
        PreserveProperties = false;
        PreserveRelations = false;        
    }
    public ConvertInstanceToType(Guid inputModel, string typeOfInstance, Guid outputModel, bool preserveType, bool preserveProperties, bool preserveRelations, bool preserveOperations)
    {
        InputModel = inputModel;
        TypeOfInstance = typeOfInstance;
        OutputModel = outputModel;
        PreserveType = preserveType;
        PreserveProperties = preserveProperties;
        PreserveRelations = preserveRelations;
        PreserveOperations = preserveOperations;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(Guid.Parse("cb4efb0c-9c59-4e39-9506-ee285aa36a80"),nameof(ConvertInstanceToType),"Object2Concept","Convert DomainObjects to DomainConcepts");
        return builder.AddField(nameof(InputModel),"Input model",FieldType.InputModel)
                .AddField(nameof(TypeOfInstance),"Type of instance",FieldType.InputType)
                .AddField(nameof(PreserveProperties),"Preserve properties",FieldType.Variability)
                .AddField(nameof(PreserveRelations),"Preserve relations",FieldType.Variability)
                .AddField(nameof(PreserveOperations),"Preserve operations",FieldType.Variability)
                .AddField(nameof(OutputModel),"Output model",FieldType.OutputModel)
                .Build();
    }
}
public class ConvertInstanceToTypeHandler : ICommandHandler<ConvertInstanceToType>
{
    private readonly IDomainModelService _domainModelService;

    public ConvertInstanceToTypeHandler(IDomainModelService domainModelService)
    {
        _domainModelService = domainModelService;
    }

    public void Handle(ConvertInstanceToType command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(ConvertInstanceToType command)
    {
        await _domainModelService.ConvertInstanceToTypeAsync(command);
    }
}
