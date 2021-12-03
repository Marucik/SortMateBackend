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
    /// <summary>
    /// Kontroler zapytań związanych z rządaniem dodania produktu.
    /// </summary>
    [Route("api/product-requests")]
    [ApiController]
    public class ProductRequestsController : Controller
    {
        private IProductRequestRepository _productRequestRepository;
        private IProductRepository _productRepository;

        /// <summary>
        /// Konstruktor wstrzykujący zależności.
        /// </summary>
        /// <param name="productRequestRepository"></param>
        /// <param name="productRepository"></param>
        public ProductRequestsController(IProductRequestRepository productRequestRepository, IProductRepository productRepository)
        {
            _productRequestRepository = productRequestRepository;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Metoda zwracająca wszystkie rządania dodania produktu z bazy.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRequest>>> GetProductRequests()
        {
            try
            {
                var userId = (String)Request.HttpContext.Items["UserId"];
                if (userId == null) return Unauthorized();


                return Ok(await _productRequestRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Metoda dodająca nowe rządanie dodania produktu do bazy.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task InsertProductRequest(NewProductRequestDto entity)
        {
            var productRequest = new ProductRequest(entity.Name, entity.Code, entity.Description, entity.SegregationType);
            await _productRequestRepository.InsertAsync(productRequest);
        }

        /// <summary>
        /// Metoda akceptująca rządanie dodania produktu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}:accept")]
        public async Task AcceptProductRequest(Guid id)
        {
            var acceptedProduct = await _productRequestRepository.FindAndDeleteByIdAsync(id);
            await _productRepository.InsertAsync(new Product(acceptedProduct));
        }
    }
}