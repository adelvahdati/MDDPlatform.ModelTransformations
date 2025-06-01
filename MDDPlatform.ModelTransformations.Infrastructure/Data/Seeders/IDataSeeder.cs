namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders;
public interface IDataSeeder
{
    Task SeedPatternsAsync();
    Task SeedPatternInstanceTemplatesAsync();
    Task SeedProcessAsync();
}