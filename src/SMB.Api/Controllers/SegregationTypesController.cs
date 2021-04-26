using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain;
using SMB.Infrastructure.Dto;
using SMB.Infrastructure.Repositories;

namespace SMB.Api.Controllers
{
	[Route("api/segregation-types")]
	[ApiController]
	public class SegregationTypesController : Controller
	{
		private readonly ISegregationTypeRepository _segregationTypeRepositoty;

		public SegregationTypesController(ISegregationTypeRepository segregationTypeRepositoty)
		{
			_segregationTypeRepositoty = segregationTypeRepositoty;
		}

		[HttpGet]
		public async Task<IEnumerable<SegregationTypeDto>> GetProducts()
		{
			var segregationTypes = await _segregationTypeRepositoty.GetAllAsync();
			var productsDto = segregationTypes.Select(x => SegregationTypeDto.FromSegregationType(x));

			return productsDto;
		}

		[HttpPost]
		public async Task InsertProduct(SegregationTypeDto entity)
		{
			var segregationType = new SegregationType(entity.Name);
			await _segregationTypeRepositoty.InsertAsync(segregationType);
		}
	}
}