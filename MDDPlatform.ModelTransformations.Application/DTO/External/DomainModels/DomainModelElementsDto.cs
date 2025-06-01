using MDDPlatform.ModelTransformations.Application.DTO.Elements;

namespace MDDPlatform.ModelTransformations.Application.DTO.External.DomainModels;
public class DomainModelElementsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Type { get; set; }
    public int Level { get; set; }
    public Guid DomainId { get; set; }
    public List<ElementDto> Elements {get;set;}
    public DomainModelElementsDto(Guid id, string name, string tag, string type, int level, Guid domainId, List<ElementDto> elements)
    {
        Id = id;
        Name = name;
        Tag = tag;
        Type = type;
        Level = level;
        DomainId = domainId;
        Elements = elements;
    }
}