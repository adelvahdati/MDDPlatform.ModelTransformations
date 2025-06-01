using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetActivitiesQuery : IQuery<List<ActivityDto>?>
{
    public Guid ProcessId {get;set;}
    public Guid PhaseId {get;set;}

    public GetActivitiesQuery(Guid processId, Guid phaseId)
    {
        ProcessId = processId;
        PhaseId = phaseId;
    }
}
public class GetActivitiesQueryHandler : IQueryHandler<GetActivitiesQuery, List<ActivityDto>?>
{
    private readonly IProcessRepository _repository;

    public GetActivitiesQueryHandler(IProcessRepository repository)
    {
        _repository = repository;
    }

    public List<ActivityDto> Handle(GetActivitiesQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ActivityDto>?> HandleAsync(GetActivitiesQuery query)
    {
        var process = await _repository.GetProcessAsync(query.ProcessId);
        if(Equals(process,null))
            return null;
        
        var phase = process.Phases.FirstOrDefault(phase=>phase.Id == query.PhaseId);
        if(Equals(phase,null))
            return null;
        
        var activities = phase.Activities.Select(activity=>ActivityDto.CreateFrom(activity)).ToList();

        return activities;

    }
}
