namespace Catalog.Products.EventHandlers;

public class ProductPriceChangedEventHandler(ILogger<ProductPriceChangedEventHandler> logger)
    : INotificationHandler<ProductPriceChangedEvent>
{
    public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
    {
        //TODO: publish product price changed event to message broker for other modules to consume
        logger.LogInformation("Domain event handled: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
