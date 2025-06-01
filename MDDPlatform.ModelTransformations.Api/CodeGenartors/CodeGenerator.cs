using System.IO.Compression;
using MDDPlatform.ModelTransformations.Application.Services.External;

namespace MDDPlatform.ModelTransformations.Api.CodeGenerators;
public class CodeGenerator : ICodeGenerator
{
    private IDomainModelReader _reader;

    public CodeGenerator(IDomainModelReader reader)
    {
        _reader = reader;
    }

    public async Task CreateProjectAsync(Guid DomainModelId, string FileConcept,string FileNameProperty, string FileContentProperty, string FileExtensionProperty, string RelativePathProperty)
    {
        string templateProjectPath = "Templates/EmptyProject.zip";
        string templateProjectRootPath = "EmptyProject/";

        var ignoreFiles = await GetIngnoreFiles();
        
        
        var zipFilePath = GetProjectZipFilePath(DomainModelId);
        var domainObjects = await _reader.GetDomainObjectsAsync(DomainModelId,FileConcept);
        if(domainObjects== null)
            throw new Exception("Project File Not Found");

        
        if(!Directory.Exists(GetArchiveDirectory()))
            Directory.CreateDirectory(GetArchiveDirectory());

        if (File.Exists(zipFilePath))
            File.Delete(zipFilePath);        

        using (ZipArchive archive =ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
        {
            // Copy Default Template Files
            var templateArchive = ZipFile.OpenRead(templateProjectPath);
            foreach(var entry in templateArchive.Entries)
            {
                var item = entry.FullName.Replace(templateProjectRootPath,"");
                var ignored = ignoreFiles.Any(file=>file.ToLower() == item.ToLower());
                if(!ignored)
                {
                    var destinationEntry = archive.CreateEntry(item);
                    using(StreamWriter writer = new StreamWriter(destinationEntry.Open()))
                    {
                        using(var reader = new StreamReader(entry.Open()))
                        {
                            var content = await reader.ReadToEndAsync();
                            await writer.WriteAsync(content);
                        }
                        
                    }
                }
            }

            // Copy Project Files
            foreach(var domainObject in domainObjects)
            {
                string fileName = domainObject.GetFileName(FileNameProperty);
                string extension = domainObject.GetFileNameExtension(FileExtensionProperty);
                string content = domainObject.GetFileContent(FileContentProperty);
                string relativePath = domainObject.GetFileRelativePath(RelativePathProperty);
                string path;
                if(relativePath.EndsWith("/"))
                    path = string.Format("{0}{1}.{2}",relativePath,fileName,extension);
                else
                    path = string.Format("{0}/{1}.{2}",relativePath,fileName,extension);
                
                var destinationEntry = archive.CreateEntry(path);
                using(StreamWriter writer = new StreamWriter(destinationEntry.Open()))
                {
                    await writer.WriteAsync(content);
                }
            }
        }
        
    }

    public string GetArchiveDirectory()
    {
        return "Contents";
    }

    public string GetProjectZipFileName(Guid DomainModelId)
    {
        return string.Format("archive-{0}.zip",DomainModelId);
    }

    public string GetProjectZipFilePath(Guid DomainModelId)
    {
        var acrhiveDirectory = GetArchiveDirectory();
        var zipFileName = GetProjectZipFileName(DomainModelId);
        return string.Format("{0}/{1}",acrhiveDirectory,zipFileName);
    }
    private async Task<List<string>> GetIngnoreFiles(){
        var ignoreFile = System.IO.File.OpenRead("Templates/.ignore");
        var reader = new StreamReader(ignoreFile);
        var files = new List<string>();
        while(!reader.EndOfStream){
            var line = await reader.ReadLineAsync();
            if(!string.IsNullOrEmpty(line))
                files.Add(line);
        }
        return files;
    }
}

