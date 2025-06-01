using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class InstructionDocument
{
    public string Code { get; set; }
    public List<string> Arguments { get; set; }

    public InstructionDocument(string code, List<string> arguments)
    {
        Code = code;
        Arguments = arguments;
    }

    public static InstructionDocument CreateFrom(IInstruction instruction)
    {
        return new(instruction.Code,instruction.Arguments);

    }
    public Instruction ToInstruction()
    {
        return Instruction.Load(Code,Arguments);
    }
}