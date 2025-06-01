using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Services.Repositories;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class DeletePattern : ICommand
{
    public Guid PatternId {get;set;}

    public DeletePattern(Guid patternId)
    {
        this.PatternId = patternId;
    }
}
public class DeletePatternHandler : ICommandHandler<DeletePattern>
{
    private readonly IPatternRepository _patternRepository;

    public DeletePatternHandler(IPatternRepository patternRepository)
    {
        _patternRepository = patternRepository;
    }

    public void Handle(DeletePattern command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeletePattern command)
    {
        await _patternRepository.DeletePatternAsync(command.PatternId);
    }
}
