using MDDPlatform.Messages.Queries;
using MDDPlatform.ModelTransformations.Application.DTO.Internal;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Application.Queries;
public class ListProcessQuery : IQuery<List<ProcessDto>>
{

}
public class ListProcessQueryHandler : IQueryHandler<ListProcessQuery, List<ProcessDto>>
{
    private readonly IProcessRepository _repository;

    public ListProcessQueryHandler(IProcessRepository repository)
    {
        _repository = repository;
    }

    public List<ProcessDto> Handle(ListProcessQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProcessDto>> HandleAsync(ListProcessQuery query)
    {
        var processes =  await _repository.ListProcessesAsync();
        return processes.Select(process=>ProcessDto.CreateFrom(process)).ToList();        
    }
}
