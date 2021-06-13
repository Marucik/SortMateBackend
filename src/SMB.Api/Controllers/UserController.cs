using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain.UserCredentials;

namespace SMB.Api.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class UserController : Controller
  {
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
