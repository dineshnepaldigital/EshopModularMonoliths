namespace Catalog.Products.Features.GetProducts;

public record GetProductsQuery()
    : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<ProductDto> Products);

internal class GetProductsHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        //1. get products from database
        //2. return result

        var products = await dbContext.Products
                        .AsNoTracking()
                        .OrderBy(p => p.Name)
                        .ToListAsync();

        //mapping product entities to product dtos using Mapster
        var productDtos =products.Adapt<List<ProductDto>>();

        return new GetProductsResult(productDtos);
    }
}
