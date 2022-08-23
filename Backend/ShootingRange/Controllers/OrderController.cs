using Application.Dto;
using Application.Services.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRange.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("Api/Order")]
    [ApiController]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderServices;

        public OrderController(IOrderService orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAllWeapons()
        {
            return Ok(_orderServices.GetAllOrders());
        }
    }
}
