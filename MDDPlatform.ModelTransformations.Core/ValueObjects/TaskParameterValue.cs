using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ModelTransformations.Core.ValueObjects;
public class TaskParameterValue : ValueObject
{
    private bool _isConfigured;

    public string Name {get; private set;}
    public string? Value {get; private set;}
    public bool IsConfigured => _isConfigured;

    private TaskParameterValue(string name, string? value,bool isConfigured)
    {
        _isConfigured = isConfigured;
        Name = name;
        Value = value;
    }
    private TaskParameterValue(string name, string value)
    {
        _isConfigured = true;
        Name = name;
        Value = value;
    }
    private TaskParameterValue(string name)
    {
        _isConfigured = false;
        Name = name;
        Value = null;
    }
    public void Config(string value)
    {
        Value = value;
        _isConfigured = true;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return _isConfigured;
        yield return Value == null ? "[NULL]" : Value;
    }

    public static TaskParameterValue Create(string name, string value)
    {
        return new(name,value);
    }
    public static TaskParameterValue Create(string name)
    {
        return new(name);
    }

    public static TaskParameterValue Load(string name,string? value, bool isConfigured)
    {
        return new(name,value,isConfigured);
    }
}