using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain.UserCredentials;

namespace SMB.Api.Controllers
{
  /// <summary>
  /// Kontroler imitujący logowanie użytkownika.
  /// </summary>
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class UserController : Controller
  {
    /// <summary>
    /// Metoda sprawdzająca poświadczenia użytkownika.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Login(UserCredentials user)
    {
      if (user.Login == "admin" && user.Password == "Pa55w0rd")
      {
        return Ok();
      }
      else
      {
        return NotFound();
      }
    }
  }
}
