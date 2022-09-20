using System.Threading.Tasks;
using AuthenticationService.API.Models.RequestModels;
using AuthenticationService.API.Models.ResponseModels;
using AuthenticationService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest authenticateRequest)
        {
            string token = await _userService.Authenticate(authenticateRequest.Username, authenticateRequest.Password);

            AuthenticateResponse response = new AuthenticateResponse();

            if (string.IsNullOrWhiteSpace(token))
            {
                return Unauthorized();
            }

            response.Success = true;
            response.Token = token;
            return response;

        }
    }
}
