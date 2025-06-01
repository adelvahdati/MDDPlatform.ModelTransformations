using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class PatternInstanceTemplateDto
{
    public Guid Id {get;set;}
    public Guid PatternId {get; set;}
    public string PatternName {get; set;}
    public string PatternCategory {get; set;}
    public string Title {get; set;}
    public string Name {get; set;}
    public List<FieldValueDto> FieldValues {get;set;}
    public List<FieldDto> Variables {get;set;}

    public PatternInstanceTemplateDto(Guid id, Guid patternId, string patternName, string patternCategory, string title, string name, List<FieldValueDto> fieldValues, List<FieldDto> variables)
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

    public static PatternInstanceTemplateDto CreateFrom(PatternInstanceTemplate template)
    {
        var fieldValues = template.FieldValues.Select(fv=>FieldValueDto.CreateFrom(fv)).ToList();
        var variables = template.Variables.Select(f=>FieldDto.CreateFrom(f)).ToList();
        return new PatternInstanceTemplateDto(template.Id,
                                                template.PatternId,
                                                template.PatternName,
                                                template.PatternCategory,
                                                template.Title,
                                                template.Name,
                                                fieldValues,
                                                variables);
    }
    public PatternInstanceTemplate ToPatternInstanceTemplate()
    {
        var fieldValues = FieldValues.Select(fvDto=>fvDto.ToFieldValue()).ToList();
        var variables = Variables.Select(fDto=>fDto.ToField()).ToList();
        return PatternInstanceTemplate.Load(Id,
                                            PatternId,
                                            PatternName,
                                            PatternCategory,
                                            Title,
                                            Name,
                                            fieldValues,
                                            variables);
    }
}