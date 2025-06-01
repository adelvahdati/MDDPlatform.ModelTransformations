namespace MDDPlatform.ModelTransformations.Application.DTO.Elements;
public class RelationDto{
    public string Name { get; set; }
    public string Target { get; set; }
    public string Multiplicity { get; set; }

    public RelationDto(string name, string target, string multiplicity)
    {
        Name = name;
        Target = target;
        Multiplicity = multiplicity;
    }

}