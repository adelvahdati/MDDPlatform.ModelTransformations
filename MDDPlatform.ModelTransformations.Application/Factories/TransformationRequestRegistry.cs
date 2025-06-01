using MDDPlatform.ModelTransformations.Services.Builders;
using MDDPlatform.ModelTransformations.Services.Commands;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
using MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
using MDDPlatform.ModelTransformations.Application.Patterns.ModelToText;

namespace MDDPlatform.ModelTransformations.Application.Factories;
public class TransformationRequestRegistry : ITransformationRequestRegistry
{
    private Dictionary<string,ModelTransformationRequest> _transformationRequests = new();

    public TransformationRequestRegistry()
    {
        // Object2Concept
        _transformationRequests.Add(nameof(ConvertInstanceToType), new ConvertInstanceToType());
        _transformationRequests.Add(nameof(ExtractOperationFromChainOfNodes),new ExtractOperationFromChainOfNodes());
        _transformationRequests.Add(nameof(ExtractOperationAttributeFromChainOfNodes), new ExtractOperationAttributeFromChainOfNodes());
        _transformationRequests.Add(nameof(ExtractOperationFromOneToOneToManyRelation),new ExtractOperationFromOneToOneToManyRelation());
        _transformationRequests.Add(nameof(MapObjectPropertyToConceptAttribute),new MapObjectPropertyToConceptAttribute());
        _transformationRequests.Add(nameof(ReplaceAssociationWithRelation), new ReplaceAssociationWithRelation());
        _transformationRequests.Add(nameof(ReplaceRelationWithAction),new ReplaceRelationWithAction());
        _transformationRequests.Add(nameof(ReplaceRelationWithGenericProperty), new ReplaceRelationWithGenericProperty());
        _transformationRequests.Add(nameof(ReplaceRelationWithOperation), new ReplaceRelationWithOperation());
        _transformationRequests.Add(nameof(ReplaceRelationWithConceptAttribute),new ReplaceRelationWithConceptAttribute());
        _transformationRequests.Add(nameof(ReplaceRelationWithOperationAttributes),new ReplaceRelationWithOperationAttributes());
        _transformationRequests.Add(nameof(ReplaceRelationWithProperty), new ReplaceRelationWithProperty());

        // Object2Object
        _transformationRequests.Add(nameof(MapInstance), new MapInstance());
        _transformationRequests.Add(nameof(MapOneToOne),new MapOneToOne());
        _transformationRequests.Add(nameof(MapOneToOneWithProperties),new MapOneToOneWithProperties());
        _transformationRequests.Add(nameof(ReplaceRelationWithChainOfNodes),new ReplaceRelationWithChainOfNodes());
        _transformationRequests.Add(nameof(MapRelatedObjects),new MapRelatedObjects());
        _transformationRequests.Add(nameof(MergerDomainObjectModels),new MergerDomainObjectModels());
        _transformationRequests.Add(nameof(ReplaceRelationWithForkNode), new ReplaceRelationWithForkNode());
        _transformationRequests.Add(nameof(MapOneToTwo), new MapOneToTwo());
        _transformationRequests.Add(nameof(SetRelationalDimension), new SetRelationalDimension());

        // RelationalDimension
        _transformationRequests.Add(nameof(CopyUpstreamNodePropertyToDownstreamNodeRelation), new CopyUpstreamNodePropertyToDownstreamNodeRelation());
        _transformationRequests.Add(nameof(CopyUpstreamNodeRelationToDownstreamNodeRelation), new CopyUpstreamNodeRelationToDownstreamNodeRelation());
        _transformationRequests.Add(nameof(ReplaceRelationalDimensionWithSourceNodeRelation), new ReplaceRelationalDimensionWithSourceNodeRelation());
        _transformationRequests.Add(nameof(MergeUpstreamNodePropertyWithDownStreamNodeRelation),new MergeUpstreamNodePropertyWithDownStreamNodeRelation());                
        _transformationRequests.Add(nameof(MergeUpstreamNodeWithDownStreamNode), new MergeUpstreamNodeWithDownStreamNode());
        _transformationRequests.Add(nameof(MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute), new MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute());
        _transformationRequests.Add(nameof(SetHigherDimensionRelation), new SetHigherDimensionRelation());

        // Model2Text
        _transformationRequests.Add(nameof(GenerateCSharpCodeOfClassConcept),new GenerateCSharpCodeOfClassConcept());
        _transformationRequests.Add(nameof(GenerateCSharpCodeOfInterfaceConcept),new GenerateCSharpCodeOfInterfaceConcept());
        _transformationRequests.Add(nameof(AppendLineForEachOneToManyRelation),new AppendLineForEachOneToManyRelation());
    }

    public ModelTransformationRequest? GetRequestTemplate(string patternName)
    {
        if(!_transformationRequests.ContainsKey(patternName))
            return null;

        var transformationRequest = _transformationRequests[patternName];
        return transformationRequest;
    }
}