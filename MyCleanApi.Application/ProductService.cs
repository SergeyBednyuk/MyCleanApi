using MyCleanApi.Core;

namespace MyCleanApi.Application;

public sealed class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await _productRepository.GetProductByIdAsync(productId);
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepository.AddProductAsync(product);
    }

    public Task UpdateProductAsync(Product product)
    {
        return _productRepository.UpdateProductAsync(product);
    }

    public Task DeleteProductAsync(int productId)
    {
        return _productRepository.DeleteProductAsync(productId);
    }
}