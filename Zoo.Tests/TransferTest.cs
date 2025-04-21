using System.Net.Mime;
using Zoo.App.Feeding;
using Zoo.Domain.Feeding;

namespace Zoo.Tests;

using App.Animals;
using App.Enclosures;

using Domain.Events;

using Domain.Models;
using Infrastructure.Animals;
using Infrastructure.Enclosures;
using Infrastructure.Events;

public class TransferTest
{
    
    [Fact]
    public void TransferTest1()
    {
        Food meat = new Food("meat", AnimalType.Aquatic);
        Species species = new Species("Tralalelo", AnimalType.Aquatic);

        var animalFactory = new AnimalFactory();
        var animal = animalFactory.Create("Tralalala", species, new DateOnly(2020, 01, 01), meat);

        AnimalRepository animalRepo = new AnimalRepository();

        animalRepo.Add(animal);

        EnclosureRepository enclosureRepo = new EnclosureRepository();
        
        var enclosureFactory = new EnclosureFactory();
        
        enclosureRepo.Add(
            enclosureFactory.Create(AnimalType.Aquatic, 10));
        
        enclosureRepo.Add(
            enclosureFactory.Create(AnimalType.Aquatic, 2));
        
        enclosureRepo.Add(
            enclosureFactory.Create(AnimalType.Predator, 3));  
        
        enclosureRepo.Add(
            enclosureFactory.Create(AnimalType.Predator, 0));

        var enclosures = enclosureRepo.GetAll().ToList();
        FeedingEvent feedingEvent = new FeedingEvent();
        FeedingEventLogger feedingLogger = new FeedingEventLogger();
        feedingLogger.Listen(feedingEvent);
        FeedingSchedule schedule = new FeedingSchedule();
        
        FeedingOrganizationService feedingOrganization = new FeedingOrganizationService(schedule, animalRepo, feedingEvent);
        TransferEventListener transferEventListener = new TransferEventListener();
        
        TransferEvent transferEvent = new TransferEvent();
        transferEventListener.Listen(transferEvent);
        
        AnimalService transferService = new AnimalService(animalFactory, animalRepo, enclosureRepo, feedingOrganization, transferEvent);
        
        Assert.True(transferService.TransferAnimal(animal.Id, enclosures[0].Id));
        Assert.True(transferService.TransferAnimal(animal.Id, enclosures[1].Id));
        Assert.False(transferService.TransferAnimal(animal.Id, enclosures[2].Id));
        Assert.False(transferService.TransferAnimal(animal.Id, enclosures[3].Id));
    }
    
}