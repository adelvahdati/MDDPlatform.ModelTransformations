namespace MDDPlatform.ModelTransformations.Application.Patterns.Common;
public class PatternId
{
    public string StringValue {get;}
    public Guid GuidValue {get;}

    private PatternId(string stringValue, Guid guidValue)
    {
        StringValue = stringValue;
        GuidValue = guidValue;
    }

    public PatternId Create(string value)
    {
        Guid id;
        var result = Guid.TryParse(value,out id);
        if(!result)
            throw new Exception("Invalid Pattern Id");
        
        return new(value,id);        
    }
}