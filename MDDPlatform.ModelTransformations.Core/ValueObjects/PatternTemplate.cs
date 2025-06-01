using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class PatternTemplate : ValueObject
{
    public Guid PatternId {get;set;}
    public string PatternName {get;set;}

    public PatternTemplate(Guid patternId, string patternName)
    {
        PatternId = patternId;
        PatternName = patternName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PatternId;
        yield return PatternName;
    }

    internal static PatternTemplate CreateFrom(Pattern pattern)
    {
        return new PatternTemplate(pattern.Id,pattern.Name);
    }
}