namespace Zoo.Domain.Enclosures;

using Models;


public class Enclosure : IEnclosure
{
    public Guid Id { get; private set; }
    public AnimalType Type { get; private set; }
    public int Capacity { get; private set; }
    
    private readonly List<Guid> _animals = new();

    public Enclosure(Guid id, AnimalType type, int capacity)
    {
        Id = id;
        Type = type;
        Capacity = capacity;
        // Animals = new List<Animal>();
    }
    public IEnumerable<Guid> GetAllAnimalIds() => _animals;
    public void AddAnimal(Guid animalId) => _animals.Add(animalId);
    public bool IsFull() => _animals.Count >= Capacity;
    public int GetAnimalCount() => _animals.Count;
    
    public bool DeleteAnimal(Guid animalId)
    {
        if (!_animals.Contains(animalId)) return false;
        
        _animals.Remove(animalId);
        return true;

    }
}
