namespace MDDPlatform.ModelTransformations.Api.CodeGenerators;
public interface ICodeGenerator
{
    Task CreateProjectAsync(Guid DomainModelId, string FileConcept,string FileNameProperty, string FileContentProperty, string FileExtensionProperty, string RelativePathProperty);
    string GetProjectZipFilePath(Guid DomainModelId);
    string GetProjectZipFileName(Guid DomainModelId);
    string GetArchiveDirectory();
}
