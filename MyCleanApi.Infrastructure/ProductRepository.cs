using Microsoft.EntityFrameworkCore;
using MyCleanApi.Core;
using MyCleanApi.Infrastructure.Data;

namespace MyCleanApi.Infrastructure;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _db.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddProductAsync(Product product)
    {
        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        var productToUpdate = await _db.Products.FindAsync(product.Id);
        if (productToUpdate != null)
            _db.Entry(productToUpdate).CurrentValues.SetValues(product);

        await _db.SaveChangesAsync();
    }

    public async Task UpdateProductsPricesAsync(IEnumerable<Product> products)
    {
        var productsIds = products.Select(x => x.Id).ToList();

        await _db.Products.Where(x => productsIds.Contains(x.Id)).ExecuteUpdateAsync(p =>
            p.SetProperty(
                p => p.Price, 
                p => products.Where(x => x.Id == p.Id).First().Price));
    }

    public async Task DeleteProductAsync(int id)
    {
        Product productToDelete = _db.Products.Find(id);
        if (productToDelete != null)
        {
            _db.Products.Remove(productToDelete);
            await _db.SaveChangesAsync();
        }
    }
}