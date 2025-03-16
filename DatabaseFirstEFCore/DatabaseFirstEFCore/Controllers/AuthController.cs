using Asp.Versioning;
using DatabaseFirstEFCore.Model;
using DatabaseFirstEFCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirstEFCore.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO userDetails)
        {
            try
            {
                return Ok(await _authService.LogIn(userDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
