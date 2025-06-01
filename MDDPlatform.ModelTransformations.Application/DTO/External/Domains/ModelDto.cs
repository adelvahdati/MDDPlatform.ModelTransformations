namespace MDDPlatform.ModelTransformations.Application.DTO.External;
public class ModelDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Type { get; set; }
    public int Level { get; set; }
    public LanguageDto Language { get; set; }
    public ModelDto(Guid id, string name, string tag, string type, int level, LanguageDto language)
    {
        Id = id;
        Name = name;
        Tag = tag;
        Type = type;
        Level = level;
        Language = language;
    }
}
