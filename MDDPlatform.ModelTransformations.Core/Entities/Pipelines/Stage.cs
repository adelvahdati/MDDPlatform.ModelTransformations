using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class Stage : BaseEntity<Guid>
{
    public string Title { get;  set; }
    public Guid TaskId { get;  set; }
    public StageType Type { get; set; }

    public Stage(Guid id, string title, Guid taskId, StageType type)
    {
        Id = id;
        Title = title;
        TaskId = taskId;
        Type = type;
    }
}