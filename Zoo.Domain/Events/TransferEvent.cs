using Zoo.Domain.Animals;

namespace Zoo.Domain.Events;

public class TransferEventArgs: EventArgs
{
    public required Guid AnimalId { get; init; }
    public required Guid FromEnclosureId { get; init; }
    public required Guid ToEnclosureId { get; init; }
}

public class TransferEvent : ITransferEvent
{
    public event EventHandler<TransferEventArgs>? Transfer;
    
    public void OnTransfer(Guid animalId, Guid fromEnclosureId, Guid toEnclosureId)
    {
        Transfer?.Invoke(this, new TransferEventArgs
        {
            AnimalId = animalId,
            FromEnclosureId = fromEnclosureId,
            ToEnclosureId = toEnclosureId
        });
    }
}