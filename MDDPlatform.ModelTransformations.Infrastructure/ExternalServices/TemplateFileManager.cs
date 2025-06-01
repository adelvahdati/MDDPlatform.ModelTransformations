using System.IO.Compression;
using MDDPlatform.ModelTransformations.Application.Interfaces;

namespace MDDPlatform.ModelTransformations.Infrastructure.ExternalServices;
public class TemplateFileManager : ITemplateFileManager
{
    public async Task<string> GetFileContentAsync(string templateArchiveId, string fileId)
    {
        string zipPath = GetArchivePath(templateArchiveId);
        string filePath = GetFilePath(templateArchiveId,fileId);
        using (var archive = ZipFile.OpenRead(zipPath))
        {
            Console.WriteLine($"Zip Path {zipPath}");
            Console.WriteLine($"File Path {zipPath}");
            archive.Entries.ToList().ForEach(ent=>Console.WriteLine($"Entry FullName {ent.FullName}"));
            var templateEntry = archive.Entries.Where(entry=>entry.FullName == filePath).FirstOrDefault();
            if(templateEntry==null)
            {
                Console.WriteLine("Template Not Found");
                throw new Exception("Template Not Found");
            }            
            else
            {
                using (var stream = templateEntry.Open())
                {
                    using(var reader = new StreamReader(stream))
                    {
                        var content = await reader.ReadToEndAsync();
                        return content;
                    }
                }                
            }

        }
        


    }
    private string GetArchivePath(string templateArchiveId)
    {
        return string.Format("Templates/{0}.zip",templateArchiveId);
    }
    private string GetFilePath(string templateArchiveId,string fileId)
    {
        return string.Format("EmptyProject/{0}",fileId);
    }
}
