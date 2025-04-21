namespace Zoo.Infrastructure.Animals;
using Domain.Animals;

public interface IAnimalRepository
{
    IEnumerable<IAnimal> GetAll();
    IAnimal? GetById(Guid id);
    void Add(IAnimal animal);
    bool Delete(Guid id);
}