using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetPhasesQuery : IQuery<List<PhaseDto>?>
{
    public Guid ProcessId {get;set;}

    public GetPhasesQuery(Guid processId)
    {
        ProcessId = processId;
    }
}
public class GetPhasesQueryHandler : IQueryHandler<GetPhasesQuery, List<PhaseDto>?>
{
    private readonly IProcessRepository _repository;

    public GetPhasesQueryHandler(IProcessRepository repository)
    {
        _repository = repository;
    }

    public List<PhaseDto> Handle(GetPhasesQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PhaseDto>?> HandleAsync(GetPhasesQuery query)
    {
        var process = await _repository.GetProcessAsync(query.ProcessId);
        if(Equals(process,null))
            return null;
        
        var phases = process.Phases.Select(phase=> PhaseDto.CreateFrom(phase)).ToList();
        return phases;
    }
}
