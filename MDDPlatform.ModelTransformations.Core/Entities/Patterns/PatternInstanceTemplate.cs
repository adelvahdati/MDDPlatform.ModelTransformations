using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Core.ValueObjects;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class PatternInstanceTemplate : BaseEntity<Guid>
{
    private List<FieldValue> _fieldValues;
    private List<Field> _variables;

    public Guid PatternId {get;private set;}
    public string PatternName {get;private set;}
    public string PatternCategory {get;private set;}
    public string Title {get;private set;}
    public string Name {get;private set;}
    public IReadOnlyList<FieldValue> FieldValues => _fieldValues;
    public IReadOnlyList<Field> Variables => _variables;

    private PatternInstanceTemplate(Guid patternId, string patternName, string patternCategory, string title,string name,List<FieldValue> fieldValues, List<Field> variables)
    {
        Id = Guid.NewGuid();
        PatternId = patternId;
        PatternName = patternName;
        PatternCategory = patternCategory;
        Title = title;
        Name = name;
        _fieldValues = fieldValues;
        _variables = variables;
    }
    private PatternInstanceTemplate(Guid id,Guid patternId, string patternName, string patternCategory, string title,string name,List<FieldValue> fieldValues, List<Field> variables)
    {
        Id = id;
        PatternId = patternId;
        PatternName = patternName;
        PatternCategory = patternCategory;
        Title = title;
        Name = name;
        _fieldValues = fieldValues;
        _variables = variables;
    }
    public static PatternInstanceTemplate CreateFrom(Pattern pattern, PatternInstance pattrenInstance,string? componentTitle = null,string? componentName =null)
    {
        if(pattern.Id != pattrenInstance.Template.PatternId || pattern.Name.ToLower()!=pattrenInstance.Template.PatternName.ToLower())
            throw new Exception("Mismatch between pattern and pattern instance");
        
        var title = string.IsNullOrEmpty(componentTitle)? pattrenInstance.Title : componentTitle;
        var name = string.IsNullOrEmpty(componentName)? pattrenInstance.Name : componentName;
        var fieldValues = new List<FieldValue>();
        var variables = new List<Field>();
        foreach(var field in  pattern.Fields)
        {
            if(field.Type == FieldType.InputModel || field.Type == FieldType.OutputModel)
                variables.Add(field);
            else
            {
                var fieldValue = pattrenInstance.GetFieldValue(field.Name);
                if(Equals(fieldValue,null))
                    throw new Exception("Mismatch between pattern and pattern instance");
                
                fieldValues.Add(fieldValue);
            }
        }

        return new PatternInstanceTemplate(pattern.Id,pattern.Name,pattern.Category,title,name,fieldValues,variables);        
    }
    public static PatternInstanceTemplate CreateFrom(Guid patternInstanceTemplateId,Pattern pattern, PatternInstance pattrenInstance,string? componentTitle = null,string? componentName =null)
    {
        if(pattern.Id != pattrenInstance.Template.PatternId || pattern.Name.ToLower()!=pattrenInstance.Template.PatternName.ToLower())
            throw new Exception("Mismatch between pattern and pattern instance");
        
        var title = string.IsNullOrEmpty(componentTitle)? pattrenInstance.Title : componentTitle;
        var name = string.IsNullOrEmpty(componentName)? pattrenInstance.Name : componentName;
        var fieldValues = new List<FieldValue>();
        var variables = new List<Field>();
        foreach(var field in  pattern.Fields)
        {
            if(field.Type == FieldType.InputModel || field.Type == FieldType.OutputModel)
                variables.Add(field);
            else
            {
                var fieldValue = pattrenInstance.GetFieldValue(field.Name);
                if(Equals(fieldValue,null))
                    throw new Exception("Mismatch between pattern and pattern instance");
                
                fieldValues.Add(fieldValue);
            }
        }

        return new PatternInstanceTemplate(patternInstanceTemplateId,pattern.Id,pattern.Name,pattern.Category,title,name,fieldValues,variables);        
    }

    public static PatternInstanceTemplate Load(Guid id, Guid patternId, string patternName, string patternCategory, string title, string name, List<FieldValue> fieldValues, List<Field> variables)
    {
        return new PatternInstanceTemplate(id,patternId,patternName,patternCategory,title,name,fieldValues,variables);                
    }
    public bool IsSimilarTo(PatternInstanceTemplate template){
        if(PatternId != template.PatternId)
            return false;
        if(PatternName != template.PatternName)
            return false;
        if(PatternCategory !=template.PatternCategory)
            return false;
        if(Title !=template.Title)
            return false;
        if(Name !=template.Name)
            return false;
        
        var currenFieldValue = _fieldValues.ToHashSet();
        var otherFeildValue = template.FieldValues.ToHashSet();
        if(currenFieldValue != otherFeildValue)
            return false;
        
        var currentVariables = _variables.ToHashSet();
        var otherVariables = template.Variables.ToHashSet();
        if(currentVariables!=otherVariables)
            return false;
    
        return true;
    }
}