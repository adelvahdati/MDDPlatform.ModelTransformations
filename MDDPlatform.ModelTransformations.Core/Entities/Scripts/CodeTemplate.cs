using System.Text.Json;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class CodeTemplate : BaseEntity<Guid>
{
    private List<Field> _variables;
    private List<Instruction> _instructions;
    public string Title {get; private set;}
    public IReadOnlyList<IInstruction> Instructions => _instructions;
    public IReadOnlyList<Field> Variables => _variables;

    private CodeTemplate(string title,List<Instruction> instructions,List<Field> variables)
    {
        Id = Guid.NewGuid();
        Title = title;
        _instructions = instructions;
        _variables = variables;
    }
    public string ToJsonString()
    {
        return JsonSerializer.Serialize<List<Instruction>>(_instructions);
    }
}