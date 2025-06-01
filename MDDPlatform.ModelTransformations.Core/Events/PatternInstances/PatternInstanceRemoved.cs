using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.ModelTransformations.Core.Events;
public class PatternInstanceRemoved : IDomainEvent
{
    public Guid PatternInstanceId {get;set;}

    public PatternInstanceRemoved(Guid patternInstanceId)
    {
        PatternInstanceId = patternInstanceId;
    }
}