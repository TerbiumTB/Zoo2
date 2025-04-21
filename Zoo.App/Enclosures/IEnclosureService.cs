namespace Zoo.App.Enclosures;
using Domain.Models;
using Domain.Enclosures;
public interface IEnclosureService
{
    public void Create(AnimalType type, int capacity);
    public bool Delete(Guid id);
    public IEnclosure? GetById(Guid id);
    public IEnumerable<IEnclosure> GetAll();
}