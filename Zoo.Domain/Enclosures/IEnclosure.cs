using Zoo.Domain.Animals;

namespace Zoo.Domain.Enclosures;
using Models;

public interface IEnclosure
{
    IEnumerable<Guid> GetAllAnimalIds();
    void AddAnimal(Guid animalId);
    bool DeleteAnimal(Guid animalId);
    
    bool IsFull();
    int GetAnimalCount();
    
    Guid Id { get; }
    AnimalType Type { get; }
    int Capacity { get; }
}