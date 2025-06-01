using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.External.Requests;

public class CreateOrUpdateInstanceRequest : BaseRequest
{
    public Guid DomainModelId {get;set;}
    public string InstanceName {get;set;}
    public string InstanceType {get;set;}
    public List<ProeprtyValueDto> PropertyValues {get;set;}

    public CreateOrUpdateInstanceRequest(Guid domainModelId,string instanceName, string instanceType, List<ProeprtyValueDto> propertyValues,Guid coordinationId,Guid stepId)
    {
        DomainModelId = domainModelId;
        InstanceName = instanceName;
        InstanceType = instanceType;
        PropertyValues = propertyValues;
        CoordinationId = coordinationId;
        StepId = stepId;
    }
}
