using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.Interfaces;
public interface ITextGenerator
{
    string ClassToText(ElementDto element);
    string InterfaceToText(ElementDto element);
}