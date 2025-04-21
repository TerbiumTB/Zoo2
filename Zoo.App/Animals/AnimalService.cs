using Zoo.App.Feeding;
using Zoo.Domain.Enclosures;

namespace Zoo.App.Animals;

using Domain.Animals;
using Domain.Models;
using Infrastructure.Animals;
using Infrastructure.Enclosures;
using Domain.Events;

public class AnimalService : IAnimalService
{
    private readonly IAnimalFactory _animalFactory;
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;
    private readonly IFeedingOrganizationService _feedingOrganization;
    private readonly ITransferEvent _transferEvent;

    public AnimalService(IAnimalFactory animalFactory,
        IAnimalRepository animalRepository,
        IEnclosureRepository enclosureRepository,
        IFeedingOrganizationService feedingOrganization,
        ITransferEvent transferEvent)
    {
        _animalFactory = animalFactory;
        _animalRepository = animalRepository;
        _enclosureRepository = enclosureRepository;
        _feedingOrganization = feedingOrganization;
        _transferEvent = transferEvent;
    }

    public IAnimal? GetById(Guid id) => _animalRepository.GetById(id);

    public IEnumerable<IAnimal> GetAll() => _animalRepository.GetAll();

    public void Create(string nickName, Species species, DateOnly birthday, Food favoriteFood)
    {
        var animal = _animalFactory.Create(nickName, species, birthday, favoriteFood);

        _animalRepository.Add(animal);
    }

    public bool Delete(Guid id)
    {
        var animal = GetById(id);
        if (animal is null) return false;
        
        
        var enclosure = _enclosureRepository.GetById(animal.EnclosureId);
        enclosure?.DeleteAnimal(animal.Id);

        _feedingOrganization.DeleteFeedingPlan(animal.Id);
        
        return _animalRepository.Delete(id);
        // _animalRepository.(id);
    }
    
    public bool TransferAnimal(Guid animalId, Guid enclosureId)
    {
        var animal = _animalRepository.GetById(animalId);
        if (animal == null) return false;
        
        var oldEnclosure = _enclosureRepository.GetById(animal.EnclosureId);
        var newEnclosure = _enclosureRepository.GetById(enclosureId);

        if (newEnclosure == null) return false;
        // if (newEnclosure == null || oldEnclosure == null) return false;

        if (animal.Species.Type != newEnclosure.Type || newEnclosure.IsFull()) return false;

        newEnclosure.AddAnimal(animal.Id);
        oldEnclosure?.DeleteAnimal(animal.Id);
        animal.Move(enclosureId);
        _transferEvent.OnTransfer(animalId, newEnclosure.Id, oldEnclosure?.Id ?? Guid.Empty);

        return true;
    }
}