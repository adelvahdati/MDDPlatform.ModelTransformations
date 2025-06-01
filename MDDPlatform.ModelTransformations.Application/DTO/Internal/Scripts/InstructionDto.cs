using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Application.DTO.Internal;
public class InstructionDto
{
    public string Code { get; set; }
    public List<string> Arguments { get; set; }

    public InstructionDto(string code, List<string> arguments)
    {
        Code = code;
        Arguments = arguments;
    }

    internal static InstructionDto CreateFrom(IInstruction ins)
    {
        return new(ins.Code,ins.Arguments);
    }
}