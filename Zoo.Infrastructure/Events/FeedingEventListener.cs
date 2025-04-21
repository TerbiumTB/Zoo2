namespace Zoo.Infrastructure.Events;

using Domain.Events;

public class FeedingEventLogger : IFeedingEventListener
{
    public void Listen(IFeedingEvent feedingEvent)
    {
        feedingEvent.Feeding += HandleFeedingEvent;
    }

    public void HandleFeedingEvent(object? sender, FeedingEventArgs e)
    {
        Console.WriteLine($"Animal {e.AnimalId} was fed with {e.Food.Name} at {e.FeedingTime}");
    }
}