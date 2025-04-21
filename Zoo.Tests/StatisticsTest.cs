namespace Zoo.Tests;

using App.Statistics;
using App.Animals;
using App.Enclosures;

using Infrastructure.Animals;
using Infrastructure.Enclosures;

using Domain.Animals;
using Domain.Enclosures;
using Domain.Models;

public class StatisticsTest
{
    [Fact]
    public void FeedTest1()
    {
        EnclosureRepository enclosureRepo = new EnclosureRepository();
        AnimalRepository animalRepo = new AnimalRepository();
        
        var enclosureFactory = new EnclosureFactory();
        var animalFactory = new AnimalFactory();
        
        Food meat = new Food("meat", AnimalType.Predator);
        var species = new Species("Tralalelo", AnimalType.Aquatic);
        
        enclosureRepo.Add(enclosureFactory.Create(AnimalType.Predator, 1));
        enclosureRepo.Add(enclosureFactory.Create(AnimalType.Predator, 1));
        enclosureRepo.Add(enclosureFactory.Create(AnimalType.Predator, 1));

        var animalToDelete = animalFactory.Create("Tralalala", species, new DateOnly(2020, 01, 01), meat);
        animalRepo.Add(animalToDelete);
        animalRepo.Add(animalFactory.Create("Tralala", species , new DateOnly(2020, 01, 01), meat));
        animalRepo.Add(animalFactory.Create("Trala", species , new DateOnly(2020, 01, 01), meat));
        
        StatisticsService statisticsService = new StatisticsService(enclosureRepo, animalRepo);
        
        Assert.True(statisticsService.GetTotalAnimalCount() == 3);
        animalRepo.Delete(animalToDelete.Id);
        Assert.True(statisticsService.GetTotalAnimalCount() == 2);
        Assert.True(statisticsService.GetTotalEnclosureCount() == 3);
        
        Assert.True(statisticsService.GetTotalHungryAnimalCount() == 2);
    }
}