namespace Zoo.App.Animals;

using Domain.Animals;
using Domain.Models;

public class AnimalFactory: IAnimalFactory
{
    public IAnimal Create(string nickName, Species species, DateOnly birthday, Food favoriteFood)
    {
        return new Animal(Guid.NewGuid(), nickName, species, birthday, favoriteFood, DateTime.MinValue,Guid.Empty);
    }
}