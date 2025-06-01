using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.TypeMappers;
public interface ITypeMapper
{
    ElementDto Map(ElementDto source);
}
