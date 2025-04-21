namespace Zoo.Infrastructure.Enclosures;
using Domain.Enclosures;

public interface IEnclosureRepository
{
    IEnumerable<IEnclosure> GetAll();
    void Add(IEnclosure enclosure);
    IEnclosure? GetById(Guid id);
    bool Delete(Guid id);
    
}