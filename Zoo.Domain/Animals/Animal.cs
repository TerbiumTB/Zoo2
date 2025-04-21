namespace Zoo.Domain.Animals;

using Models;

public class Animal : IAnimal
{
    public Guid Id { get; private set; }
    public string NickName { get; private set; }
    public Species Species { get; private set; }
    public DateOnly Birthday { get; }

    public Guid EnclosureId { get; private set; }
    public Food FavouriteFood { get; private set; }
    public DateTime LastFed { get; private set; }
    
    public bool IsHungry => DateTime.Now - LastFed > TimeSpan.FromDays(1);


    public Animal(Guid id, string nickName, Species species, DateOnly birthday, Food favouriteFood, DateTime lastFed, Guid enclosureId)
    {
        Id = id;
        NickName = nickName;
        Species = species;
        EnclosureId = enclosureId;
        Birthday = birthday;
        FavouriteFood = favouriteFood;
        LastFed = lastFed;
    }
    
    public void Feed(Food food, DateTime feedingTime) => LastFed = feedingTime;

    public void Move(Guid enclosureId) => EnclosureId = enclosureId;
}