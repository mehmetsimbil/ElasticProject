using Business.Abstract;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Security.JWT;
using Business.Requests.User;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public void Register([FromBody] Business.Requests.User.RegisterRequest request)
        {
            _userService.Register(request);
        }

        [HttpPost("Login")]
        public AccessToken Login([FromBody] Business.Requests.User.LoginRequest request)
        {
            return _userService.Login(request);
        }
    }
}
