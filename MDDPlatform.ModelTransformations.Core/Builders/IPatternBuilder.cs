using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;

namespace MDDPlatform.ModelTransformations.Core.Builders;
public interface IPatternBuilder
{
    IPatternBuilder AddField(string name,string label, FieldType type);
    Pattern Build();
}