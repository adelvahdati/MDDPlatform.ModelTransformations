using MDDPlatform.ModelTransformations.Application.ReadModels;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class PatternInstanceInfoDocument : BaseEntity<Guid>
{
    public Guid ProblemDomainId {get;set;}
    public Guid PatternId {get;set;}
    public string PatternName {get;set;}
    public string PatternCategory {get;set;}
    public string PatternInstanceTitle {get;set;}
    public List<ModelInfoDocument> InputModels {get;set;}
    public List<ModelInfoDocument> OutputModels {get;set;}

    public PatternInstanceInfoDocument(Guid id,Guid problemDomainId, Guid patternId, string patternName, string patternCategory, string patternInstanceTitle, List<ModelInfoDocument> inputModels, List<ModelInfoDocument> outputModels)
    {
        Id = id;
        ProblemDomainId = problemDomainId;
        PatternId = patternId;
        PatternName = patternName;
        PatternCategory = patternCategory;
        PatternInstanceTitle = patternInstanceTitle;
        InputModels = inputModels;
        OutputModels = outputModels;
    }
    public static PatternInstanceInfoDocument CreateFrom(PatternInstanceInfo patternInstanceInfo )
    {
        return new(patternInstanceInfo.Id,
                    patternInstanceInfo.ProblemDomainId,
                    patternInstanceInfo.PatternId,
                    patternInstanceInfo.PatternName,
                    patternInstanceInfo.PatternCategory,
                    patternInstanceInfo.PatternInstanceTitle,
                    patternInstanceInfo.InputModels.Select(modelInfo=>ModelInfoDocument.CreateFrom(modelInfo)).ToList(),
                    patternInstanceInfo.OutputModels.Select(modelInfo=>ModelInfoDocument.CreateFrom(modelInfo)).ToList());    
    }
    public PatternInstanceInfo ToPatternInstanceInfo(){
        return new PatternInstanceInfo(ProblemDomainId,
                                        PatternId,
                                        Id,
                                        PatternName,
                                        PatternCategory,
                                        PatternInstanceTitle,
                                        InputModels.Select(modelDoc=>modelDoc.ToModelInfo()).ToList(),
                                        OutputModels.Select(modelDoc=>modelDoc.ToModelInfo()).ToList());
    }
}