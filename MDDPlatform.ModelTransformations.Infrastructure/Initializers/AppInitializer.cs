using MDDPlatform.Messages.Brokers;
using MDDPlatform.ModelTransformations.Core.Events;
using MDDPlatform.ModelTransformations.Services.ExternalEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MDDPlatform.ModelTransformations.Infrastructure.Initializers;
public class AppInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public AppInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        IMessageBroker messageBroker = scope.ServiceProvider.GetRequiredService<IMessageBroker>();
        await messageBroker.SubscribeAsync<ModelOperationCompleted>();
        await messageBroker.SubscribeAsync<ModelOperationFailed>();
        await messageBroker.SubscribeAsync<PatternInstanceCreated>();
        await messageBroker.SubscribeAsync<PatternInstanceRemoved>();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
