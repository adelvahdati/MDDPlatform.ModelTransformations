using MDDPlatform.ModelTransformations.Application.ReadModels;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
public class ModelInfoDocument : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public Guid LanguageId {get; set;}
    public string LaguageName {get;  set;}
    public bool IsBuiltin {get;set;}

    public ModelInfoDocument(Guid id,string name, string type, Guid languageId, string laguageName, bool isBuiltin)
    {
        Id = id;
        Name = name;
        Type = type;
        LanguageId = languageId;
        LaguageName = laguageName;
        IsBuiltin = isBuiltin;
    }
    public static ModelInfoDocument CreateFrom(ModelInfo modelInfo)
    {
        return new(modelInfo.Id,modelInfo.Name,modelInfo.Type,modelInfo.LanguageId,modelInfo.LaguageName,modelInfo.IsBuiltin);
    }
    public ModelInfo ToModelInfo()
    {
        return new ModelInfo(Id,Name,Type,LanguageId,LaguageName,IsBuiltin);
    }
}