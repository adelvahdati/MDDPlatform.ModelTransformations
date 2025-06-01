using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class PatternTemplateDocument
{
    public Guid PatternId {get;set;}
    public string PatternName {get;set;}

    public PatternTemplateDocument(Guid patternId, string patternName)
    {
        PatternId = patternId;
        PatternName = patternName;
    }
    public static PatternTemplateDocument CreateFrom(PatternTemplate patternTemplate){
        return new PatternTemplateDocument(patternTemplate.PatternId,patternTemplate.PatternName);
    }

    public PatternTemplate ToPatternTemplate(){
        return new PatternTemplate(PatternId,PatternName);
    }
}