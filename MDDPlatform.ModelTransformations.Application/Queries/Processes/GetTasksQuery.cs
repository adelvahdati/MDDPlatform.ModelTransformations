using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetTasksQuery : IQuery<List<TaskDto>?>
{
    public Guid ProcessId {get;set;}
    public Guid PhaseId {get;set;}
    public Guid ActivityId {get;set;}

    public GetTasksQuery(Guid processId, Guid phaseId, Guid activityId)
    {
        ProcessId = processId;
        PhaseId = phaseId;
        ActivityId = activityId;
    }
}
public class GetTasksQueryHandler : IQueryHandler<GetTasksQuery, List<TaskDto>?>
{
    private readonly IProcessRepository _repository;

    public GetTasksQueryHandler(IProcessRepository repository)
    {
        _repository = repository;
    }

    public List<TaskDto> Handle(GetTasksQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TaskDto>?> HandleAsync(GetTasksQuery query)
    {
        var process = await _repository.GetProcessAsync(query.ProcessId);
        if(Equals(process,null))
            return null;
        
        var phase = process.Phases.FirstOrDefault(phase=>phase.Id == query.PhaseId);
        if(Equals(phase,null))
            return null;
        
        var activity = phase.Activities.FirstOrDefault(activity=>activity.Id==query.ActivityId);

        if(Equals(activity,null))
            return null;
        
        var tasks = activity.Tasks.Select(task=>TaskDto.CreateFrom(task)).ToList();
        return tasks;
    }
}
