using MDDPlatform.DataStorage.MongoDB;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Extensions.Handlers;
using MDDPlatform.ModelTransformations.Application.Services.External;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders;
using MDDPlatform.ModelTransformations.Infrastructure.ExternalServices;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.SharedKernel.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Infrastructure.Initializers;
using MDDPlatform.ModelTransformations.Services.DomainServices;
using MDDPlatform.ModelTransformations.Services.Builders;
using MDDPlatform.ModelTransformations.Application.Factories;
using MDDPlatform.ModelTransformations.Application.ReadModels.Repositories;
using MDDPlatform.ModelTransformations.Application.Interfaces;
using MDDPlatform.ModelTransformations.Application.TextGenerators.CSharp;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders.PatternTemplates;
using MDDPlatform.ModelTransformations.Application.TextGenerators.TypeMappers;

namespace MDDPlatform.ModelTransformations.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHandlers();
        services.AddHostedService<AppInitializer>();
        services.AddRabbitMQ(configuration,"rabbitmq");
        services.AddMongoDB(configuration,"mongodb");
        services.AddMongoRespository<PatternDocumnet,Guid>("Patterns");
        services.AddMongoRespository<PatternInstanceDocument,Guid>("PatternInstances");
        services.AddMongoRespository<PatternInstanceInfoDocument,Guid>("PatternInstancesInfo");
        services.AddMongoRespository<PatternInstanceTemplateDocument,Guid>("PatternInstanceTemplates");
        services.AddMongoRespository<PipelineDocument,Guid>("Pipelines");
        services.AddMongoRespository<ScriptDocument,Guid>("Scripts");
        services.AddMongoRespository<ProcessDocument,Guid>("Processes");
        services.AddMongoRespository<ProcessConfigurationDocument,Guid>("ProcessConfigurations");
        services.AddMongoRespository<ExecutableProcessDocument,Guid>("ExcutableProcesses");
        services.AddMongoRespository<SagaDocument,Guid>("TransformationSaga");

        services.AddSingleton<IEventMapper,DefaultEventMapper>();

        services.AddScoped<IPatternRepository,PatternRepository>();
        services.AddScoped<IPatternInstanceRepository,PatternInstanceRepository>();
        services.AddScoped<IPatternInstanceInfoRepository,PatternInstanceInfoRepository>();
        services.AddScoped<IPatternInstanceTemplateRepository,PatternInstanceTemplateRepository>();
        services.AddScoped<IPipelineRepository,PipelineRepository>();
        services.AddScoped<IScriptRepository,ScriptRepository>();
        services.AddScoped<IProcessRepository,ProcessRepository>();
        services.AddScoped<IProcessConfigurationRepository,ProcessConfigurationRepository>();
        services.AddScoped<IExecutableProcessRepository,ExecutableProcessRepository>();
        services.AddScoped<ISagaRepository,SagaRepository>();
        
        
        services.AddScoped<IPatternInstanceTemplateRgistry,PatternInstanceTemplateRegistry>();
        services.AddScoped<IDataSeeder,DataSeeder>();

        services.AddScoped<ITypeMapper,CSharpTypeMapper>();
        services.AddScoped<ITextGenerator,CSharpCodeGenerator>();

        services.AddSingleton<ITemplateFileManager,TemplateFileManager>();

        services.AddHttpClient<IDomainService,DomainService>
        (
            httpClient=>
            {
                // var url = "http://localhost:5271";
                var url = configuration["Services:DomainService"];
                httpClient.BaseAddress = new Uri(url);
            }
        );

        services.AddHttpClient<IDomainModelService,DomainModelService>
        (
            httpClient=>
            {
                // var url = "http://localhost:5173";
                var url = configuration["Services:DomainModelService"];
                httpClient.BaseAddress = new Uri(url);
            }
        );

        services.AddHttpClient<IScriptRunner,ScriptRunner>
        (
            httpClient=>
            {
                // var url = "http://localhost:5173";
                var url = configuration["Services:DomainModelService"];
                httpClient.BaseAddress = new Uri(url);
            }
        );


        services.AddHttpClient<IDomainModelReader,DomainModelReader>
        (
            httpClient=>
            {
                // var url = "http://localhost:5173";
                var url = configuration["Services:DomainModelService"];
                httpClient.BaseAddress = new Uri(url);
            }
        );
        services.AddHttpClient<IDomainModelWriter,DomainModelWriter>
        (
            httpClient=>
            {
                // var url = "http://localhost:5173";
                var url = configuration["Services:DomainModelService"];
                httpClient.BaseAddress = new Uri(url);
            }
        );


        services.AddScoped<ITransformationService,TransformationService>();

        services.AddScoped<IPatternService,PatternService>();
        services.AddScoped<IPatternInstanceService,PatternInstanceService>();
        services.AddScoped<IPatternInstanceTemplateService,PatternInstanceTemplateService>();
        
        services.AddSingleton<ITransformationRequestRegistry,TransformationRequestRegistry>();
        services.AddSingleton<ITransformationRequestBuilder,TransformationRequestBuilder>();

        services.AddScoped<IPipelineExecutor,PipelineExecutor>();
        services.AddScoped<IProcessExecutor,ProcessExecutor>();
        return services;
    }
}