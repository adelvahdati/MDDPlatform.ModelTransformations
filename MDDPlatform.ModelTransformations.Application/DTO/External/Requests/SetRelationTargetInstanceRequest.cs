namespace MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
public class SetRelationTargetInstanceRequest : BaseRequest
{
    public Guid DomainModelId {get;set;}
    public string SourceNodeName {get;set;}
    public string SourceNodeType {get;set;}
    public string RelationName {get;set;}
    public string RelationTarget {get;set;}
    public List<string> TargetInstances {get;set;}

    public SetRelationTargetInstanceRequest(Guid domainModelId, string sourceNodeName, string sourceNodeType, string relationName, string relationTarget, List<string> targetInstances,Guid coordinationId , Guid stepId)
    {
        DomainModelId = domainModelId;
        SourceNodeName = sourceNodeName;
        SourceNodeType = sourceNodeType;
        RelationName = relationName;
        RelationTarget = relationTarget;
        TargetInstances = targetInstances;
        CoordinationId = coordinationId;
        StepId = stepId;
    }
}