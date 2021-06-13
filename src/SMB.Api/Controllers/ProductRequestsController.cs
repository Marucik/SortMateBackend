using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain.ProductRequest;
using SMB.Infrastructure.Dto;
using SMB.Infrastructure.Repositories;

namespace SMB.Api.Controllers
{
  [Route("api/product-requests")]
  [ApiController]
  public class ProductRequestsController : Controller
  {
    private IProductRequestRepository _productRequestRepository;

    public ProductRequestsController(IProductRequestRepository productRequestRepository)
    {
      _productRequestRepository = productRequestRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductRequest>> GetProductRequests()
    {
      return await _productRequestRepository.GetAllAsync();
    }

    [HttpPost]
    public async Task InsertProductRequest(NewProductRequestDto entity)
    {
      var productRequest = new ProductRequest(entity.Name, entity.Code, entity.Description, entity.SegregationType);
      await _productRequestRepository.InsertAsync(productRequest);
    }
  }
}