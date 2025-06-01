namespace MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;
public class DomainObjectRelationDto
{
    public string RelationName { get; set;}
    public string RelationTarget { get; set;}
    public string Multiplicity { get; set;}
    public List<string> TargetInstances { get; set;}

    public DomainObjectRelationDto(string relationName, string relationTarget, string multiplicity, List<string> targetInstances)
    {
        RelationName = relationName;
        RelationTarget = relationTarget;
        Multiplicity = multiplicity;
        TargetInstances = targetInstances;
    }
}