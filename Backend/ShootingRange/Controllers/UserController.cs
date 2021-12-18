using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ShootingRange.Controllers
{
    [Route("Api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUser command)
        {
            await _userService.RegisterUser(command);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginUser command)
        {
            string token = _userService.GenerateJwt(command);
            return Ok(token);
        }
        [HttpPatch("role/{userId}")]
        public async Task<ActionResult> ChangeRole(Guid userId, [FromBody] ChangeRole command)
        {
            command.UserId = userId;
            await _userService.ChangeRole(command);
            return Ok();
        }
        [HttpDelete("{userId}")]
        public async Task<ActionResult> Deleteuser(Guid userId)
        {
            var command = new DeleteUser { UserId = userId };
            await _userService.DeleteUser(command);
            return Ok();
        }

    }
}
