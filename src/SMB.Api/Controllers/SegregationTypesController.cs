using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain;
using SMB.Infrastructure.Dto;
using SMB.Infrastructure.Repositories;

namespace SMB.Api.Controllers
{
  /// <summary>
  /// Kontroler zapytań związanych z typami segregacji.
  /// </summary>
  [Route("api/segregation-types")]
  [ApiController]
  public class SegregationTypesController : Controller
  {
    private readonly ISegregationTypeRepository _segregationTypeRepositoty;
    /// <summary>
    /// Konstruktor wstrzykujący zależność.
    /// </summary>
    /// <param name="segregationTypeRepositoty"></param>
    public SegregationTypesController(ISegregationTypeRepository segregationTypeRepositoty)
    {
      _segregationTypeRepositoty = segregationTypeRepositoty;
    }
    /// <summary>
    /// Metoda zwaracjąca wszystkie typy segragacji.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<SegregationTypeDto>> GetSegregations()
    {
      var segregationTypes = await _segregationTypeRepositoty.GetAllAsync();
      var productsDto = segregationTypes.Select(x => SegregationTypeDto.FromSegregationType(x));

      return productsDto;
    }
    /// <summary>
    /// Metoda dodająca nowy typ segregacji.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task InsertSegregation(NewSegregationTypeDto entity)
    {
      var segregationType = new SegregationType(entity.Name);
      await _segregationTypeRepositoty.InsertAsync(segregationType);
    }
  }
}