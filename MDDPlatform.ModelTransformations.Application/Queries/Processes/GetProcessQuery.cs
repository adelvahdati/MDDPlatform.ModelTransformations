using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetProcessQuery : IQuery<ProcessDto?>
{
    public Guid ProcessId {get;set;}

    public GetProcessQuery(Guid processId)
    {
        ProcessId = processId;
    }
}
public class GetProcessQueryHandler : IQueryHandler<GetProcessQuery, ProcessDto?>
{
    private readonly IProcessRepository _repository;

    public GetProcessQueryHandler(IProcessRepository repository)
    {
        _repository = repository;
    }

    public ProcessDto? Handle(GetProcessQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<ProcessDto?> HandleAsync(GetProcessQuery query)
    {
        var process = await _repository.GetProcessAsync(query.ProcessId);
        if(Equals(process,null))
            return null;
        
        return ProcessDto.CreateFrom(process);

    }
}
