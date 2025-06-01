using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;
using MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

namespace MDDPlatform.ModelTransformations.Application.Patterns.ModelToText;

public class GenerateCSharpCodeOfClassConcept : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("851968c9-de6e-451e-9f61-16abee4c9cf4");
    public Guid DownstreamModel {get;set;}
    public Guid UpstreamModel {get;set;}
    public string DownstreamNode {get;set;}
    public string RelationalDimension {get;set;}
    public string ContentProperty {get;set;}

    public GenerateCSharpCodeOfClassConcept(Guid downstreamModel, Guid upstreamModel, string downstreamNode, string relationalDimension, string contentProperty)
    {
        DownstreamModel = downstreamModel;
        UpstreamModel = upstreamModel;
        DownstreamNode = downstreamNode;
        RelationalDimension = relationalDimension;
        ContentProperty = contentProperty;
    }

    public GenerateCSharpCodeOfClassConcept()
    {
        DownstreamModel = Guid.Empty;
        UpstreamModel = Guid.Empty;
        DownstreamNode = string.Empty;
        RelationalDimension = string.Empty;
        ContentProperty = string.Empty;
    }

    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(GenerateCSharpCodeOfClassConcept.PatternId,nameof(GenerateCSharpCodeOfClassConcept),"RelationalDimension","Generate C# Code Of Class Concepts");
        return builder.AddField(nameof(DownstreamModel),"Downstream Model :", FieldType.InputModel)
                        .AddField(nameof(UpstreamModel),"Upstream Model :",FieldType.InputModel)
                        .AddField(nameof(DownstreamNode),"DownStream Node :",FieldType.InputType)
                        .AddField(nameof(RelationalDimension),"Relational Dimension : ",FieldType.String)
                        .AddField(nameof(ContentProperty),"Text Content Property :",FieldType.OutputTypeProperty)
                        .Build();
    }

}
public class GenerateCSharpCodeOfClassConceptHandler : ICommandHandler<GenerateCSharpCodeOfClassConcept>
{
    private IDomainModelReader _reader;
    private IDomainModelWriter _writer;
    private ITextGenerator _textGenerator;

    public GenerateCSharpCodeOfClassConceptHandler(IDomainModelReader reader, IDomainModelWriter writer, ITextGenerator textGenerator)
    {
        _reader = reader;
        _writer = writer;
        _textGenerator = textGenerator;
    }

    public void Handle(GenerateCSharpCodeOfClassConcept command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(GenerateCSharpCodeOfClassConcept command)
    {
        var modelElements = await _reader.GetDomainModelElementsAsync(command.UpstreamModel);
        var domainObjects = await _reader.GetDomainObjectsAsync(command.DownstreamModel,command.DownstreamNode);
        
        if(modelElements == null || domainObjects == null)
            return;

        var instances =  new List<InstanceProperties>();
        foreach(var domainObject in domainObjects)
        {
            var relationalDimension = domainObject.RelationalDimensions.Where(rel=>rel.Name.ToLower().Trim() == command.RelationalDimension.ToLower().Trim()).FirstOrDefault();
            if(relationalDimension == null)
                continue;
            var targetElement = modelElements.Elements.Where(element=>element.FullName.ToLower().Trim() == relationalDimension.Target.Trim().ToLower()).FirstOrDefault();
            if(targetElement == null)
                continue;
            var content = _textGenerator.ClassToText(targetElement);
            
            var propValues = new List<ProeprtyValueDto>();
            propValues.Add(new ProeprtyValueDto(command.ContentProperty,content));

            instances.Add(new InstanceProperties(domainObject.InstanceName,domainObject.InstanceType,propValues));
        }
        // if(instances.Count>0)
        // {
        //     var request = new CreateOrUpdateInstancesRequest(command.DownstreamModel,instances,command.CoordinationId,command.StepId);
        //     await _writer.TryCreateOrUpdateInstancesAsync(request);
        // }
        var request = new CreateOrUpdateInstancesRequest(command.DownstreamModel,instances,command.CoordinationId,command.StepId);
        await _writer.TryCreateOrUpdateInstancesAsync(request);
    }

}
