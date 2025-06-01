using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class GetExecutableProcessQuery : IQuery<ExecutableProcessDto?>
{
    public Guid Id {get;set;}

    public GetExecutableProcessQuery(Guid id)
    {
        Id = id;
    }
}
public class GetExecutableProcessQueryHanlder : IQueryHandler<GetExecutableProcessQuery, ExecutableProcessDto?>
{
    private readonly IExecutableProcessRepository _repository;

    public GetExecutableProcessQueryHanlder(IExecutableProcessRepository repository)
    {
        _repository = repository;
    }

    public ExecutableProcessDto? Handle(GetExecutableProcessQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<ExecutableProcessDto?> HandleAsync(GetExecutableProcessQuery query)
    {
        var executableProcess = await _repository.GetAsync(query.Id);
        if(Equals(executableProcess,null))
            return null;
            
        return ExecutableProcessDto.CreateFrom(executableProcess);
    }
}
