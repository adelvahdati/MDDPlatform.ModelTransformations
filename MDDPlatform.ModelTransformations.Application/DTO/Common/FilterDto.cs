namespace MDDPlatform.ModelTransformations.Application.DTO.Common;
public class FilterDto<T>
{
    public T? Value {get;set;}
    public bool IsApplied {get;set;}

    public FilterDto(T? value, bool isApplied)
    {
        Value = value;
        IsApplied = isApplied;
    }
    public static FilterDto<T> DontCare(){
        return new FilterDto<T>(default,false);
    }
    public static FilterDto<T> Create(T value){
        if(Equals(value,null))
            return DontCare();
        
        return new FilterDto<T>(value,true);
    }

}