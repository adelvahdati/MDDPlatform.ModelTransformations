using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class PipelineDocument : BaseEntity<Guid>
{
    public Guid ProblemDomainId {get;set;}
    public string Title {get;set;}
    public List<PipelineStageDocument> Stages {get;set;}

    public PipelineDocument(Guid id, string title, List<PipelineStageDocument> stages,Guid problemDomainId)
    {
        Id = id;
        Title = title;
        Stages = stages;
        ProblemDomainId = problemDomainId;
    }
    public static PipelineDocument CreateFrom(Pipeline pipeline)
    {
        var stages = pipeline.Stages.Select(stage=> PipelineStageDocument.CreateFrom(stage)).ToList();

        return new PipelineDocument(pipeline.Id,pipeline.Title,stages,pipeline.ProblemDomainId);
    }
    public Pipeline ToPipeline()
    {
        var stages = Stages.Select(stage=> stage.ToPipelineStage()).ToList();
        return Pipeline.Load(Id,Title,stages,ProblemDomainId);
    }
}
