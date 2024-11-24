namespace MyCleanApi.Core;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task UpdateProductsPricesAsync(IEnumerable<Product> products);
    Task DeleteProductAsync(int id);
}