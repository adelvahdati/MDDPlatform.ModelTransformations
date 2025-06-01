using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class PatternInstanceDto
{
    public Guid ProblemDomainId {get;set;}
    public Guid Id {get;set;}
    public string Title {get;set;}
    public string Name {get; set;}
    public Guid PatternId {get;set;}
    public string PatternName {get;set;}
    public List<FieldValueDto> FieldValues {get;set;}

    public PatternInstanceDto(Guid id, string title, string name, Guid patternId, string patternName, List<FieldValueDto> fieldValues,Guid problemDomainId)
    {
        ProblemDomainId = problemDomainId;
        Id = id;
        Title = title;
        Name = name;
        PatternId = patternId;
        PatternName = patternName;
        FieldValues = fieldValues;
    }
    public static PatternInstanceDto CreateFrom(PatternInstance patternInstance)
    {
        var fieldValues = patternInstance.FieldValues
                                            .Select(fieldValue=>FieldValueDto.CreateFrom(fieldValue))
                                            .ToList();
        return new(patternInstance.Id,
                    patternInstance.Title,
                    patternInstance.Name,
                    patternInstance.Template.PatternId,
                    patternInstance.Template.PatternName,
                    fieldValues,
                    patternInstance.ProblemDomainId);
    }
}