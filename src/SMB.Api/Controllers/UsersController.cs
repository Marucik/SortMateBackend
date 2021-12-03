using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMB.Core.Domain.User;
using SMB.Infrastructure.Dto;
using SMB.Infrastructure.Repositories;
using SMB.Infrastructure.Services;

namespace SMB.Api.Controllers
{
    /// <summary>
    /// Kontroler imitujący logowanie użytkownika.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUserRepository _userRepository;

        public UsersController(IAuthenticateService authenticateService, IUserRepository userRepository)
        {
            _authenticateService = authenticateService;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Metoda sprawdzająca poświadczenia użytkownika.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserCredentialsDto credentials)
        {
            var response = await _authenticateService.Authenticate(credentials);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response.Token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCredentialsDto credentials)
        {

            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = credentials.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(credentials.Password)
            };

            await _userRepository.InsertAsync(user);

            return Ok();
        }

        [HttpGet("me")]
        public async Task<IActionResult> CheckToken()
        {
            try
            {
                var userId = (String)Request.HttpContext.Items["UserId"];
                if (userId == null) return Unauthorized();


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
