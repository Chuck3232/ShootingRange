using Application.Commands.ShootingSpot;
using Application.Dto;
using Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShootingRange.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Api/ShootingSpot")]
    [ApiController]
    [Authorize]
    public class ShootingSpotController :  ControllerBase
    {
        private readonly IShootingSpotServices _shootingSpotServices;

        public ShootingSpotController(IShootingSpotServices shootingSpotServices)
        {
            _shootingSpotServices = shootingSpotServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddShootingSpot([FromBody] AddShootingSpot command)
        {
            await _shootingSpotServices.AddShootingSpot(command);
            return Ok();
        }
        [HttpPost("{spotId}/customer/{customerId}")]
        public async Task<IActionResult> AddCustomerAndCreateOrder(Guid spotId, Guid customerId)
        {
            var command = new AddCustomer {spotId = spotId, customerId = customerId };
            await _shootingSpotServices.AddCustomerAndCreateOrder(command);
            return Ok();
        }
        [HttpPut("{spotId}")]
        public async Task<IActionResult> EndOrder(Guid spotId)
        {
            var command = new EndOrder { ShootingSpotId = spotId};
            await _shootingSpotServices.EndOrder(command);
            return Ok();
        }
        [HttpGet]
        public ActionResult<List<ShootingSpotDto>> GetAllSpots()
        {
            return Ok(_shootingSpotServices.GetAllSpots());
        }
    }
}
