using MDDPlatform.ModelTransformations.Application.Patterns.Common;

namespace MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
public class MapOneToTwoRequest : BaseRequest
{
    public Guid InputModel { get; set;}
    public string Source {get;set;}
    public string FirstDestination {get;set;}
    public string FirstDestinationInstanceNameExpression {get;set;}
    public string SecondDestination {get;set;}
    public string SecondDestinationInstanceNameExpression {get;set;}
    public string FirstToSecondRelationName {get;set;}

    public List<MemberValueExpression> FirstDestinationMembers {get;set;}
    public List<MemberValueExpression> SecondDestinationMembers {get;set;}
    public Guid OutputModel { get; set;}

    public MapOneToTwoRequest(Guid inputModel, string source, string firstDestination, string firstDestinationInstanceNameExpression, string secondDestination, string secondDestinationInstanceNameExpression, string firstToSecondRelationName, List<MemberValueExpression> firstDestinationMembers, List<MemberValueExpression> secondDestinationMembers, Guid outputModel,Guid coordinationId, Guid stepId)
    {
        InputModel = inputModel;
        Source = source;
        FirstDestination = firstDestination;
        FirstDestinationInstanceNameExpression = firstDestinationInstanceNameExpression;
        SecondDestination = secondDestination;
        SecondDestinationInstanceNameExpression = secondDestinationInstanceNameExpression;
        FirstToSecondRelationName = firstToSecondRelationName;
        FirstDestinationMembers = firstDestinationMembers;
        SecondDestinationMembers = secondDestinationMembers;
        OutputModel = outputModel;
        CoordinationId = coordinationId;
        StepId = stepId;
    }
}