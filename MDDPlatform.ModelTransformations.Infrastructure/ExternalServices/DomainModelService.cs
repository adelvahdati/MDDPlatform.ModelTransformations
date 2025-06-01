using MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
using MDDPlatform.ModelTransformations.Application.Patterns.Common;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
using MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.RestClients;

namespace MDDPlatform.ModelTransformations.Infrastructure.ExternalServices;
public class DomainModelService : IDomainModelService
{
    private IRestClient _restclient;

    public DomainModelService(HttpClient httpClient)
    {
        _restclient = new RestClient(httpClient);
    }

    // Object2Concept
    public async Task ConvertInstanceToTypeAsync(ConvertInstanceToType request)
    {
        var url = "TransformationPattern/Object2Concept/ConvertInstanceToType";
        await _restclient.PostAsync(url,request);
    }
    public async Task ExtractOperationFromChainOfNodesAsync(ExtractOperationFromChainOfNodes request)
    {
        var url = "TransformationPattern/Object2Concept/ExtractOperationFromChainOfNodes";
        await _restclient.PostAsync(url,request);
    }
    public async Task ExtractOperationAttributeFromChainOfNodesAsync(ExtractOperationAttributeFromChainOfNodes request)
    {
        var url = "TransformationPattern/Object2Concept/ExtractOperationAttributeFromChainOfNodes";
        await _restclient.PostAsync(url,request);
    }
    public async Task ExtractOperationFromOneToOneToManyRelationAsync(ExtractOperationFromOneToOneToManyRelation request)
    {
        var url = "TransformationPattern/Object2Concept/ExtractOperationFromOneToOneToManyRelation";
        await _restclient.PostAsync(url,request);
    }

    public async Task MapObjectPropertyToConceptAttributeAsync(MapObjectPropertyToConceptAttribute request)
    {
        var url = "TransformationPattern/Object2Concept/MapObjectPropertyToConceptAttribute";
        await _restclient.PostAsync(url,request);
    }

    public async Task ReplaceAssociationWithRelationAsync(ReplaceAssociationWithRelation request)
    {
        var url = "TransformationPattern/Object2Concept/ReplaceAssociationWithRelation";
        await _restclient.PostAsync(url,request);
    }
    public async Task ReplaceRelationWithActionAsync(ReplaceRelationWithAction request)
    {
        var url = "TransformationPattern/Object2Concept/ReplaceRelationWithAction";
        await _restclient.PostAsync(url,request);
    }

    public async Task ReplaceRelationwithGenericPropertyAsync(ReplaceRelationWithGenericProperty request)
    {
        var url = "TransformationPattern/Object2Concept/ReplaceRelationWithGenericProperty";
        await _restclient.PostAsync(url,request);
    }
    public async Task ReplaceRelationWithOperationAsync(ReplaceRelationWithOperation request)
    {
        var url = "TransformationPattern/Object2Concept/ReplaceRelationWithOperation";
        await _restclient.PostAsync(url,request);
    }
    public async Task ReplaceRelationWithConceptAttributeAsync(ReplaceRelationWithConceptAttribute request)
    {
        var url = "TransformationPattern/Object2Concept/ReplaceRelationWithConceptAttribute";
        await _restclient.PostAsync(url,request);
    }

    public async Task ReplaceRelationWithOperationAttributesAsync(ReplaceRelationWithOperationAttributes request)
    {
        var url = "TransformationPattern/Object2Concept/ReplaceRelationWithOperationAttributes";
        await _restclient.PostAsync(url,request);
    }
    public async Task ReplaceRelationWithPropertyAsync(ReplaceRelationWithProperty request)
    {
        var url = "TransformationPattern/Object2Concept/ReplaceRelationWithProperty";
        await _restclient.PostAsync(url,request);
    }


