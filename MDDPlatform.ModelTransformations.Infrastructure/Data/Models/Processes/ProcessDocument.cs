using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class ProcessDocument : BaseEntity<Guid>
{
    public string Title {get;set;}
    public List<PhaseDocument> Phases {get;set;}

    public ProcessDocument(Guid id,string title, List<PhaseDocument> phases)
    {
        Id = id;
        Title = title;
        Phases = phases;
    }
    public static ProcessDocument CreateFrom(Process process)
    {
        var phases = process.Phases.Select(phase=>PhaseDocument.CreateFrom(phase)).ToList();
        return new ProcessDocument(process.Id,process.Title,phases);

    }
    public Process ToProcess()
    {
        var phases = Phases.Select(phaseDoc=>phaseDoc.ToPhase()).ToList();
        return Process.Load(Id,Title,phases);
    }
}