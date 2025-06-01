using System.Text;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Application;
using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;
using MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Core.Builders;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Commands;

public class AppendLineForEachOneToManyRelation : ModelTransformationRequest, ITransformationPattern
{
    public static Guid PatternId => Guid.Parse("95ea4da5-7f6c-4c1b-b6aa-6c70181b4e01");
    public Guid InputModel {get;set;}
    public string Source {get;set;}   
    public string Destination {get;set;}   
    public string SourceToDestinationRelation {get;set;}
    public string TemplateArchiveId {get;set;}
    public string TemplateFileId {get;set;}
    public string Marker {get;set;}
    public string ValueExpression {get;set;}
    public Guid OutputModel {get;set;}
    public string FileConcept {get;set;}
    public string InstanceNameExpression {get;set;}
    public string FileContentProperty {get;set;}    
    public string FileNameProeprty {get;set;}
    public string FileNameValueExpression {get;set;}
    public string FileExtensionProperty {get;set;}
    public string FileExtensionValue {get;set;}
    public string FileRelativePathProeprty {get;set;}
    public string FileRelativePathValue {get;set;}

    public AppendLineForEachOneToManyRelation(Guid inputModel, string source, string destination, string sourceToDestinationRelation, string templateArchive, string templateFile, string marker, string valueExpression, Guid outputModel, string fileConcept, string instanceNameExpression, string fileContentProperty, string fileNameProeprty, string fileNameValueExpression, string fileExtensionProperty, string fileExtensionValue, string fileRelativePathProeprty, string fileRelativePathValue)
    {
        InputModel = inputModel;
        Source = source;
        Destination = destination;
        SourceToDestinationRelation = sourceToDestinationRelation;
        TemplateArchiveId = templateArchive;
        TemplateFileId = templateFile;
        Marker = marker;
        ValueExpression = valueExpression;
        OutputModel = outputModel;
        FileConcept = fileConcept;
        InstanceNameExpression = instanceNameExpression;
        FileContentProperty = fileContentProperty;
        FileNameProeprty = fileNameProeprty;
        FileNameValueExpression = fileNameValueExpression;
        FileExtensionProperty = fileExtensionProperty;
        FileExtensionValue = fileExtensionValue;
        FileRelativePathProeprty = fileRelativePathProeprty;
        FileRelativePathValue = fileRelativePathValue;
    }

    public AppendLineForEachOneToManyRelation(){
        InputModel = Guid.Empty;
        Source = string.Empty;
        Destination = string.Empty;
        SourceToDestinationRelation = string.Empty;
        TemplateArchiveId = string.Empty;
        TemplateFileId = string.Empty;
        Marker = string.Empty;
        ValueExpression = string.Empty;
        OutputModel = Guid.Empty;
        FileConcept = string.Empty;
        InstanceNameExpression = string.Empty;
        FileContentProperty = string.Empty;
        FileNameProeprty = string.Empty;
        FileNameValueExpression = string.Empty;
        FileExtensionProperty = string.Empty;
        FileExtensionValue = string.Empty;
        FileRelativePathProeprty = string.Empty;
        FileRelativePathValue = string.Empty;
    }
    public Pattern Specification()
    {
        IPatternBuilder builder = PatternBuilder.Create(AppendLineForEachOneToManyRelation.PatternId,nameof(AppendLineForEachOneToManyRelation),"Object2Object","Append Line To The Template For Each One to Many Relation");
        return builder.AddField(nameof(InputModel),"Input Model :", FieldType.InputModel)
                        .AddField(nameof(OutputModel),"Output Model :",FieldType.OutputModel)
                        .AddField(nameof(Source),"Source Node :",FieldType.InputType)
                        .AddField(nameof(Destination),"Destination Node :",FieldType.InputType)
                        .AddField(nameof(SourceToDestinationRelation),"Source-to-Destination Relation :",FieldType.InputTypeRelation)
                        .AddField(nameof(TemplateArchiveId),"Template Archive Id: ",FieldType.String)
                        .AddField(nameof(TemplateFileId),"Template File Id: ",FieldType.String)
                        .AddField(nameof(Marker),"Marker : ",FieldType.String)
                        .AddField(nameof(ValueExpression),"Content Value Expression : ",FieldType.InputTypeExpression)
                        .AddField(nameof(FileConcept),"File Concept :",FieldType.OutputType)
                        .AddField(nameof(FileNameProeprty),"File Name Property :",FieldType.OutputTypeProperty)
                        .AddField(nameof(FileExtensionProperty),"File Extension Property :",FieldType.OutputTypeProperty)
                        .AddField(nameof(FileRelativePathProeprty),"File Relative Path Property :",FieldType.OutputTypeProperty)
                        .AddField(nameof(FileContentProperty),"File Content Property :",FieldType.OutputTypeProperty)
                        .AddField(nameof(InstanceNameExpression),"Instance Name Expression:",FieldType.InputTypeExpression)
                        .AddField(nameof(FileNameValueExpression),"File Name Value:",FieldType.InputTypeExpression)
                        .AddField(nameof(FileExtensionValue),"File Extension Value:",FieldType.String)
                        .AddField(nameof(FileRelativePathValue),"File Relative Path Value:",FieldType.String)

                        .Build();
    }
}
public class AppendLineForEachOneToManyRelationHandler : ICommandHandler<AppendLineForEachOneToManyRelation>
{
    private IDomainModelReader _reader;
    private ITemplateFileManager _templateFileManager;
    private IDomainModelWriter _writer;


