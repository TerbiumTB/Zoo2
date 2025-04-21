namespace Zoo.Domain.Events;
using Models;


public class FeedingEventArgs : EventArgs
{
    public required Guid AnimalId { get; init; }
    public required Food Food { get; init; }
    public required DateTime FeedingTime { get; init; }
}

public class FeedingEvent : IFeedingEvent
{
    public event EventHandler<FeedingEventArgs>? Feeding;
    
    public void OnFeeding(Guid animalId, Food food, DateTime feedingTime)
    {
        Feeding?.Invoke(this, new FeedingEventArgs
        {
            AnimalId = animalId,
            Food = food,
            FeedingTime = feedingTime
        });
    }
}