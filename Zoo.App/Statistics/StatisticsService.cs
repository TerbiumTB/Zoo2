namespace Zoo.App.Statistics;

using Infrastructure.Enclosures;
using Infrastructure.Animals;


public class StatisticsService : IStatisticsService
{
    private readonly IEnclosureRepository _enclosureRepository;
    private readonly IAnimalRepository _animalRepository;
    
    public StatisticsService(IEnclosureRepository enclosureRepository, IAnimalRepository animalRepository)
    {
        _enclosureRepository = enclosureRepository;
        _animalRepository = animalRepository;
    }
    
    public int GetTotalAnimalCount() => _animalRepository.GetAll().Count();
    
    public int GetTotalEnclosureCount() => _enclosureRepository.GetAll().Count();

    public int GetTotalHungryAnimalCount() => _animalRepository.GetAll().Count(a => a.IsHungry);
}