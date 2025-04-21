namespace Zoo.App.Enclosures;

using Domain.Models;
using Domain.Enclosures;


public class EnclosureFactory: IEnclosureFactory
{
    public IEnclosure Create(AnimalType type, int capacity)
    {
        return new Enclosure(Guid.NewGuid(), type, capacity);
    }
}