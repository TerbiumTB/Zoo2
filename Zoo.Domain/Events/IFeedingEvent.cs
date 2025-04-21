namespace Zoo.Domain.Events;
using Models;

public interface IFeedingEvent
{
    public event EventHandler<FeedingEventArgs>? Feeding;
    public void OnFeeding(Guid animalId, Food food, DateTime feedingTime);
}