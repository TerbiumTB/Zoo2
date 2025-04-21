namespace Zoo.App.Feeding;

using Domain.Models;

public interface IFeedingOrganizationService
{
    public bool SetFeedingPlan(Guid animalId, TimeSpan interval, Food foodType);

    public bool UpdateFeedingInterval(Guid animalId, TimeSpan interval);

    public bool UpdateFeedingFoodType(Guid animalId, Food foodType);

    public bool Feed(Guid animalId);

    public bool DeleteFeedingPlan(Guid animalId);

    void FeedAll();
}