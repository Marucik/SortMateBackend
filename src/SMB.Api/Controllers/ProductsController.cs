using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain;
using SMB.Infrastructure.Dto;
using SMB.Infrastructure.Repositories;
using System.Linq;

namespace SMB.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : Controller
	{
		private readonly IProductRepository _productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<ProductDto>> GetProducts()
		{
			var products = await _productRepository.GetAllAsync();
			var productsDto = products.Select(x => ProductDto.FromProduct(x));

			return productsDto;
		}

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

		[HttpPost]
		public async Task InsertProduct(NewProductDto entity)
		{
			var product = new Product(entity.Name, entity.Code, entity.Description, entity.SegregationTypes);
			await _productRepository.InsertAsync(product);
		}
	}
}