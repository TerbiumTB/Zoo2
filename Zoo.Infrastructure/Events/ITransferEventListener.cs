namespace Zoo.Infrastructure.Events;
using Domain.Events;

public interface ITransferEventListener
{
    public void Listen(ITransferEvent transferEvent);
    public void HandleTransferEvent(object? sender, TransferEventArgs e);
}