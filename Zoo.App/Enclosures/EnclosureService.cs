namespace Zoo.App.Enclosures;

using Domain.Models;
using Domain.Enclosures;
using Infrastructure.Enclosures;
using Infrastructure.Animals;

public class EnclosureService : IEnclosureService
{
    private readonly IEnclosureFactory _enclosureFactory;
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;

    public EnclosureService(IEnclosureFactory enclosureFactory,
        IAnimalRepository animalRepository,
        IEnclosureRepository enclosureRepository)
    {
        _enclosureFactory = enclosureFactory;
        _animalRepository = animalRepository;
        _enclosureRepository = enclosureRepository;
    }

    public IEnclosure? GetById(Guid id) => _enclosureRepository.GetById(id);

    public IEnumerable<IEnclosure> GetAll() => _enclosureRepository.GetAll();

    public void Create(AnimalType type, int capacity)
    {
        var enclosure = _enclosureFactory.Create(type, capacity);

        _enclosureRepository.Add(enclosure);
    }

    public bool Delete(Guid id)
    {

        var enclosure = _enclosureRepository.GetById(id);
        if (enclosure is null) return false;
        
        foreach (var animalId in enclosure.GetAllAnimalIds())
        {
            var animal = _animalRepository.GetById(animalId)!;
            animal.Move(Guid.Empty);
        }
        
        return _enclosureRepository.Delete(id);
    }
}