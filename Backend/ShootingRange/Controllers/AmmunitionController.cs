using Application.Dto;
using Application.Commands.Ammunition;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace ShootingRange.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Api/Ammo")]
    [ApiController]
    [Authorize]
    public class AmmunitionController : ControllerBase
    {
        private readonly IAmmunitionServices _ammunitionServices;

        public AmmunitionController(IAmmunitionServices ammunitionServices)
        {
            _ammunitionServices = ammunitionServices;     
        }

        [HttpPost]
        public async Task<IActionResult> AddAmunition([FromBody] AddAmmo command)
        {
            await _ammunitionServices.AddAmmo(command);
            return Ok();
        }
        [HttpPut("{ammoId}")]
        public async Task<ActionResult<Ammunition>> EditAmmo([FromBody] AddAmmo command, Guid ammoId)
        {
            command.Id = ammoId;
            await _ammunitionServices.EditAmmo(command);
            return Ok();
        }
        [HttpGet]
        public ActionResult<List<AmmunitionDto>> GetAllAmmo()
        {
            return Ok(_ammunitionServices.GetallAmmo());
        }
        [HttpGet("customer")]
        public ActionResult<List<AmmunitionDto>> GetAmmoToCustomer()
        {
            return Ok(_ammunitionServices.GetAmmoToCustomer());
        }
        [HttpGet("{weaponId}")]
        public async Task<ActionResult<Ammunition>> GetAmmoToWeapon(Guid weaponId)
        {
            var command = new GetAmmoToWeapon { WeaponId = weaponId };          
            return Ok(await _ammunitionServices.GetAmmoToWeapon(command));
        }
    }
}
