using MDDPlatform.BaseConcepts.ValueObjects;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;
using OperationInput = MDDPlatform.ModelTransformations.Application.DTO.Elements.OperationInput;
using OperationOutput = MDDPlatform.ModelTransformations.Application.DTO.Elements.OperationOutput;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.TypeMappers;
public class CSharpTypeMapper : ITypeMapper
{
    private Dictionary<string,string> TypeMaps;

    public CSharpTypeMapper()
    {
        TypeMaps = new();
        TypeMaps.Add("StringValueObject","string");
        TypeMaps.Add("IntegerValueObject","int");
        TypeMaps.Add("LongValueObject","long");
        TypeMaps.Add("DoubleValueObject","double");
        TypeMaps.Add("FloatValueObject","float");
        TypeMaps.Add("GuidValueObject","Guid");
        TypeMaps.Add("DateTimeValueObject","DateTime");
        TypeMaps.Add("BooleanValueObject","bool");

        TypeMaps.Add("StringParameter","string");
        TypeMaps.Add("IntegerParameter","int");
        TypeMaps.Add("LongParameter","long");
        TypeMaps.Add("DoubleParameter","double");
        TypeMaps.Add("FloatParameter","float");
        TypeMaps.Add("GuidParameter","Guid");
        TypeMaps.Add("DateTimeParameter","DateTime");
        TypeMaps.Add("BooleanParameter","bool");

    }

    public ElementDto Map(ElementDto source)
    {
        
        var id = source.Id;
        var name = source.Name;
        var type = MapFrom(source.Type);
        var properties = source.Properties.Select(prop=> new PropertyDto(prop.Name,MapFrom(prop.Type),prop.Value,prop.IsCollection,prop.Attributes)).ToList();
        var relations = source.Relations.Select(rel=>new RelationDto(rel.Name,MapFrom(rel.Target),rel.Multiplicity)).ToList();
        var operations = source.Operations.Select(op=> 
            new OperationDto(
                op.Inputs.Select(opInput=> new OperationInput(opInput.Name,MapFrom(opInput.Type))).ToList(),
                op.Name,
                new OperationOutput(MapFrom(op.Output.Type),op.Output.IsCollection),
                op.Attributes
        )).ToList();

        var attributes = source.Attributes;
        var index = attributes.FindIndex(attr=>attr.Name.ToLower()=="extend");

        if(index == -1)
            return new ElementDto(id,name,type,properties,relations,operations,attributes);
        
        var extendAttribute = attributes[index];        
        if(extendAttribute == null)        
            return new ElementDto(id,name,type,properties,relations,operations,attributes);

        var extendValue = extendAttribute.Value;
        if(extendValue == null) 
            return new ElementDto(id,name,type,properties,relations,operations,attributes);

        var types = extendValue.Split(new string[]{"<",",",">"},StringSplitOptions.RemoveEmptyEntries).Where(item=> item.Contains(".")).ToList();
        types.ForEach(type=> extendValue = extendValue.Replace(type,MapFrom(type)));
        attributes[index].Value = extendValue;
        return new ElementDto(id,name,type,properties,relations,operations,attributes);
    }

    private string MapFrom(string type)
    {
        var concreteType = ConceptFullName.Create(type).ExtractConceptName();
        var destinationType = TypeMaps.ContainsKey(concreteType)? TypeMaps[concreteType] : concreteType;

        return destinationType;
    }

}
