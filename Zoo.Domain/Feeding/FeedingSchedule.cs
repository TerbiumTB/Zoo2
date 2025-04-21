using System.Net.Sockets;

namespace Zoo.Domain.Feeding;

using Models;

public class FeedingSchedule : IFeedingSchedule
{
    Dictionary<Guid, FeedingPlan> _feedingPlans = new();

    public void SetFeedingPlan(FeedingPlan plan) => _feedingPlans[plan.AnimalId] = plan;
    
    public FeedingPlan? GetFeedingPlan(Guid animalId) => _feedingPlans.ContainsKey(animalId) ? _feedingPlans[animalId] : null;
    public void UpdateFeedingInterval(Guid animalId, TimeSpan interval) =>
        _feedingPlans[animalId] = _feedingPlans[animalId] with { Interval = interval };
    
    public void UpdateFeedingFoodType(Guid animalId, Food foodType) =>
        _feedingPlans[animalId] = _feedingPlans[animalId] with { FoodType = foodType };
    
    public void UpdateFeedingLastFed(Guid animalId, DateTime lastFed) =>
        _feedingPlans[animalId] = _feedingPlans[animalId] with { LastFed = lastFed };
    
    public bool DeleteFeedingPlan(Guid animalId) => _feedingPlans.Remove(animalId);
}