using Zoo.App.Animals;
using Zoo.Domain.Models;
using Zoo.Infrastructure.Animals;
using Zoo.Infrastructure.Enclosures;
using Zoo.App.Enclosures;
using Zoo.App.Feeding;

namespace Zoo.Tests;

public class AnimalTest
{
    [Fact]
    public void AnimalTest1()
    {
        AnimalFactory factory = new AnimalFactory();
        AnimalRepository repo = new AnimalRepository();
        
        var meat1 = new Food("meat", AnimalType.Predator);
        Species species = new Species("Tralalelo", AnimalType.Aquatic);

        DateOnly date = new DateOnly(2020, 01, 01);
        
        var animal = factory.Create("Tralalala", species, date, meat1);
        
        var meat2 = new Food("meat", AnimalType.Predator);
        
        animal.Feed(meat2, DateTime.Now);

        Assert.True(animal.NickName == "Tralalala");
    }
    
    [Fact]
    public void AnimalTestRepo()
    {
        AnimalFactory factory = new AnimalFactory();
        AnimalRepository repo = new AnimalRepository();
        
        var meat1 = new Food("meat", AnimalType.Predator);
        Species species = new Species("Tralalelo", AnimalType.Aquatic);

        DateOnly date = new DateOnly(2020, 01, 01);
        
        var animal = factory.Create("Tralalala", species, date, meat1);
        
        repo.Add(animal);
        Assert.NotNull(repo.GetById(animal.Id));
        
        repo.Delete(animal.Id);
        Assert.Null(repo.GetById(animal.Id));
        
    }
    
    [Fact]
    public void AnimalTestService()
    {
        AnimalFactory animalFactory = new AnimalFactory();
        AnimalRepository animalRepo = new AnimalRepository();
        EnclosureFactory enclosureFactory = new EnclosureFactory();
        
        
        var meat1 = new Food("meat", AnimalType.Predator);
        Species species = new Species("Tralalelo", AnimalType.Aquatic);

        DateOnly date = new DateOnly(2020, 01, 01);
        
        var animal = animalFactory.Create("Tralalala", species, date, meat1);
        
        animalRepo.Add(animal);
        Assert.NotNull(animalRepo.GetById(animal.Id));
        
        animalRepo.Delete(animal.Id);
        Assert.Null(animalRepo.GetById(animal.Id));
        
    }
}