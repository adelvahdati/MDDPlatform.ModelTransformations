using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class Process : BaseEntity<Guid>
{
    private List<Phase> _phases = new();

    public string Title {get;private set;}

    public IReadOnlyList<Phase> Phases => _phases;
    public IReadOnlyList<WorkUnit> WorkUnits => _phases.SelectMany(phase=>phase.WorkUnits).ToList();

    private Process(Guid id,string title,List<Phase> phases)
    {
        Id = id;
        _phases = phases;
        Title = title;
    }
    private Process(string title,List<Phase> phases)
    {
        Id = Guid.NewGuid();
        _phases = phases;
        Title = title;
    }
    private Process(string title){
        Id = Guid.NewGuid();
        Title = title;
        _phases = new();
    }
    private Process(Guid processId, string title){
        Id = processId;
        Title = title;
        _phases = new();
    }
    public static Process Create(string title)
    {
        return new Process(title);
    }
    public static Process Create(Guid processId, string title)
    {
        return new Process(processId,title);
    }
    public static Process Load(Guid id, string title, List<Phase> phases)
    {
        return new Process(id,title,phases);
    }

    public void AddPhase(string title)
    {
        Phase phase  = Phase.Create(title);
        _phases.Add(phase);
    }
    public void AddPhase(Phase phase)
    {        
        _phases.Add(phase);
    }

    public void CreateActivity(Guid phaseId, string title)
    {
        var phase = _phases.SingleOrDefault(p=>p.Id == phaseId);
        if(Equals(phase,null))
            throw new Exception("Phase Not Found");
        
        phase.CreateActivity(title);
    }
    public void CreateActivity(Guid phaseId, Activity activity)
    {
        var phase = _phases.SingleOrDefault(p=>p.Id == phaseId);
        if(Equals(phase,null))
            throw new Exception("Phase Not Found");
        
        phase.CreateActivity(activity);
    }

    public void CreateTask(Guid phaseId,Guid activityId,WorkUnit task)
    {
        var phase = _phases.SingleOrDefault(p=>p.Id == phaseId);
        if(Equals(phase,null))
            throw new Exception("Phase Not Found");

        phase.CreateTask(activityId,task);
    }

    public void DeletePhase(Guid phaseId)
    {
        _phases.RemoveAll(phase => phase.Id == phaseId);
    }

    public void DeleteActivity(Guid phaseId, Guid activityId)
    {        
        var phase = _phases.Find(phase=>phase.Id == phaseId);
        if(Equals(phase,null))
            return;
        
        phase.DeleteActivity(activityId);

    }

    public void DeleteTask(Guid phaseId, Guid activityId, Guid taskId)
    {
        var phase = _phases.Find(phase=>phase.Id == phaseId);
        if(Equals(phase,null))
            return;
        
        phase.DeleteTask(activityId,taskId);
    }
}