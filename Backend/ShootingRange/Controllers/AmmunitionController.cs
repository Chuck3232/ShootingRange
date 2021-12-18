using Application.Dto;
using Application.Commands.Ammunition;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Models;

namespace ShootingRange.Controllers
{
    [Route("Api/Ammo")]
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

        [HttpGet]
        public ActionResult<List<AmmunitionDto>> GetAllAmmo()
        {
            return Ok(_ammunitionServices.GetallAmmo());
        }
        [HttpGet("{weaponId}")]
        public  ActionResult<Ammunition> GetAmmoToWeapon(Guid weaponId)
        {
            var command = new GetAmmoToWeapon { WeaponId = weaponId };          
            return Ok(_ammunitionServices.GetAmmoToWeapon(command));
        }
    }
}
