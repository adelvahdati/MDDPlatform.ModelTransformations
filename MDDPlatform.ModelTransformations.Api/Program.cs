using MDDPlatform.ModelTransformations.Api.CodeGenerators;
using MDDPlatform.ModelTransformations.Api.Hubs;
using MDDPlatform.ModelTransformations.Api.Middlewares;
using MDDPlatform.ModelTransformations.Api.Services;
using MDDPlatform.ModelTransformations.Infrastructure;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options=>{
    options.AddPolicy("APIClient",policy=>{
        policy.WithOrigins("http://localhost:6094","https://localhost:7021")
                .AllowAnyHeader()
                .AllowAnyMethod();                
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Services.AddSingleton<IPipelineNotificationService,PipelineNotificationService>();
builder.Services.AddSingleton<IProcessNotificationService,ProcessNotificationService>();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<ICodeGenerator,CodeGenerator>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();


app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("APIClient");

app.UseAuthorization();
app.UseEndpoints(endpoint =>{
    endpoint.MapGet("/", () => {
        return "Hello world! MDDPlatform.ModelTransformations is running";
    } );
});
app.MapControllers();
app.MapHub<PipelineHub>("/pipelinehub");
app.MapHub<ProcessHub>("/processhub");

app.Run();
