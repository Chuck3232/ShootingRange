using Application.Commands.Assignment;
using Application.Dto;
using Application.Services.Interface;
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
    public class AssignmentServices : IAssignmentServices
    {
        private readonly ApplicationDbContext _dbContext;

        public AssignmentServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<AssignmentDto> GetMyAssignments(GetMyAssignments command)
        {
            var assignment = _dbContext.Assignments.OrderBy(o => o.CreatedAt)
                                          .Where(a => a.User.Id == command.UserId)
                                          .Include(a => a.User)
                                          .Include(a => a.WeaponOrder)
                                          .ThenInclude(w => w.Weapon)
                                          .Include(a => a.AmmoOrder)
                                          .ThenInclude(a => a.Ammunition)
                                          .Include(a => a.Order)
                                          .ThenInclude(o => o.Spot )
                                          .ThenInclude(s => s.Weapon)
                                          .Include(a => a.Order)
                                          .ThenInclude(o => o.Customer);
            var assignmentDto = assignment.Select(a => new AssignmentDto
            {
                Id = a.Id,
                UserId = a.User.Id,
                OrderId = a.Order.Id,
                CustomerId = a.Order.Customer.Id,
                CustomerName = new String(a.Order.Customer.LastName + " " + a.Order.Customer.FirstName),
                Status = a.Status,
                Type = a.Type,
                WeaponId = a.WeaponOrder.Weapon.Id,
                WeaponName = a.WeaponOrder.Weapon.Name,
                WeaponStatus = a.WeaponOrder.Weapon.InStock,
                AmmoId = a.AmmoOrder.Ammunition.Id,
                AmmoName = a.AmmoOrder.Ammunition.Caliber,
                AmmoQuant = a.AmmoOrder.Quantity,
                Instuctor = a.Instuctor,
                CustomerLicense = a.Order.Customer.FirearmsLicense,
                InstuctorInSpot = a.Instuctor,
                WeaponInSpotId = a.Order.Weapons.OrderBy(e => e.CreatedAt).Last().Weapon.Id,
                WeaponInSpot = new String(a.Order.Weapons.OrderBy(e => e.CreatedAt).Last().Weapon.Name + ": " + a.Order.Weapons.OrderBy(e => e.CreatedAt).Last().Weapon.Caliber),
                AmmoInSpotId = a.Order.AmmoOrders.OrderBy(e => e.CreatedAt).Last().Ammunition.Id,
                AmmoInSpot = new String(a.Order.AmmoOrders.OrderBy(e => e.CreatedAt).Last().Ammunition.Caliber + ": " + a.Order.AmmoOrders.OrderBy(e => e.CreatedAt).Last().Quantity)
            }); ; 
            return assignmentDto.ToList();
        }
        public async Task AddAssignmentWeapon(AddAssigmentWeapon command)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.RoleId == 3);
            if (user == null)
                throw new KeyNotFoundException("User ist't overseer");
            var order = await _dbContext.Orders.OrderByDescending(e => e.CreatedAt)
                                               .Include(o => o.Weapons)
                                               .Include(o => o.AmmoOrders)
                                               .FirstOrDefaultAsync(o => o.Customer.Id == command.CustomerId);
            if (order == null)
                throw new KeyNotFoundException("Order doesn't exist");
            var weapon = await _dbContext.Weapons.FirstOrDefaultAsync(w => w.Id == command.WeaponId);
            if (weapon == null)
                throw new KeyNotFoundException("Weapon doesn't exist");
            var weaponOrder = new WeaponOrder(weapon);
            await _dbContext.AddAsync(weaponOrder);
            var instructor = order.IsInstructor;

            var assignment = new Assignment();
            if (order.AmmoOrders.Count > 0 )
            {
                 var ammo = order.AmmoOrders.OrderBy(e => e.CreatedAt).Last();
                 assignment = new Assignment(user, order, weaponOrder, ammo, instructor, "weapon");
            }
            else
            {
                 assignment = new Assignment(user, order, weaponOrder, null, instructor, "weapon");
            }
                  
            await _dbContext.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddAssignmentAmmunition(AddAssignmentAmmo command)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.RoleId == 4);
            if (user == null)
                throw new KeyNotFoundException("User ist't armoreer");
            var order = await _dbContext.Orders.OrderByDescending(e => e.CreatedAt)
                                               .Include(o => o.Weapons)
                                               .Include(o => o.AmmoOrders)
                                               .FirstOrDefaultAsync(o => o.Customer.Id == command.CustomerId);
            if (order == null)
                throw new KeyNotFoundException("Order doesn't exist");
            var ammunition = await _dbContext.Ammunitions.FirstOrDefaultAsync(w => w.Id == command.AmmoId);
            if (ammunition == null)
                throw new KeyNotFoundException("Ammunition doesn't exist");
            var ammoOrder = new AmmoOrder(ammunition, command.AmmoQuant);
            await _dbContext.AddAsync(ammoOrder);
            await _dbContext.SaveChangesAsync();
            var instructor = order.IsInstructor;

            var assignment = new Assignment();
            if (order.Weapons.Count > 0 )
            {
                var weapon = order.Weapons.OrderBy(e => e.CreatedAt).Last();
                assignment = new Assignment(user, order, weapon, ammoOrder, instructor, "ammo");
            }
            else
            {
                assignment = new Assignment(user, order, null, ammoOrder, instructor, "ammo");
            }
             
            await _dbContext.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddAssignmentInstructor(AddAssignmentInstructor command)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == command.InstructorId );
            if (user == null)
                throw new KeyNotFoundException("User ist't instructor");
            if(user.Status != "active")
                throw new ApplicationException("User is busy");
            var order = await _dbContext.Orders.OrderByDescending(e => e.CreatedAt)
                                               .Include(o => o.Weapons)
                                               .Include(o => o.AmmoOrders)
                                               .FirstOrDefaultAsync(o => o.Customer.Id == command.CustomerId && o.Status == "open");
            if (order == null)
                throw new KeyNotFoundException("Order doesn't exist");

            var assignment = new Assignment();
            if (order.Weapons.Count > 0  && order.AmmoOrders.Count > 0)
            {
                var weapon = order.Weapons.OrderBy(e => e.CreatedAt).Last();
                var ammo = order.AmmoOrders.OrderBy(e => e.CreatedAt).Last();
                assignment = new Assignment(user, order, weapon, ammo, true, "instructor");
            }
            else if (order.AmmoOrders == null && order.Weapons.Count > 0)
            {
                var weapon = order.Weapons.OrderBy(e => e.CreatedAt).Last();
                assignment = new Assignment(user, order, weapon, null, true, "instructor");
            }
            else if (order.AmmoOrders.Count > 0 && order.Weapons == null)
            {
                var ammo = order.AmmoOrders.OrderBy(e => e.CreatedAt).Last();
                assignment = new Assignment(user, order, null, ammo, true, "instructor");
            }
            else 
            {
                assignment = new Assignment(user, order, null, null, true, "instructor");
            }

            await _dbContext.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AcceptationAssignment(GetAssignmentById command)
        {
            var assignment = await _dbContext.Assignments.Where(a => a.Id == command.AssignmentId)
                                        .Include(a => a.WeaponOrder)
                                        .Include(a => a.AmmoOrder)
                                        .FirstOrDefaultAsync();
            if (assignment == null)
                throw new KeyNotFoundException("Assignment doesn't exist");
            if (assignment.Status == "accepted")
                throw new ApplicationException("Assignment is alredy accepted");
            if (assignment.Type == "weapon")
            {
                assignment = await _dbContext.Assignments.Where(a => a.Id == command.AssignmentId)
                                           .Include(a => a.WeaponOrder)
                                           .ThenInclude(w => w.Weapon)
                                           .Include(a => a.Order)
                                           .ThenInclude(o => o.Spot)
                                           .ThenInclude(o => o.Weapon)
                                           .Include(a => a.Order)
                                           .ThenInclude(o => o.Weapons)
                                           .FirstOrDefaultAsync();

                if (assignment.Order.Spot.Weapon != null)
                    assignment.Order.Spot.Weapon.InStock = true;
                assignment.Status = "accepted";
                var weapon = assignment.WeaponOrder.Weapon;
                assignment.Order.Spot.Weapon = weapon;
                assignment.Order.Spot.Weapon.InStock = false;
                assignment.Order.Spot.Weapon.NumberOfUse += 1;
                assignment.Order.Weapons.Add(assignment.WeaponOrder);
            }
            else if (assignment.Type == "ammo")
            {
                assignment = await _dbContext.Assignments.Where(a => a.Id == command.AssignmentId)
                                           .Include(a => a.AmmoOrder)
                                           .ThenInclude(a => a.Ammunition)
                                           .Include(a => a.Order)
                                           .ThenInclude(o => o.Spot)
                                           .ThenInclude(o => o.AmmoOrder)
                                           .Include(a => a.Order)
                                           .ThenInclude(o => o.AmmoOrders)
                                           .FirstOrDefaultAsync();

                assignment.Status = "accepted";
                var ammoOrder = assignment.AmmoOrder;
                ammoOrder.Ammunition.QuantityInStock -= ammoOrder.Quantity;
                assignment.Order.Spot.AmmoOrder = ammoOrder;
                assignment.Order.AmmoOrders.Add(ammoOrder);
            }
            else if (assignment.Type == "instructor")
            {
                
                assignment = await _dbContext.Assignments.Where(a => a.Id == command.AssignmentId)
                                           .Include(a => a.Order)
                                           .ThenInclude(o => o.Spot)
                                           .Include(a => a.User)                                          
                                           .FirstOrDefaultAsync();
                if (assignment.User.Status == "busy")
                    throw new ApplicationException("User is busy");
                assignment.User.Status = "busy";
                assignment.Status = "accepted";
                assignment.Order.Spot.Instructor = assignment.User;
                assignment.Order.IsInstructor = true;
            }
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeclineAssignment(GetAssignmentById command)
        {
            var assignment = await _dbContext.Assignments.Where(a => a.Id == command.AssignmentId).FirstOrDefaultAsync();
            if (assignment == null)
                throw new KeyNotFoundException("Assignment doesn't exist");
            assignment.Decline();
            await _dbContext.SaveChangesAsync();
        }
    }
}
