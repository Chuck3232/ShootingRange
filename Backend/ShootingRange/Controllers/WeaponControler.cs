using Application.Dto;
using Application.Services.Interface;
using Application.Commands.Weapon;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ShootingRange.Controlers
{
    [EnableCors("MyPolicy")]
    [Route("Api/Weapon")]
    [ApiController]
    [Authorize]
    public class WeaponControler : ControllerBase
    {
        private readonly IWeaponServices _weaponServices;

        public WeaponControler(IWeaponServices weaponService)
        {
            _weaponServices = weaponService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeapon([FromBody] WeaponDto command)
        {
            await _weaponServices.AddWeapon(command);
            return Ok();
        }
  

        [HttpGet]
        public ActionResult<IEnumerable<WeaponDto>> GetAllWeapons()
        {
            return Ok(_weaponServices.GetallWeapons());
        }
        [HttpPut("{weaponId}")]
        public async Task<ActionResult> EditWeapon([FromBody] EditWeapon command, Guid weaponId)
        {
            command.Id = weaponId;
            await _weaponServices.EditWeapon(command);
            return Ok();
        }
        [HttpGet("customer")]
        public ActionResult<List<WeaponDto>> GetAllWeaponsCustomer()
        {
            return Ok(_weaponServices.GetAllWeaponsToCustomer());
        }
        [HttpDelete("{weaponId}")]
        public async Task<ActionResult> DeleteWeapon(Guid weaponId)
        {
            var command = new GetWeaponById { WeaponId = weaponId };
            await _weaponServices.DeleteWeapon(command);
            return Ok();
        }
        [HttpPut("reset/{weaponId}")]
        public async Task<ActionResult> ResetNumberOfUse(Guid weaponId)
        {
            var command = new GetWeaponById { WeaponId = weaponId };
            await _weaponServices.ResetNumberOfUse(command);
            return Ok();
        }


    }
}