using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Dto;
using Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ShootingRange.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Api/User")]
    [ApiController]
    [Authorize]
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
            Response.Cookies.Append("jwt", token);
            return Ok(token);
        }
        [HttpPost("logout")]
        public ActionResult Logout()
        { 
            Response.Cookies.Delete("jwt");
            return Ok();
        }
        [HttpPatch("role/{userId}")]
        public async Task<ActionResult> ChangeRole(Guid userId, [FromBody] ChangeRole command)
        {
            command.UserId = userId;
            await _userService.ChangeRole(command);
            return Ok();
        }
        [HttpGet("instructors")]
        public  ActionResult<List<UserDto>> GetAllInstructors()
        {
            return Ok( _userService.GetAllInstructors());
        }
        [HttpGet]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(Guid userId, [FromBody] EditUser command)
        {
            command.UserId = userId;
            await _userService.EditUser(command);
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
