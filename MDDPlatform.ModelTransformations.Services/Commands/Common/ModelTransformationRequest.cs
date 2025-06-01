using System.Reflection;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ModelTransformations.Core.ValueObjects;

namespace MDDPlatform.ModelTransformations.Services.Commands;
public class ModelTransformationRequest : ICommand
{
    public Guid CoordinationId {get; private set;}
    public Guid StepId {get; private set;}
    protected ModelTransformationRequest(Guid coordinationId,Guid stepId)
    {
        CoordinationId = coordinationId;
        StepId = stepId;
    }
    protected ModelTransformationRequest()
    {
        CoordinationId = Guid.Empty;
        StepId = Guid.Empty;
    }    
    public ModelTransformationRequest Build(List<FieldValue> fieldValues)
    {
        foreach(var fieldValue in fieldValues)
        {
            PropertyInfo? prop = GetType().GetProperty(fieldValue.Name, BindingFlags.Public | BindingFlags.Instance);
            if(prop!= null  && prop.CanWrite)
            {   
                if(prop.PropertyType == typeof(Guid))
                    prop.SetValue(this, Guid.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(int))
                    prop.SetValue(this, int.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(long))
                    prop.SetValue(this, long.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(DateTime))
                    prop.SetValue(this, DateTime.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(Boolean))
                    prop.SetValue(this, Boolean.Parse(fieldValue.Value), null);
                else
                    prop.SetValue(this, fieldValue.Value, null);
            }            
        }
        CoordinationId = Guid.Empty;
        StepId = Guid.Empty;
        return this;        
    }
   public ModelTransformationRequest Build(List<FieldValue> fieldValues,Guid coordinationId, Guid stepId)
    {
        foreach(var fieldValue in fieldValues)
        {
            PropertyInfo? prop = GetType().GetProperty(fieldValue.Name, BindingFlags.Public | BindingFlags.Instance);
            if(prop!= null  && prop.CanWrite)
            {   
                if(prop.PropertyType == typeof(Guid))
                    prop.SetValue(this, Guid.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(int))
                    prop.SetValue(this, int.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(long))
                    prop.SetValue(this, long.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(DateTime))
                    prop.SetValue(this, DateTime.Parse(fieldValue.Value), null);
                else if(prop.PropertyType == typeof(Boolean))
                    prop.SetValue(this, Boolean.Parse(fieldValue.Value), null);
                else
                    prop.SetValue(this, fieldValue.Value, null);
            }            
        }
        CoordinationId = coordinationId;
        StepId = stepId;
        return this;        
    }    
}