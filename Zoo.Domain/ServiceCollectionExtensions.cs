using Microsoft.Extensions.DependencyInjection;
using Zoo.Domain.Events;

namespace Zoo.Domain;

using Animals;
using Enclosures;
using Feeding;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        // services.AddSingleton<IEnclosure, Enclosure>();
        // services.AddSingleton<IAnimal, Animal>();
        services.AddSingleton<IFeedingSchedule, FeedingSchedule>();
        services.AddSingleton<IFeedingEvent, FeedingEvent>();
        services.AddSingleton<ITransferEvent, TransferEvent>();
        return services;
    }
}