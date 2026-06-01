namespace Catalog.Products.Features.GetProductByCategory;

public record GetProductByCategoryQuery(string Category)
    : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<ProductDto> Products);

internal class GetProductByCategoryHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        //1. get products from database based on category
        //2. return result

        var products = await dbContext.Products
            .AsNoTracking()
            .Where(p=> p.Category.Contains(query.Category))
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        //mapping products to productDtos using mapster
        var productDtos = products.Adapt<List<ProductDto>>();

        return new GetProductByCategoryResult(productDtos);
    }
}
