namespace Zoo.Infrastructure.Events;
using Domain.Events;

public class TransferEventListener : ITransferEventListener
{
    public void Listen(ITransferEvent transferEvent)
    {
        transferEvent.Transfer += HandleTransferEvent;
    }
    public void HandleTransferEvent(object? sender, TransferEventArgs e)
    {
        Console.WriteLine($"Animal {e.AnimalId} was transferred from {e.FromEnclosureId} to {e.ToEnclosureId}");
    }
}