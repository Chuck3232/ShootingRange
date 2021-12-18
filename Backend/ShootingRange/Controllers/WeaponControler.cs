using Application.Dto;
using Application.Services;
using Application.Services.Interface;
using Application.Commands.Weapon;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace ShootingRange.Controlers
{
    [Route("Api/Weapon")]
    public class WeaponControler : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponControler(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeapon([FromBody] AddWeapon command)
        {
            await _weaponService.AddWeapon(command);
            return Ok();
        }
        [HttpGet]
        public ActionResult<List<WeaponDto>> GetAllWeapons()
        {
            return Ok(_weaponService.GetallWeapons());
        }
        [HttpDelete("{weaponId}")]
        public async Task<ActionResult> DeleteWeapon(Guid weaponId)
        {
            var command = new GetWeaponById { WeaponId = weaponId };
            await _weaponService.DeleteWeapon(command);
            return Ok();
        }

        [HttpPut("{weaponId}")]
        public async Task<ActionResult> ResetNumberOfUse(Guid weaponId)
        {
            var command = new GetWeaponById { WeaponId = weaponId };
            await _weaponService.ResetNumberOfUse(command);
            return Ok();
        }


    }
}