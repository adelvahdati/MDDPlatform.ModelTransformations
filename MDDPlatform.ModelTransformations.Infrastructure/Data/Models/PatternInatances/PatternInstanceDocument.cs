using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class PatternInstanceDocument : BaseEntity<Guid>
{
    public Guid ProblemDomainId {get; private set;}
    public string Title {get;private set;}
    public string Name {get;private set;}
    public PatternTemplateDocument Template {get; private set;}
    public List<FieldValueDocument> FieldValues {get;set;}

    public PatternInstanceDocument(Guid id, string title, string name, PatternTemplateDocument template, List<FieldValueDocument> fieldValues,Guid problemDomainId)
    {
        Id =id;
        Title = title;
        Name = name;
        Template = template;
        FieldValues = fieldValues;
        ProblemDomainId = problemDomainId;
    }
    public static PatternInstanceDocument CreateFrom(PatternInstance patternInstance)
    {
        PatternTemplateDocument template = PatternTemplateDocument.CreateFrom(patternInstance.Template);

        List<FieldValueDocument> fieldValues = patternInstance.FieldValues
                                                                .Select(fieldValue=>FieldValueDocument.CreateFrom(fieldValue))
                                                                .ToList();
        return new PatternInstanceDocument(patternInstance.Id,
                                            patternInstance.Title,
                                            patternInstance.Name,
                                            template,
                                            fieldValues,
                                            patternInstance.ProblemDomainId);
    }
    public PatternInstance ToPatternInstance()
    {
        PatternTemplate template = Template.ToPatternTemplate();
        var fieldValues = FieldValues.Select(fieldValueDocument=> fieldValueDocument.ToFieldValue())
                                        .ToList();
        return PatternInstance.Load(Id,Title,Name,template,fieldValues,ProblemDomainId);
    }
}