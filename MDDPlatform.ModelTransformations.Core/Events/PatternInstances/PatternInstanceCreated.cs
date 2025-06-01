using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.ModelTransformations.Core.Events;
public class PatternInstanceCreated : IDomainEvent
{
    public Guid ProblemDomainId {get;set;}
    public Guid PatternId {get;set;}
    public Guid PatternInstanceId {get;set;}    
    public List<Guid> InputModelIds {get;set;}
    public List<Guid> OutputModelIds {get;set;}

    public PatternInstanceCreated(Guid problemDomainId, Guid patternId, Guid patternInstanceId, List<Guid> inputModelIds, List<Guid> outputModelIds)
    {
        ProblemDomainId = problemDomainId;
        PatternId = patternId;
        PatternInstanceId = patternInstanceId;
        InputModelIds = inputModelIds;
        OutputModelIds = outputModelIds;
    }
    public static PatternInstanceCreated Create(Pattern pattern, PatternInstance patternInstance)
    {
        if(pattern.Id!= patternInstance.Template.PatternId)
            throw new Exception("The pattern instance was not created form this pattern");

        List<Guid> inputModelIds = new();
        List<Guid> outputModelIds = new();
        Guid id;
        var inputFields = pattern.Fields.Where(f=>f.Type == FieldType.InputModel).Select(f=>f.Name).ToList();
        var outputFields = pattern.Fields.Where(f=>f.Type == FieldType.OutputModel).Select(f=>f.Name).ToList();
        
        if(inputFields != null){
            var items = patternInstance.FieldValues.Where(fv=>inputFields.Contains(fv.Name)).Select(fv=>fv.Value).ToList();
            foreach(var item in items)
            {
                if(Guid.TryParse(item,out id))
                    inputModelIds.Add(id);
            }
        }
        if(outputFields != null){
            var items = patternInstance.FieldValues.Where(fv=>outputFields.Contains(fv.Name)).Select(fv=>fv.Value).ToList();
            foreach(var item in items)
            {
                if(Guid.TryParse(item,out id))
                    outputModelIds.Add(id);
            }
        }
        
        return new PatternInstanceCreated(patternInstance.ProblemDomainId,pattern.Id,patternInstance.Id,inputModelIds,outputModelIds);
            
    }
}