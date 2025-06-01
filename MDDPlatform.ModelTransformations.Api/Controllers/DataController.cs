using MDDPlatform.Messages.Brokers;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.SharedKernel.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ModelTransformations.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase 
{
    private readonly IDataSeeder _dataSeeder;
    private IMessageBroker _messagBroker;
    private IEventMapper _eventMapper;
    private IPatternInstanceRepository _patternInstancerepository;
    private IPatternRepository _patternRepository;
    private ISagaRepository _sagaRepository;
    public DataController(IDataSeeder dataSeeder, IMessageBroker messagBroker, IEventMapper eventMapper, IPatternInstanceRepository patternInstancerepository, IPatternRepository patternRepository, ISagaRepository sagaRepository)
    {
        _dataSeeder = dataSeeder;
        _messagBroker = messagBroker;
        _eventMapper = eventMapper;
        _patternInstancerepository = patternInstancerepository;
        _patternRepository = patternRepository;
        _sagaRepository = sagaRepository;
    }
    [HttpPost("Seed")]
    public async Task Seed()
    {
        await _dataSeeder.SeedPatternsAsync();
        await _dataSeeder.SeedPatternInstanceTemplatesAsync();
        await _dataSeeder.SeedProcessAsync();
    }

    [HttpPost("Saga/Cleare")]
    public async Task CleareSaga()
    {
        await _sagaRepository.ClearAsync();
    }
    [HttpPost("Saga/RemoveAll/{coordinationId}")]
    public async Task CleareSaga(Guid coordinationId)
    {
        await _sagaRepository.RemoveAllAsync(coordinationId);
    }
}
