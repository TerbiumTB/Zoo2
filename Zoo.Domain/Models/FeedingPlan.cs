namespace Zoo.Domain.Models;

using Models;

public record FeedingPlan(Guid AnimalId, TimeSpan Interval, Food FoodType)
{
    public DateTime LastFed { get; init; } = DateTime.MinValue;
}