    public AppendLineForEachOneToManyRelationHandler(IDomainModelReader reader, ITemplateFileManager templateFileManager, IDomainModelWriter writer)
    {
        _reader = reader;
        _templateFileManager = templateFileManager;
        _writer = writer;
    }

    public void Handle(AppendLineForEachOneToManyRelation command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(AppendLineForEachOneToManyRelation command)
    {
        var templateContent = await _templateFileManager.GetFileContentAsync(command.TemplateArchiveId,command.TemplateFileId);

        var sourceInstances = await _reader.GetDomainObjectsAsync(command.InputModel,command.Source);
        var destinationInstances = await _reader.GetDomainObjectsAsync(command.InputModel,command.Destination);

        if(sourceInstances == null  || destinationInstances==null)
            return;
        
        foreach(var source in sourceInstances)
        {
            var relation = source.Relations.Where(rel=>rel.RelationName.ToLower() == command.SourceToDestinationRelation.ToLower() && rel.RelationTarget.ToLower() == command.Destination.ToLower()).FirstOrDefault();
            if(relation==null)            
                continue;
            
            var relationTargetInstances = relation.TargetInstances.Select(targetInstance=>targetInstance.Trim().ToLower()).ToList();
            if(relationTargetInstances == null)
                continue;

            var destinationObjects = destinationInstances.Where(instance=>relationTargetInstances.Contains(instance.FullName.ToLower().Trim())).ToList();

            await InterpolateTemplateAndUpdateContent(templateContent,source,destinationObjects,command);
        }

    }

    private async Task InterpolateTemplateAndUpdateContent(string templateContent,  DomainObjectDto source, List<DomainObjectDto> destinationObjects, AppendLineForEachOneToManyRelation command)
    {
        Dictionary<string,string> keyValues = new();        
        StringBuilder builder;
        string content = string.Empty;

        if(source == null || destinationObjects==null)
            return;

        
        builder = new StringBuilder();
        var sourceKeyValues = source.ToKeyValueExpressionResolver("Source");        
        foreach(var domainObject in destinationObjects)
        {
            keyValues.Clear();
            keyValues = domainObject.ToKeyValueExpressionResolver("Destination")
                                    .AppendKeyValues(sourceKeyValues);
                                    
            var value = command.ValueExpression.ResolveExpression(keyValues);
            Console.WriteLine($"Value is {value}");
            builder.AppendLine(value);
        }
        content = builder.ToString();
        if(content==string.Empty)
        {
            content = templateContent;
        }            
        else 
        {
            char[] delims = new[] { '\r', '\n' };
            var templateContentLines = templateContent.Split(delims).ToList();

            var index = templateContentLines.FindIndex(line => line.ToLower().Contains(command.Marker.ToLower()));
            var count = templateContentLines.Count;
            Console.WriteLine($"Index is {index}");
            if(index>=0 && index<count)
                templateContentLines.Insert(index,content);            
            else if(index == count && index>0)
                templateContentLines.Insert(index-1,content);   
            
            builder = new StringBuilder();
            templateContentLines.ForEach(line=> builder.AppendLine(line));
            content = builder.ToString();
        }

        var instanceName = command.InstanceNameExpression.ResolveExpression(sourceKeyValues);
        var fileNameValue = command.FileNameValueExpression.ResolveExpression(sourceKeyValues);
        List<ProeprtyValueDto> propValues = new();
        
        propValues.Add(new ProeprtyValueDto(command.FileNameProeprty,fileNameValue));
        propValues.Add(new ProeprtyValueDto(command.FileExtensionProperty,command.FileExtensionValue));
        propValues.Add(new ProeprtyValueDto(command.FileContentProperty,content));
        propValues.Add(new ProeprtyValueDto(command.FileRelativePathProeprty,command.FileRelativePathValue));                

        var request = new CreateOrUpdateInstanceRequest(command.OutputModel,instanceName,command.FileConcept,propValues,command.CoordinationId,command.StepId);    
        await _writer.TryCreateOrUpdateInstanceAsync(request);        
    }
}
