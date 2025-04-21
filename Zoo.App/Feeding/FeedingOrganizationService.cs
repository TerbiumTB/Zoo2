using Zoo.Domain.Events;

namespace Zoo.App.Feeding;

using Domain.Feeding;
using Domain.Models;
using Domain.Animals;
using Infrastructure.Animals;

public class FeedingOrganizationService : IFeedingOrganizationService
{
    private readonly IFeedingSchedule _feedingSchedule;
    private readonly IAnimalRepository _animalRepository;
    // private readonly IFeedingEventListener _feedingEventListener;

    private readonly IFeedingEvent _feedingEvent;
    // private readonly 

    public FeedingOrganizationService(IFeedingSchedule feedingSchedule, 
        IAnimalRepository animalRepository,
        IFeedingEvent feedingEvent)
    {
        _feedingSchedule = feedingSchedule;
        _animalRepository = animalRepository;
        _feedingEvent = feedingEvent;
        // _feedingEventListener.Listen(_feedingEvent);
    }

    public bool SetFeedingPlan(Guid animalId, TimeSpan interval, Food foodType)
    {
        if (_feedingSchedule.GetFeedingPlan(animalId) != null) return false;

        _feedingSchedule.SetFeedingPlan(new FeedingPlan(animalId, interval, foodType));
        return true;
    }

    public bool UpdateFeedingInterval(Guid animalId, TimeSpan interval)
    {
        if (_feedingSchedule.GetFeedingPlan(animalId) == null) return false;

        _feedingSchedule.UpdateFeedingInterval(animalId, interval);
        return true;
    }

    public bool UpdateFeedingFoodType(Guid animalId, Food foodType)
    {
        if (_feedingSchedule.GetFeedingPlan(animalId) == null) return false;

        _feedingSchedule.UpdateFeedingFoodType(animalId, foodType);
        return true;
    }

    public bool DeleteFeedingPlan(Guid animalId) => _feedingSchedule.DeleteFeedingPlan(animalId);

    public bool Feed(Guid animalId)
    {
        var plan = _feedingSchedule.GetFeedingPlan(animalId);
        if (plan == null) return false;

        if (DateTime.Now - plan.LastFed < plan.Interval) return false;

        var animal = _animalRepository.GetById(animalId);

        //should be redundant
        if (animal == null) return false;

        if (animal.Species.Type != plan.FoodType.Type && animal.FavouriteFood.Type != plan.FoodType.Type) return false;

        var feedingTime = DateTime.Now;
        animal.Feed(plan.FoodType, feedingTime);

        _feedingSchedule.UpdateFeedingLastFed(animalId, feedingTime);
        _feedingEvent.OnFeeding(animal.Id, plan.FoodType, feedingTime);
        return true;
    }

    public IEnumerable<IAnimal> GetAllHungry() => _animalRepository.GetAll().Where(animal => animal.IsHungry);

    public void FeedAll()
    {
        foreach (var animal in _animalRepository.GetAll())
        {
            Feed(animal.Id);
        }
    }
}