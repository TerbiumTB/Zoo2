namespace Zoo.App.Animals;

using Domain.Animals;
using Domain.Models;

public interface IAnimalFactory
{
    public IAnimal Create(string nickName, Species species, DateOnly birthday, Food favoriteFood);
}