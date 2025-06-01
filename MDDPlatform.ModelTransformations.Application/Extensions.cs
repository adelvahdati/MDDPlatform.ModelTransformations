using System.Text;
using MDDPlatform.ModelTransformations.Application.DTO.Elements;
using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;

namespace MDDPlatform.ModelTransformations.Application;
public static class Extensions{
    public static StringBuilder AppendIndented(this StringBuilder sb, string textBlock)
    {
        foreach (var line in textBlock.TrimEnd().Split('\n'))
        {
            if (!string.IsNullOrWhiteSpace(line))
                sb.AppendLine($"\t{line}");
        }
        return sb;
        
    }
    public static Dictionary<string,string> ToKeyValueExpressionResolver(this DomainObjectDto domainObject, string variableName)
    {
        Dictionary<string,string> keyValues = new();
        string key = string.Format("{0}.{1}",variableName,"Name");
        string? value = domainObject.InstanceName;
        keyValues.Add(key,value);

        foreach(var prop in domainObject.Properties)
        {
            value = prop.Value;
            if(value!=null)
            {
                key = string.Format("{0}.{1}",variableName,prop.Name);
                if(!keyValues.ContainsKey(key))
                    keyValues.Add(key,value);
            }    
        }
        foreach(var rel in domainObject.Relations)
        {
            if(rel.TargetInstances.Count>0)
            {
                key = string.Format("{0}.{1}({2})",variableName,rel.RelationName,rel.RelationTarget);
                value = string.Join(",",rel.TargetInstances);
                if(!keyValues.ContainsKey(key))
                    keyValues.Add(key,value);
            }
        }
        return keyValues;
    }
    public static Dictionary<string,string> ToKeyValueExpressionResolver(this ElementDto element, string variableName)
    {
        Dictionary<string,string> keyValues = new();
        string key = string.Format("{0}.{1}",variableName,"Name");
        string? value = element.Name;
        keyValues.Add(key,value);

        key = string.Format("{0}.{1}",variableName,"Type");
        value = element.Type;
        return keyValues;
    }
    public static Dictionary<string,string> AppendKeyValues(this Dictionary<string,string> keyValues , Dictionary<string,string> otherKeyValues)
    {
        foreach(var item in otherKeyValues)
        {
            keyValues.Add(item.Key,item.Value);
        }
        return keyValues;
    }
    public static string ResolveExpression(this string expression, Dictionary<string,string> keyValues)
    {
        
        string expr = expression;
        var terms = expression.Split('+');        
        foreach(var term in terms)
        {
            if(keyValues.ContainsKey(term))
                expr = expr.Replace(term,keyValues[term]);
        }
        expr = expr.Replace("+","");
        return expr;        
    }
}