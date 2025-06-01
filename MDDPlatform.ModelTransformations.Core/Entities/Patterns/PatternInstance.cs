using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class PatternInstance : BaseEntity<Guid>
{
    private List<FieldValue> _filedValues = new();

    public Guid ProblemDomainId {get;private set;}
    public string Title {get;private set;}
    public string Name {get;private set;}
    public PatternTemplate Template {get; private set;}
    public IReadOnlyList<FieldValue> FieldValues => _filedValues;

    internal PatternInstance(string title, string name, PatternTemplate template,List<FieldValue> filedValues,Guid problemDomainId)
    {
        Id= Guid.NewGuid();
        Title = title;
        Name = name;
        Template = template;
        _filedValues = filedValues;
        ProblemDomainId = problemDomainId;
    }
    internal PatternInstance(Guid id,string title, string name, PatternTemplate template,List<FieldValue> filedValues,Guid problemDomainId)
    {
        Id= id;
        Title = title;
        Name = name;
        Template = template;
        _filedValues = filedValues;
        ProblemDomainId = problemDomainId;
    }

    public static PatternInstance Load(Guid id, string title, string name, PatternTemplate template,List<FieldValue> filedValues,Guid problemDomainId)
    {
        return new PatternInstance(id,title,name,template,filedValues,problemDomainId);
    }
    public FieldValue? GetFieldValue(string fieldName)
    {
        return _filedValues.FirstOrDefault(fieldValue=> fieldValue.Name.ToLower() == fieldName.ToLower());
    }
}