using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Application.ReadModels;
public class PatternInstanceInfo : BaseEntity<Guid>
{
    public Guid ProblemDomainId {get;set;}
    public Guid PatternId {get;set;}
    public string PatternName {get;set;}
    public string PatternCategory {get;set;}
    public string PatternInstanceTitle {get;set;}
    public List<ModelInfo> InputModels {get;set;}
    public List<ModelInfo> OutputModels {get;set;}

    public Guid PatternInstanceId => Id;

    public PatternInstanceInfo(Guid problemDomainId,Guid patternId, Guid PatternInsatnceId, string patternName, string patternCategory, string patternInstanceTitle, List<ModelInfo> inputModels, List<ModelInfo> outputModels)
    {
        ProblemDomainId = problemDomainId;
        PatternId = patternId;
        Id = PatternInsatnceId;
        PatternName = patternName;
        PatternCategory = patternCategory;
        PatternInstanceTitle = patternInstanceTitle;
        InputModels = inputModels;
        OutputModels = outputModels;
    }
}