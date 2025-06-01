using MDDPlatform.ModelTransformations.Application.DTO.External.DomainObjects;

namespace MDDPlatform.ModelTransformations.Api.CodeGenerators;
public static class Extensions{
    public static string GetFileName(this DomainObjectDto domainObject,string FileNameProperty)
    {
        var fileName = domainObject.GetPropertyValue(FileNameProperty);
        if(fileName!=null)
            return fileName;

        return string.Format("{0}_{1}",domainObject.InstanceName,domainObject.Id);
    }
    public static string GetFileNameExtension(this DomainObjectDto domainObject, string FileExtensionProperty)
    {
        var extension = domainObject.GetPropertyValue(FileExtensionProperty);
        if(extension==null)
            return "txt";
        
        if(extension.StartsWith("."))
            extension = extension.Replace(".","");

        if(extension.StartsWith("*."))
            extension = extension.Replace("*.","");
        
        if(string.IsNullOrEmpty(extension))
            return "txt";
        
        return extension;

    }
    public static string GetFileContent(this DomainObjectDto domainObject,string FileContentProperty)
    {
        var content = domainObject.GetPropertyValue(FileContentProperty);
        if(content!=null)
            return content;

        return string.Empty;
    }
    public static string GetFileRelativePath(this DomainObjectDto domainObject,string RelativePathProperty)
    {
        var path = domainObject.GetPropertyValue(RelativePathProperty);
        if(path ==null)
            return string.Empty;

        if(path.StartsWith("./"))
            path = path.Replace("./","");
        return path;
    }

    private static string? GetPropertyValue(this DomainObjectDto domainObject,string propertyName)
    {
        var property = domainObject.Properties.FirstOrDefault(prop=>prop.Name.ToLower().Trim() == propertyName.ToLower().Trim());
        if(property !=null)
            return property.Value;
        
        return null;
    }

}