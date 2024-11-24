using Microsoft.AspNetCore.Mvc;
using MyCleanApi.Application;

namespace MyCleanApi.WebApi.Controllers;

public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("/products")]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }
}