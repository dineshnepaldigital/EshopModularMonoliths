namespace Catalog.Products.Features.GetProductById;

public record GetProductByIdQuery(Guid ProductId)
    : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(ProductDto Product);

internal class GetProductByIdHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        //1. get product from database based on id
        //2. return resuult

        var product = await dbContext.Products
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == query.ProductId, cancellationToken);

        if (product is null)
        {
            throw new Exception($"Product with id {query.ProductId} not found.");
        }

        //mapping product to product dto using mapster
        var productDto = product.Adapt<ProductDto>();

        return new GetProductByIdResult(productDto);
    }
}
