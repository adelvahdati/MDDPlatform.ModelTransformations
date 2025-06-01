namespace MDDPlatform.ModelTransformations.Application.Interfaces;
public interface ITemplateFileManager
{
    Task<string> GetFileContentAsync(string templateArchiveId, string fileId);
}