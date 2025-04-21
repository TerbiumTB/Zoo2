namespace Zoo.Infrastructure.Animals;
using Domain.Animals;
// using 

public class AnimalRepository: IAnimalRepository
{
    // Dictionary<int, IAnimal> _animals = new Dictionary<int, IAnimal>();
    private readonly List<IAnimal> _animals = new ();
    // private int counter;

    public IEnumerable<IAnimal> GetAll() => _animals;
    
    public void Add(IAnimal animal) => _animals.Add(animal);
    
    public IAnimal? GetById(Guid id) => _animals.FirstOrDefault(a => a.Id == id);

    public bool Delete(Guid id)
    {
        var animal = GetById(id);
        // if (animal is null) throw new KeyNotFoundException("Animal not found");
        
        return animal != null && _animals.Remove(animal);
    }
}