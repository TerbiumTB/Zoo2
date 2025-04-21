namespace Zoo.Domain.Events;

public interface ITransferEvent
{
    public event EventHandler<TransferEventArgs>? Transfer;
    public void OnTransfer(Guid animalId, Guid fromEnclosureId, Guid toEnclosureId);
}