using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class Phase : BaseEntity<Guid>
{
    private List<Activity> _activities = new();

    public string Title {get;private set;}
    public IReadOnlyList<Activity> Activities => _activities;

    public IReadOnlyList<WorkUnit> WorkUnits => _activities.SelectMany(activity=> activity.Tasks).ToList();

    private Phase(Guid id,string title,List<Activity> activities)
    {
        Id = id;
        _activities = activities;
        Title = title;
    }
    private Phase(string title,List<Activity> activities)
    {
        Id = Guid.NewGuid();
        _activities = activities;
        Title = title;
    }
    private Phase(string title){
        Id = Guid.NewGuid();
        Title = title;
        _activities = new();
    }

    public static Phase Create(string title)
    {
        return new Phase(title);
    }
    public static Phase Create(string title,List<string> activities)
    {
        var acts = new List<Activity>();
        foreach(var activity in activities)
        {
            acts.Add(Activity.Create(activity));            
        }
        return new Phase(title,acts);
    }
    public static Phase Load(Guid id, string title, List<Activity> activities)
    {
        return new Phase(id,title,activities);
    }

    public void CreateActivity(string title)
    {
        var activity = Activity.Create(title);
        _activities.Add(activity);
    }
    public void CreateActivity(Activity activity){
        _activities.Add(activity);
    }

    internal void CreateTask(Guid activityId, WorkUnit task)
    {
        var activity = _activities.SingleOrDefault(act=>act.Id == activityId);
        if(Equals(activity,null))
            throw new Exception("Activity Not Found");
        
        activity.CreateTask(task);
    }

    internal void DeleteActivity(Guid activityId)
    {
        _activities.RemoveAll(activity=>activity.Id ==activityId);
    }

    internal void DeleteTask(Guid activityId, Guid taskId)
    {
        var activity = _activities.SingleOrDefault(act=>act.Id == activityId);
        if(Equals(activity,null))
            throw new Exception("Activity Not Found");
        
        activity.DeleteTask(taskId);
    }
}
