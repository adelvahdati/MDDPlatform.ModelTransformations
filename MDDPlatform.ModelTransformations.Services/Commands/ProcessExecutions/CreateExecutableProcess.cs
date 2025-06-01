using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class CreateExecutableProcess : ICommand{
    public Guid ProcessId {get;set;}
    public Guid ProcessConfigurationId {get;set;}

    public CreateExecutableProcess(Guid processId, Guid processConfigurationId)
    {
        this.ProcessId = processId;
        this.ProcessConfigurationId = processConfigurationId;
    }    
}
public class CreateExecutableProcessHandler : ICommandHandler<CreateExecutableProcess>
{
    private readonly IExecutableProcessRepository _repository;
    private readonly IProcessRepository _processRepository;
    private readonly IProcessConfigurationRepository _configRepository;

    public CreateExecutableProcessHandler(IExecutableProcessRepository repository, IProcessRepository processRepository, IProcessConfigurationRepository configRepository)
    {
        _repository = repository;
        _processRepository = processRepository;
        _configRepository = configRepository;
    }

    public void Handle(CreateExecutableProcess command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(CreateExecutableProcess command)
    {
        var process = await _processRepository.GetProcessAsync(command.ProcessId);
        var processConfig = await _configRepository.GetAsync(command.ProcessConfigurationId);

        if(Equals(process,null))
            throw new Exception("Process Not Found");
        
        if(Equals(processConfig,null))
            throw new Exception("Process Configuration Not Found");
        
        ExecutableProcess executableProcess = ExecutableProcess.Create(process,processConfig);

        await _repository.CreateAsync(executableProcess);

    }
}
