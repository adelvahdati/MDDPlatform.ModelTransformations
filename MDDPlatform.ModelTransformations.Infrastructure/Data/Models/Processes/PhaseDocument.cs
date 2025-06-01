using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class PhaseDocument : BaseEntity<Guid>
{
    public string Title {get; set;}
    public List<ActivityDocument> Activities {get;set;}

    public PhaseDocument(Guid id,string title, List<ActivityDocument> activities)
    {
        Id = id;
        Title = title;
        Activities = activities;
    }
    public static PhaseDocument CreateFrom(Phase phase)
    {
        var activities = phase.Activities.Select(act=>ActivityDocument.CreateFrom(act)).ToList();
        return new PhaseDocument(phase.Id,phase.Title,activities);
    }
    public Phase ToPhase()
    {
        var activities = Activities.Select(act=>act.ToActivity()).ToList();
        return Phase.Load(Id,Title,activities);
    }
}