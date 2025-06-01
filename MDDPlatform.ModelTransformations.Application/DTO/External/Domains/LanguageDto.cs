namespace MDDPlatform.ModelTransformations.Application.DTO.External;
public class LanguageDto {
    public Guid Id {get; set;}
    public string Name {get;  set;}
    public bool IsBuiltin {get;set;}
    public LanguageDto( Guid id, string name,bool isBuiltin)
    {
        this.Id = id;
        this.Name = name;
        IsBuiltin = isBuiltin;
    }
}