using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class ActivityDocument : BaseEntity<Guid> 
{
    public string Title {get;set;}
    public List<WorkUnitDocument> Tasks {get;set;}

    public ActivityDocument(Guid id,string title, List<WorkUnitDocument> tasks)
    {
        Id = id;
        Title = title;
        Tasks = tasks;
    }
    public static ActivityDocument CreateFrom(Activity activity)
    {
        var tasks = activity.Tasks.Select(task=>WorkUnitDocument.CreateFrom(task)).ToList();
        return new ActivityDocument(activity.Id,activity.Title,tasks);
    }
    public Activity ToActivity()
    {
        var tasks = Tasks.Select(task=>task.ToWorkUnit()).ToList();
        return Activity.Load(Id,Title,tasks);
    }
}