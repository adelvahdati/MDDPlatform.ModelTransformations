using MDDPlatform.BaseConcepts.ValueObjects;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.TextGenerators.TypeMappers;

namespace MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;
public class CSharpCodeGenerator : ITextGenerator
{
    private readonly ITypeMapper _typeMapper;

    public CSharpCodeGenerator(ITypeMapper typeMapper)
    {
        _typeMapper = typeMapper;
    }

    public string ClassToText(ElementDto element)
    {  
        var newElement = _typeMapper.Map(element);
        var declaration = new CSharpClassDeclaration(newElement);
        return declaration.Build();
    }

    public string InterfaceToText(ElementDto element)
    {
        var newElement = _typeMapper.Map(element);
        var declaration = new CSharpInterfaceDeclaration(newElement);
        return declaration.Build();
    }
}
