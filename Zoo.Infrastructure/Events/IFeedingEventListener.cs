namespace Zoo.Infrastructure.Events;
using Domain.Events;

public interface IFeedingEventListener
{
    public void Listen(IFeedingEvent feedingEvent);

    public void HandleFeedingEvent(object? sender, FeedingEventArgs e);
}