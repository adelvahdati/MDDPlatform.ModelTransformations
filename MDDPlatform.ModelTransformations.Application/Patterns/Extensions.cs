using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.Patterns.ModelToText;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
using MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Application.Patterns;
public static class Extensions
{
    public static List<Pattern> AddPatterns(this List<Pattern> patterns)
    {
        List<ITransformationPattern> transformations = new List<ITransformationPattern>();

        transformations.AddObject2ConceptPatterns();
        transformations.AddObject2ObjectPatterns();
        transformations.AddRelationalDimensionPatterns();
        transformations.AddModelToTextPatterns();

        foreach(var transformation in transformations)
        {
            patterns.Add(transformation.Specification());
        }    
        return patterns;
    }

    private static List<ITransformationPattern> AddObject2ConceptPatterns(this List<ITransformationPattern> transformations)
    {
        transformations.Add( new ConvertInstanceToType());
        transformations.Add(new ExtractOperationFromChainOfNodes());
        transformations.Add(new ExtractOperationAttributeFromChainOfNodes());
        transformations.Add(new ExtractOperationFromOneToOneToManyRelation());
        transformations.Add(new MapObjectPropertyToConceptAttribute());
        transformations.Add(new ReplaceAssociationWithRelation());
        transformations.Add(new ReplaceRelationWithAction());
        transformations.Add(new ReplaceRelationWithGenericProperty());
        transformations.Add(new ReplaceRelationWithOperation());
        transformations.Add(new ReplaceRelationWithOperationAttributes());
        transformations.Add(new ReplaceRelationWithConceptAttribute());
        transformations.Add(new ReplaceRelationWithProperty());
        return transformations;
    }
    private static List<ITransformationPattern> AddObject2ObjectPatterns(this List<ITransformationPattern> transformations)
    {
        transformations.Add(new MapInstance());
        transformations.Add(new MapOneToOne());
        transformations.Add(new MapOneToOneWithProperties());
        transformations.Add(new MapOneToTwo());        
        transformations.Add(new ReplaceRelationWithChainOfNodes());
        transformations.Add(new MapRelatedObjects());
        transformations.Add(new MergerDomainObjectModels());
        transformations.Add(new ReplaceRelationWithForkNode());
        transformations.Add(new SetRelationalDimension());
        return transformations;
    }
    private static List<ITransformationPattern> AddRelationalDimensionPatterns(this List<ITransformationPattern> transformations)
    {
        transformations.Add(new CopyUpstreamNodePropertyToDownstreamNodeRelation());
        transformations.Add(new CopyUpstreamNodeRelationToDownstreamNodeRelation());
        transformations.Add(new ReplaceRelationalDimensionWithSourceNodeRelation());
        transformations.Add(new MergeUpstreamNodePropertyWithDownStreamNodeRelation());
        transformations.Add(new MergeUpstreamNodeWithDownStreamNode());
        transformations.Add(new MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute()); 
        transformations.Add(new SetHigherDimensionRelation());
        return transformations;
    }
    private static List<ITransformationPattern> AddModelToTextPatterns(this List<ITransformationPattern> transformations){
        transformations.Add(new GenerateCSharpCodeOfClassConcept() );
        transformations.Add(new GenerateCSharpCodeOfInterfaceConcept());
        transformations.Add(new AppendLineForEachOneToManyRelation());
        return transformations;
    }
}