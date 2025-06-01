namespace MDDPlatform.ModelTransformations.Api.CodeGenerators;
public class ArchiveProjectCodeRequest
{
    public Guid DomainModelId { get; set;}
    public string FileConcept { get; set;}
    public string FileNameProperty { get; set;}
    public string FileContentProperty { get; set;}
    public string FileExtensionProperty { get; set;}
    public string RelativePathProperty { get; set;}

    public ArchiveProjectCodeRequest(Guid DomainModelId, string FileConcept,string FileNameProperty, string FileContentProperty, string FileExtensionProperty, string RelativePathProperty){
        this.DomainModelId = DomainModelId;
        this.FileConcept = FileConcept;
        this.FileNameProperty = FileNameProperty;
        this.FileContentProperty = FileContentProperty;
        this.FileExtensionProperty = FileExtensionProperty;
        this.RelativePathProperty = RelativePathProperty;
    }
}