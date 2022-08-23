using Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Ammunition;
using Application.Commands.Assignment;
using Microsoft.AspNetCore.Authorization;
using Application.Dto;
using ShootingRange.Extensions;
using Microsoft.AspNetCore.Cors;

namespace ShootingRange.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Api/Assignment")]
    [ApiController]
    [Authorize]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentServices _assignmentServices;

        public AssignmentController(IAssignmentServices assignmentServices)
        {
            _assignmentServices = assignmentServices;
        }

        [HttpPost("weapon/{weaponId}/{customerId}")]
        public async Task<IActionResult> AddAssignmentWeapon(Guid weaponId, Guid customerId)
        {
            var command = new AddAssigmentWeapon
            {
                WeaponId=weaponId,
                CustomerId = customerId
            };
            await _assignmentServices.AddAssignmentWeapon(command);
            return Ok();
        }
        [HttpPost("ammo/{ammoId}/{customerId}")]
        public async Task<IActionResult> AddAssignmentAmmunition(Guid ammoId, Guid customerId, [FromBody] AddAssignmentAmmo command)
        {
            command.CustomerId = customerId;
            command.AmmoId = ammoId;
            await _assignmentServices.AddAssignmentAmmunition(command);
            return Ok();
        }
        [HttpPost("instructor/{instructorId}/{customerId}")]
        public async Task<IActionResult> AddAssignmentInstructor(Guid instructorId, Guid customerId)
        {

            var command = new AddAssignmentInstructor
            {
                InstructorId = instructorId,
                CustomerId = customerId
            };
            await _assignmentServices.AddAssignmentInstructor(command);
            return Ok();
        }
        [HttpPut("accept/{assignmentId}")]
        public async Task<IActionResult> AcceptAsignment(Guid assignmentId)
        {
            var command = new GetAssignmentById { AssignmentId = assignmentId };
            await _assignmentServices.AcceptationAssignment(command);
            return Ok();
        }
        [HttpPut("reject/{assignmentId}")]
        public async Task<IActionResult> RejectAsignment(Guid assignmentId)
        {
            var command = new GetAssignmentById { AssignmentId = assignmentId };
            await _assignmentServices.DeclineAssignment(command);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public ActionResult<List<AssignmentDto>> GetMynAssignments()
        {
            var command = new GetMyAssignments { UserId = User.GetUserId() };
            return Ok(_assignmentServices.GetMyAssignments(command));
        }

    }
}
