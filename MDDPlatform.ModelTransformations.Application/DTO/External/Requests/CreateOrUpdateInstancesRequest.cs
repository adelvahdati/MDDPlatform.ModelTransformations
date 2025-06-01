using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
public class CreateOrUpdateInstancesRequest : BaseRequest
{
    public Guid DomainModelId {get;set;}
    public List<InstanceProperties> Instances {get;set;}

    public CreateOrUpdateInstancesRequest(Guid domainModelId, List<InstanceProperties> instances,Guid coordinationId,Guid stepId)
    {
        DomainModelId = domainModelId;
        Instances = instances;
        CoordinationId = coordinationId;
        StepId = stepId;
    }
}
public class InstanceProperties
{
    public string InstanceName {get;set;}
    public string InstanceType {get;set;}
    public List<ProeprtyValueDto> PropertyValues {get;set;}

    public InstanceProperties(string instanceName, string instanceType, List<ProeprtyValueDto> propertyValues)
    {
        InstanceName = instanceName;
        InstanceType = instanceType;
        PropertyValues = propertyValues;
    }
}