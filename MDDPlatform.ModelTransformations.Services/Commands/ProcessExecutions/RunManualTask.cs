using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class RunManualTask : ICommand
{
    public Guid ProcessConfigurationId {get;set;}
    public Guid TaskId {get;set;}

    public RunManualTask(Guid processConfigurationId, Guid taskId)
    {
        this.ProcessConfigurationId = processConfigurationId;
        this.TaskId = taskId;
    }
}
public class RunManualTaskHandler : ICommandHandler<RunManualTask>
{
    private readonly IExecutableProcessRepository _exProcessRepository;
    private readonly IProcessNotificationService _processNotificationService;

    public RunManualTaskHandler(IExecutableProcessRepository exProcessRepository, IProcessNotificationService processNotificationService)
    {
        this._exProcessRepository = exProcessRepository;
        _processNotificationService = processNotificationService;
    }

    public void Handle(RunManualTask command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(RunManualTask command)
    {
        var executableProcess = await _exProcessRepository.GetAsync(command.ProcessConfigurationId);
        if(Equals(executableProcess,null))
            throw new Exception("Hanlde Manual Task Exception : Executable Process Not Found");
        
        executableProcess.HandleManualTask(command.TaskId);

        await _exProcessRepository.UpdateAsync(executableProcess);
        await _processNotificationService.TaskIsDoneAsync(executableProcess.Id,command.TaskId,executableProcess.Status);
    }
}
