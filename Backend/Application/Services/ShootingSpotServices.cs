using Application.Commands.ShootingSpot;
using Application.Commands.Weapon;
using Application.Dto;
using Application.Services.Interface;
using Domain;
using Domain.Common;
using Domain.Models;
using Infrascture.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services
{
    public class ShootingSpotServices : IShootingSpotServices
    {
        private readonly ApplicationDbContext _dbContext;

        public ShootingSpotServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddShootingSpot(AddShootingSpot command)
        {
            var shootingSpot = new ShootingSpot(command.Distance);
            await _dbContext.AddAsync(shootingSpot);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddCustomerAndCreateOrder(AddCustomer command)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == command.customerId);
            if(customer == null)
                throw new KeyNotFoundException("Customer doesn't exist");


            var shootingSpot = await _dbContext.ShootingSpots.FirstOrDefaultAsync(s => s.Id == command.spotId);
            if(shootingSpot == null)
                throw new KeyNotFoundException("Spot doesn't exist");
            if(shootingSpot.Customer != null)
                throw new AppException("Spot is ocupated");

            var order = new Order(customer, shootingSpot);
            if (customer.FirearmsLicense == null)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Status == "active");
                if (user != null)
                    throw new KeyNotFoundException("Instructor doesn't exist");
                shootingSpot.Instructor = user;
            }
            
            shootingSpot.Customer = customer;
            shootingSpot.DateEntry = DateTime.Now;
            
            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EndOrder(EndOrder command)
        {

            var shootingSpot = await _dbContext.ShootingSpots.Where(s => s.Id == command.ShootingSpotId)
                                    .Include(s => s.AmmoOrder)
                                    .Include(s => s.Weapon)
                                    .Include(s => s.Customer)
                                    .Include(s => s.Instructor)
                                    .FirstOrDefaultAsync();
            if (shootingSpot == null)
                throw new KeyNotFoundException("ShootingSpot doesn't exist");
            shootingSpot.DateExit = DateTime.Now;
            var order = await _dbContext.Orders.Where(o => o.Spot.Id == command.ShootingSpotId && o.Status=="open")
                                       .Include(o =>o.Weapons)
                                       .ThenInclude(w => w.Weapon)
                                       .Include(o => o.AmmoOrders)
                                       .ThenInclude(a => a.Ammunition)
                                       .FirstOrDefaultAsync();
            var entryRecord = await _dbContext.EntryRecords.OrderByDescending(e => e.DateEntry)
                                                           .FirstOrDefaultAsync(e => e.Customer.Id == shootingSpot.Customer.Id);
            if (entryRecord == null)
                throw new KeyNotFoundException("EntryRecord doesn't exist");
            if (order == null)
                throw new KeyNotFoundException("Order doesn't exist");
            int time = (shootingSpot.DateExit - shootingSpot.DateEntry).Hours+1;         
            float price = 0;
            foreach (AmmoOrder a in order.AmmoOrders)
                price += a.Ammunition.Price*a.Quantity;
            foreach (WeaponOrder w in order.Weapons)
                price += w.Weapon.Price;
            if(price==0)
                price += time*100;
            if (order.IsInstructor == true)
                price += 200;

            if (shootingSpot.Instructor != null)
                shootingSpot.Instructor.Active();
            order.Close(price, time);
            entryRecord.SetDateExit();
            shootingSpot.Reset();
                      
            await _dbContext.SaveChangesAsync();
        }
        public IQueryable<ShootingSpot> GetAllSpots()
        {

            return _dbContext.ShootingSpots.Include(s => s.Customer)
                                           .Include(s => s.Weapon)
                                           .Include(s => s.AmmoOrder)
                                           .ThenInclude(a => a.Ammunition)
                                           .Include(s => s.Instructor);
;
        }
    }
}