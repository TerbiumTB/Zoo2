using Zoo.App.Feeding;

namespace Zoo.App;

using Microsoft.Extensions.DependencyInjection;

using Animals;
using Enclosures;
using Statistics;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddSingleton<IAnimalFactory, AnimalFactory>();
        services.AddSingleton<IEnclosureFactory, EnclosureFactory>();
        
        services.AddSingleton<IFeedingOrganizationService, FeedingOrganizationService>();
        services.AddSingleton<IAnimalService, AnimalService>();
        services.AddSingleton<IEnclosureService, EnclosureService>();
        services.AddSingleton<IStatisticsService, StatisticsService>();
        
        
        return services;
    }
}