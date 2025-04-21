namespace Zoo.App.Animals;
using Domain.Animals;
using Domain.Models;

public interface IAnimalService
{
    public void Create(string nickName, Species species, DateOnly birthday, Food favoriteFood);
    public bool Delete(Guid id);
    public IAnimal? GetById(Guid id);
    public IEnumerable<IAnimal> GetAll();
    public bool TransferAnimal(Guid animalId, Guid enclosureId);
}