using MDDPlatform.ModelTransformations.Application.DTO.External;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Application.ReadModels;
public class ModelInfo : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public Guid LanguageId {get; set;}
    public string LaguageName {get;  set;}
    public bool IsBuiltin {get;set;}

    public ModelInfo(Guid id,string name, string type, Guid languageId, string laguageName, bool isBuiltin)
    {
        Id = id;
        Name = name;
        Type = type;
        LanguageId = languageId;
        LaguageName = laguageName;
        IsBuiltin = isBuiltin;
    }
    public static ModelInfo CreateFrom(ModelDto model)
    {
        return new ModelInfo(model.Id,model.Name,model.Type,model.Language.Id,model.Language.Name,model.Language.IsBuiltin);    
    }
}