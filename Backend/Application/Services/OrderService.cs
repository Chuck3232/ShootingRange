using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Services.Interface;
using Domain.Models;
using Infrascture.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderDto> GetAllOrders()
        {
            var orders = _dbContext.Orders.OrderBy(o => o.CreatedAt)
                                    .Include(o => o.Customer)
                                    .Include(o => o.Spot)
                                    .Include(o => o.Weapons)
                                    .ThenInclude(w=>w.Weapon)
                                    .Include(o => o.AmmoOrders)
                                    .ThenInclude(a => a.Ammunition)
                                    .Include(o => o.AmmoOrders)
                                    .ToList();
            var ordersDto = orders.Select(o => new OrderDto
            {
                OrderId = o.Id,
                CustomerId = o.Customer.Id,
                LastName = o.Customer.LastName,
                SpotDistance = o.Spot.Distance.ToString(),
                Weapons = o.Weapons.Select(w => new WeaponInOrder
                {
                    WeaponId = w.Id,
                    Name = w.Weapon.Name,
                    Type = w.Weapon.Type,
                    Caliber = w.Weapon.Caliber,
                    DateOfProduction = w.Weapon.DateOfProduction,
                    Price = w.Weapon.Price

                }),
                AmmoOrders = o.AmmoOrders.Select(a => new AmmoOrderDto
                {
                    AmmunitionId = a.Ammunition.Id,
                    Caliber = a.Ammunition.Caliber,
                    Type = a.Ammunition.Type,
                    Producer = a.Ammunition.Producer,
                    Quantity = a.Quantity,
                    Sum = a.Quantity * a.Ammunition.Price,
                    Price = a.Ammunition.Price.ToString()
                }),
                Status = o.Status,
                TrainigHours = o.TrainigHours,
                IsInstructor = o.IsInstructor,
                Price = o.Price,
                Date = o.CreatedAt
            }); 

            return ordersDto.ToList();
        }
    }
}
