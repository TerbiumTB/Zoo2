namespace Zoo.Tests;

using Zoo.App.Animals;
using Zoo.App.Enclosures;
using Domain.Animals;
using Domain.Enclosures;
using Domain.Models;
using App;
// using In
using Infrastructure.Animals;
using Infrastructure.Enclosures;


public class EnclosureTest
{
    [Fact]
    public void EnclosureTest1()
    {
        EnclosureRepository enclosureRepo = new EnclosureRepository();
        
        var enclosureFactory = new EnclosureFactory();

        var enclosure1 = enclosureFactory.Create(AnimalType.Aquatic, 10);
        enclosureRepo.Add(enclosure1);

        var enclosure2 = enclosureFactory.Create(AnimalType.Aquatic, 2);
        enclosureRepo.Add(enclosure2);

        var enclosure3 = enclosureFactory.Create(AnimalType.Predator, 0);
        Assert.NotNull(enclosureRepo.GetById(enclosure1.Id));
        
        enclosureRepo.Delete(enclosure1.Id);
        Assert.Null(enclosureRepo.GetById(enclosure1.Id));
        
        Assert.False(enclosure2.IsFull());
        Assert.True(enclosure3.IsFull());
        
    }
    
}