using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class ProcessDto
{
    public Guid Id {get;set;}
    public string Title {get;set;}
    public List<PhaseDto> Phases {get;set;}

    public ProcessDto(Guid id, string title, List<PhaseDto> phases)
    {
        Id = id;
        Title = title;
        Phases = phases;
    }
    public static ProcessDto CreateFrom(Process process){
        var phases = process.Phases.Select(phase=>PhaseDto.CreateFrom(phase)).ToList();
        return new ProcessDto(process.Id,process.Title,phases);
    }
}