    // Object2Object
    public async Task MapInstanceAsync(MapInstance request)
    {
        var url ="TransformationPattern/Object2Object/MapInstance";
        await _restclient.PostAsync(url,request);
    }
    public async Task MapOneToOneAsync(MapOneToOne request)
    {
        var url ="TransformationPattern/Object2Object/MapOneToOne";
        await _restclient.PostAsync(url,request);
    }
    public async Task MapOneToOneWithPropertiesAsync(Guid inputModel, string source, Guid outputModel, string destination, List<MemberValueExpression> valueExpressions,Guid coordinationId,Guid stepId)
    {
        var url ="TransformationPattern/Object2Object/MapOneToOneWithProperties";
        var requestPayload = new {
            InputModel = inputModel,
            Source = source,
            OutputModel = outputModel,
            Destination = destination,
            DestinationMembers = valueExpressions,
            CoordinationId = coordinationId,
            StepId = stepId
        };
        await _restclient.PostAsync(url,requestPayload);
    }
    public async Task MapOneToTwoAsync(MapOneToTwoRequest request)
    {
        var url = "TransformationPattern/Object2Object/MapOneToTwo";
        await _restclient.PostAsync(url,request);
    }

    public async Task SetRelationalDimensionAsync(SetRelationalDimension command)
    {
        var url = "TransformationPattern/Object2Object/SetRelationalDimension";
        await _restclient.PostAsync(url,command);
    }

    public async Task ReplaceRelationWithChainOfNodesAsync(ReplaceRelationWithChainOfNodes request){
        var url ="TransformationPattern/Object2Object/ReplaceRelationWithChainOfNodes";
        await _restclient.PostAsync(url,request);

    }
    public async Task MapRelatedObjectsAsync(MapRelatedObjects request)
    {
        var url ="TransformationPattern/Object2Object/MapRelatedObjects";
        await _restclient.PostAsync(url,request);
    }
    public async Task MergerDomainObjectModelsAsync(MergerDomainObjectModels request)
    {
        var url ="TransformationPattern/Object2Object/MergerDomainObjectModels";
        await _restclient.PostAsync(url,request);
    }

    public async Task ReplaceRelationWithForkNodeAsync(ReplaceRelationWithForkNode request)
    {
        var url ="TransformationPattern/Object2Object/ReplaceRelationWithForkNode";
        await _restclient.PostAsync(url,request);
    }



    //RelationalDimesion
    public async Task CopyUpstreamNodePropertyToDownstreamNodeRelationAsync(CopyUpstreamNodePropertyToDownstreamNodeRelation request)
    {
        var url = "TransformationPattern/RelationalDimension/CopyUpstreamNodePropertyToDownstreamNodeRelation";
        await _restclient.PostAsync(url,request);
    }

    public async Task CopyUpstreamNodeRelationToDownstreamNodeRelationAsync(CopyUpstreamNodeRelationToDownstreamNodeRelation request)
    {
        var url ="TransformationPattern/RelationalDimesion/CopyUpstreamNodeRelationToDownstreamNodeRelation";
        await _restclient.PostAsync(url,request);
    }

    public async Task ReplaceRelationalDimensionWithSourceNodeRelationAsync(ReplaceRelationalDimensionWithSourceNodeRelation request)
    {
        var url = "TransformationPattern/RelationalDimension/ReplaceRelationalDimensionWithSourceNodeRelation";
        await _restclient.PostAsync(url,request);
    }

    public async Task MergeUpstreamNodePropertyWithDownStreamNodeRelationAsync(MergeUpstreamNodePropertyWithDownStreamNodeRelation request)
    {
        var url ="TransformationPattern/RelationalDimension/MergeUpstreamNodePropertyWithDownStreamNodeRelation";
        await _restclient.PostAsync(url,request);
    }

    public async Task MergeUpstreamNodeWithDownStreamNodeAsync(MergeUpstreamNodeWithDownStreamNode request)
    {
        var url ="TransformationPattern/RelationalDimension/MergeUpstreamNodeWithDownStreamNode";
        await _restclient.PostAsync(url,request);
    }

    public async Task MergeUpstreamNodeWithDownStreamNodePropertyAsAttributeAsync(MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute request)
    {
        var url ="TransformationPattern/RelationalDimension/MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute";
        await _restclient.PostAsync(url,request);
    }

    public async Task SetHigherDimensionRelationAsync(SetHigherDimensionRelation request)
    {
        Console.WriteLine("Start Sending the Request");
        var url ="TransformationPattern/RelationalDimension/SetHigherDimensionRelation";
        await _restclient.PostAsync(url,request);
        Console.WriteLine("Request is sent");
    }
}
