using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class Activity : BaseEntity<Guid>
{
    private List<WorkUnit> _tasks = new();

    public string Title {get; private set;}

    public IReadOnlyList<WorkUnit> Tasks => _tasks;

    private Activity(Guid id,string title,List<WorkUnit> tasks)
    {
        Id= id;
        _tasks = tasks;
        Title = title;
    }
    private Activity(string title,List<WorkUnit> tasks)
    {
        Id= Guid.NewGuid();
        _tasks = tasks;
        Title = title;
    }
    private Activity(string title){
        Id = Guid.NewGuid();
        Title = title;
        _tasks = new();
    }

    public static Activity Create(string title)
    {
        return new Activity(title);
    }

    public void CreateTask(WorkUnit task)
    {
        _tasks.Add(task);
    }

    public static Activity Load(Guid id, string title, List<WorkUnit> tasks)
    {
        return new Activity(id,title,tasks);
    }

    internal void DeleteTask(Guid taskId)
    {
        _tasks.RemoveAll(task=>task.Id == taskId);
    }
}