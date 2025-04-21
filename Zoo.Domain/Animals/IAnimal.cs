namespace Zoo.Domain.Animals;
using Models;

public interface IAnimal
{
    Guid Id { get; }
    string NickName { get; }
    Species Species { get; }
    DateOnly Birthday { get; }
    
    bool IsHungry { get; }
    DateTime LastFed { get; }

    
    Food FavouriteFood { get; }
    Guid EnclosureId { get; }
    
    void Feed(Food food, DateTime feedingTime);
    
    void Move(Guid enclosureId);
    
}