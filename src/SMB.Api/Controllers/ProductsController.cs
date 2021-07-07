using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain;
using SMB.Infrastructure.Dto;
using SMB.Infrastructure.Repositories;
using System.Linq;

namespace SMB.Api.Controllers
{
  /// <summary>
  /// Kontroler zapytań związanych z produktami.
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : Controller
  {
    private readonly IProductRepository _productRepository;
    /// <summary>
    /// Konstruktor wstzrykujący zależność.
    /// </summary>
    /// <param name="productRepository"></param>
    public ProductsController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    /// <summary>
    /// Metoda zwracająca wszystkie produkty.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
      var products = await _productRepository.GetAllAsync();
      var productsDto = products.Select(x => ProductDto.FromProduct(x));

      return productsDto;
    }
    /// <summary>
    /// Metoda zwracająca produkt na podstawie przekazanego kodu.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{code}")]
    public async Task<ActionResult<ProductDto>> GetProductByCode(string code)
    {
      try
      {
        var product = await _productRepository.GetByCodeAsync(code);
        var productDto = ProductDto.FromProduct(product);

        return productDto;
      }
      catch (System.Exception)
      {
        return NotFound();
      }
    }
    /// <summary>
    /// Metoda dodająca przesłany produkt do bazy.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task InsertProduct(NewProductDto entity)
    {
      var product = new Product(entity.Name, entity.Code, entity.Description, entity.SegregationType);
      await _productRepository.InsertAsync(product);
    }
  }
}