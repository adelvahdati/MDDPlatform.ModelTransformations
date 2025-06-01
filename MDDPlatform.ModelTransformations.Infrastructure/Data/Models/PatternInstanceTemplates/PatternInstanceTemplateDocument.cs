using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class PatternInstanceTemplateDocument : BaseEntity<Guid>
{
    public Guid PatternId {get;private set;}
    public string PatternName {get;private set;}
    public string PatternCategory {get;private set;}
    public string Title {get;private set;}
    public string Name {get;private set;}
    public List<FieldValueDocument> FieldValues {get;private set;}
    public List<FieldDocument> Variables {get;private set;}

    public PatternInstanceTemplateDocument(Guid id,Guid patternId, string patternName, string patternCategory, string title, string name, List<FieldValueDocument> fieldValues, List<FieldDocument> variables)
    {
        Id = id;
        PatternId = patternId;
        PatternName = patternName;
        PatternCategory = patternCategory;
        Title = title;
        Name = name;
        FieldValues = fieldValues;
        Variables = variables;
    }

    public static PatternInstanceTemplateDocument CreateFrom(PatternInstanceTemplate template)
    {
        List<FieldValueDocument> fieldValues = 
            template.FieldValues
                .Select(fieldValue=>FieldValueDocument.CreateFrom(fieldValue))
                .ToList();

        var variables = template.Variables
                            .Select(field=> FieldDocument.CreateFrom(field))
                            .ToList();

        return new PatternInstanceTemplateDocument(
            template.Id,
            template.PatternId,
            template.PatternName,
            template.PatternCategory,
            template.Title,
            template.Name,
            fieldValues,
            variables
        );                
    }

    public PatternInstanceTemplate ToPatternInstanceTemplate()
    {
        var variables = Variables.Select(fieldDocument=> fieldDocument.ToField()).ToList();
        var fieldValues = FieldValues
                            .Select(fieldValueDocument=> fieldValueDocument.ToFieldValue())
                            .ToList();
        

        return PatternInstanceTemplate.Load(
            Id,
            PatternId,
            PatternName,
            PatternCategory,
            Title,
            Name,
            fieldValues,
            variables
        );
    }
}