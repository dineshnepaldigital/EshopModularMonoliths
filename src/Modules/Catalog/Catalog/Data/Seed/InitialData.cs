namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products => 
        new List<Product>
    {
        Product.Create(new Guid(),"Product 1", ["category 1"],"New product","https://example.com/product1.jpg", 500),
    };

}
