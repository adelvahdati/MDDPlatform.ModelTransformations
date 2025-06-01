
namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class NewPatternInstanceDto
{
    public Guid ProblemDomainId {get;set;}
    public string Title {get;private set;}
    public string Name {get;private set;}
    public Guid PatternId {get;set;}
    public string PatternName {get;set;}
    public List<FieldValueDto> FieldValues {get;set;}

    public NewPatternInstanceDto(string title, string name, Guid patternId, string patternName, List<FieldValueDto> fieldValues, Guid problemDomainId )
    {
        ProblemDomainId = problemDomainId;
        Title = title;
        Name = name;
        PatternId = patternId;
        PatternName = patternName;
        FieldValues = fieldValues;
    }
}