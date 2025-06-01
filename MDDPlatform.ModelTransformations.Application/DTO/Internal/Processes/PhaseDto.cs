using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class PhaseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<ActivityDto> Activities { get; set; }

    public PhaseDto(Guid id, string title, List<ActivityDto> activities)
    {
        Id = id;
        Title = title;
        Activities = activities;
    }
    public static PhaseDto CreateFrom(Phase phase){
        var activities = phase.Activities.Select(activity=>ActivityDto.CreateFrom(activity)).ToList();
        return new PhaseDto(phase.Id,phase.Title,activities);
    }
}