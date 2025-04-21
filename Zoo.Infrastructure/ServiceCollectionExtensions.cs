using Zoo.Domain.Events;

namespace Zoo.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

using Animals;
using Enclosures;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAnimalRepository, AnimalRepository>();
        services.AddSingleton<IEnclosureRepository, EnclosureRepository>();
        
        services.AddSingleton<IFeedingEvent, FeedingEvent>();
        services.AddSingleton<ITransferEvent, TransferEvent>();
        return services;
    }
}