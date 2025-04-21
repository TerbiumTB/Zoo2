using System.Net.Mime;
using Zoo.Domain.Events;
using Zoo.Infrastructure.Events;

namespace Zoo.Tests;

using App.Animals;
using Domain.Feeding;
using Domain.Models;
using App;
using App.Feeding;
// using In
using Infrastructure.Animals;

public class FeedTest
{
    [Fact]
    public void FeedTest1()
    {
        Food meat = new Food("meat", AnimalType.Predator);
        Food carrot = new Food("carrot", AnimalType.Herbo);
        Food fish = new Food("fish", AnimalType.Aquatic);

        Species species = new Species("Tralalelo", AnimalType.Aquatic);

        var animalFactory = new AnimalFactory();
        var animal = animalFactory.Create("Tralalala", species, new DateOnly(2020, 01, 01), meat);

        AnimalRepository animalRepo = new AnimalRepository();

        animalRepo.Add(animal);

        FeedingSchedule schedule = new FeedingSchedule();

        schedule.SetFeedingPlan(new FeedingPlan(animal.Id, TimeSpan.FromMicroseconds(2), meat));


        FeedingEvent feedingEvent = new FeedingEvent();
        FeedingEventLogger feedingLogger = new FeedingEventLogger();
        feedingLogger.Listen(feedingEvent);
        FeedingOrganizationService feedingOrganization = new FeedingOrganizationService(schedule, animalRepo, feedingEvent);
        
        Assert.True(feedingOrganization.Feed(animal.Id));

        Assert.True(feedingOrganization.UpdateFeedingFoodType(animal.Id, fish));
        Assert.True(feedingOrganization.Feed(animal.Id));


        feedingOrganization.UpdateFeedingFoodType(animal.Id, carrot);
        Assert.False(feedingOrganization.Feed(animal.Id));

        feedingOrganization.UpdateFeedingFoodType(animal.Id, fish);
        feedingOrganization.UpdateFeedingInterval(animal.Id, TimeSpan.FromHours(2));
        Assert.False(feedingOrganization.Feed(animal.Id));
    }

    [Fact]
    public void FeedTestAll()
    {
        Food meat = new Food("meat", AnimalType.Predator);
        Food carrot = new Food("carrot", AnimalType.Herbo);
        Food fish = new Food("fish", AnimalType.Aquatic);

        
        Species tralalelo = new Species("Tralalelo", AnimalType.Aquatic);
        Species gusini = new Species("Gusini", AnimalType.Flying);

        var animalFactory = new AnimalFactory();

        var animal1 = animalFactory.Create("Tralalala", tralalelo, new DateOnly(2020, 01, 01), meat);
        var animal2 = animalFactory.Create("Bombordini", gusini, new DateOnly(2020, 02, 01), carrot);

        AnimalRepository animalRepo = new AnimalRepository();
        animalRepo.Add(animal1);
        FeedingSchedule schedule = new FeedingSchedule();

        schedule.SetFeedingPlan(new FeedingPlan(animal1.Id, TimeSpan.FromMicroseconds(2), meat));
        schedule.SetFeedingPlan(new FeedingPlan(animal2.Id, TimeSpan.FromMicroseconds(2), carrot));

        FeedingEvent feedingEvent = new FeedingEvent();
        FeedingEventLogger feedingLogger = new FeedingEventLogger();
        feedingLogger.Listen(feedingEvent);
        FeedingOrganizationService feedingOrganization = new FeedingOrganizationService(schedule, animalRepo, feedingEvent);

        feedingOrganization.FeedAll();
        Assert.True(feedingOrganization.GetAllHungry().ToList().Count == 0);
    }
}