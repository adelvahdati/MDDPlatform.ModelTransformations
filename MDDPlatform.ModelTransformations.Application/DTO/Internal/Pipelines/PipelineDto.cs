using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;

namespace  MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class PipelineDto
{
    public Guid Id {get;set;}
    public string Title {get;set;}
    public List<PipelineStageDto> Stages {get;set;}
    public PipelineStatus Status {get;set;}
    public Guid ProblemDomainId {get;set;}

    private PipelineDto(Guid id, string title, List<PipelineStageDto> stages,PipelineStatus status,Guid problemDomainId)
    {
        Id = id;
        Title = title;
        Stages = stages;
        Status = status;
        ProblemDomainId = problemDomainId;
    }
    public static PipelineDto CreateFrom(Pipeline pipeline)
    {
        var stages = pipeline.Stages.Select(stage=> PipelineStageDto.CreateFrom(stage)).ToList();
        return new(pipeline.Id,pipeline.Title,stages,pipeline.Status,pipeline.ProblemDomainId);
    }
}