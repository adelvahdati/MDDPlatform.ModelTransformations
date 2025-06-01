using MDDPlatform.ModelTransformations.Application.DTO.External.Requests;
using MDDPlatform.ModelTransformations.Application.Patterns.Common;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
using MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;

namespace MDDPlatform.ModelTransformations.Application.Services.External;
public interface IDomainModelService
{
    // Object2Concept
    Task ConvertInstanceToTypeAsync(ConvertInstanceToType request);
    Task ExtractOperationFromChainOfNodesAsync(ExtractOperationFromChainOfNodes request);
    Task ExtractOperationAttributeFromChainOfNodesAsync(ExtractOperationAttributeFromChainOfNodes request);
    Task ExtractOperationFromOneToOneToManyRelationAsync(ExtractOperationFromOneToOneToManyRelation command);
    Task MapObjectPropertyToConceptAttributeAsync(MapObjectPropertyToConceptAttribute request);
    Task ReplaceAssociationWithRelationAsync(ReplaceAssociationWithRelation command);
    Task ReplaceRelationWithActionAsync(ReplaceRelationWithAction command);
    Task ReplaceRelationwithGenericPropertyAsync(ReplaceRelationWithGenericProperty request);
    Task ReplaceRelationWithOperationAsync(ReplaceRelationWithOperation request);
    Task ReplaceRelationWithConceptAttributeAsync(ReplaceRelationWithConceptAttribute request);
    Task ReplaceRelationWithOperationAttributesAsync(ReplaceRelationWithOperationAttributes command);
    Task ReplaceRelationWithPropertyAsync(ReplaceRelationWithProperty request);

    // Object2Object
    Task MapInstanceAsync(MapInstance request);
    Task MapOneToOneAsync(MapOneToOne request);    
    Task MapOneToOneWithPropertiesAsync(Guid inputModel, string source, Guid outputModel, string destination, List<MemberValueExpression> valueExpressions,Guid coordinationId,Guid stepId);
    Task MapOneToTwoAsync(MapOneToTwoRequest request);
    Task ReplaceRelationWithChainOfNodesAsync(ReplaceRelationWithChainOfNodes request);
    Task MapRelatedObjectsAsync(MapRelatedObjects request);
    Task MergerDomainObjectModelsAsync(MergerDomainObjectModels command);
    Task ReplaceRelationWithForkNodeAsync(ReplaceRelationWithForkNode request);
    Task SetRelationalDimensionAsync(SetRelationalDimension command);


    // RelationalDimension
    Task CopyUpstreamNodePropertyToDownstreamNodeRelationAsync(CopyUpstreamNodePropertyToDownstreamNodeRelation request);
    Task CopyUpstreamNodeRelationToDownstreamNodeRelationAsync(CopyUpstreamNodeRelationToDownstreamNodeRelation request);
    Task ReplaceRelationalDimensionWithSourceNodeRelationAsync(ReplaceRelationalDimensionWithSourceNodeRelation request);
    Task MergeUpstreamNodePropertyWithDownStreamNodeRelationAsync(MergeUpstreamNodePropertyWithDownStreamNodeRelation request);
    Task MergeUpstreamNodeWithDownStreamNodeAsync(MergeUpstreamNodeWithDownStreamNode request);
    Task MergeUpstreamNodeWithDownStreamNodePropertyAsAttributeAsync(MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute request);
    Task SetHigherDimensionRelationAsync(SetHigherDimensionRelation request);
}
