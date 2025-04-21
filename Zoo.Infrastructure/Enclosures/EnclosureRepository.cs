namespace Zoo.Infrastructure.Enclosures;
using Domain.Enclosures;

public class EnclosureRepository: IEnclosureRepository
{
    private readonly List<IEnclosure> _enclosures = new ();


    public IEnumerable<IEnclosure> GetAll() => _enclosures;
    
    public void Add(IEnclosure enclosure) => _enclosures.Add(enclosure);
    
    public IEnclosure? GetById(Guid id) => _enclosures.FirstOrDefault(a => a.Id == id);
    
    public bool Delete(Guid id)
    {
        var enclosure = GetById(id);
        
        return enclosure != null && _enclosures.Remove(enclosure);
    }
}