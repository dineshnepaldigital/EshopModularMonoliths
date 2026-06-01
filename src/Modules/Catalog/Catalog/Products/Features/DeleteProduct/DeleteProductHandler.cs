namespace Catalog.Products.Features.DeleteProduct;

public record DeleteProductCommand(Guid ProductId)
    : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

internal class DeleteProductHandler(CatalogDbContext dbContext)
     : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        //1. Delete Product entity
        //2. Save to db
        //return result

        var product = await dbContext.Products.FindAsync([command.ProductId], cancellationToken);

        if (product == null) 
        {
            throw new Exception($"Product with id {command.ProductId} not found.");
        }

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
