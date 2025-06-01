using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class ActivityDto 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<TaskDto> Tasks {get;set;}

    public ActivityDto(Guid id, string title, List<TaskDto> tasks)
    {
        Id = id;
        Title = title;
        Tasks = tasks;
    }
    public static ActivityDto CreateFrom(Activity activity)
    {
        var tasks = activity.Tasks.Select(task=>TaskDto.CreateFrom(task)).ToList();

        return new ActivityDto(activity.Id,activity.Title,tasks);
    }
}