using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain;
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
    private IProductRepository _productRepository;

    public ProductRequestsController(IProductRequestRepository productRequestRepository, IProductRepository productRepository)
    {
      _productRequestRepository = productRequestRepository;
      _productRepository = productRepository;
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

    [HttpPost]
    [Route("{id}:accept")]
    public async Task AcceptProductRequest(Guid id)
    {
      var acceptedProduct = await _productRequestRepository.FindAndDeleteByIdAsync(id);
      await _productRepository.InsertAsync(new Product(acceptedProduct));
    }
  }
}