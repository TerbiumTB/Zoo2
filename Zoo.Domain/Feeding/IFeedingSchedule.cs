namespace Zoo.Domain.Feeding;

using Models;

public interface IFeedingSchedule
{
    void SetFeedingPlan(FeedingPlan plan);

    FeedingPlan? GetFeedingPlan(Guid animalId);
    
    bool DeleteFeedingPlan(Guid animalId);

    void UpdateFeedingInterval(Guid animalId, TimeSpan interval);

    void UpdateFeedingFoodType(Guid animalId, Food foodType);

    void UpdateFeedingLastFed(Guid animalId, DateTime lastFed);
}