using Application.Commands.Ammunition;
using Application.Dto;
using Application.Services.Interface;
using Domain.Models;
using Infrascture.DbContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    
    public class AmmunitionServices : IAmmunitionServices
    {
        private readonly ApplicationDbContext _dbContext;

        public AmmunitionServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAmmo(AddAmmo command)
        {
            var ammo = new Ammunition(command.Caliber, command.Type, command.Producer, command.Price, command.QuantityInStock);
            await _dbContext.AddAsync(ammo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditAmmo(AddAmmo command)
        {
            var ammo = await _dbContext.Ammunitions.FirstOrDefaultAsync(a => a.Id == command.Id);
            if (ammo == null)
                throw new KeyNotFoundException("Ammo doesn't exist");
            ammo.Update(command.Caliber, command.Type, command.Producer, command.Price, command.QuantityInStock);
            await _dbContext.SaveChangesAsync();
        }
        public List<AmmunitionDto> GetallAmmo()
        {
            var ammo = _dbContext.Ammunitions;
            var ammoDto = ammo.Select(a => new AmmunitionDto
            {
                Id = a.Id,
                Caliber = a.Caliber,
                Type = a.Type,
                Producer = a.Producer,
                Price = a.Price,
                QuantityInStock = a.QuantityInStock
            });
            return ammoDto.ToList();
        }
        public List<AmmunitionDto> GetAmmoToCustomer()
        {
            var ammo = _dbContext.Ammunitions.Where(a => a.QuantityInStock > 0);
            var ammoDto = ammo.Select(a => new AmmunitionDto
            {
                Id = a.Id,
                Caliber = a.Caliber,
                Type = a.Type,
                Producer = a.Producer,
                Price = a.Price,
                QuantityInStock = a.QuantityInStock
            });
            return ammoDto.ToList();
        }

        public async Task<List<Ammunition>> GetAmmoToWeapon(GetAmmoToWeapon command)
        {
            var weapon = await _dbContext.Weapons.FirstOrDefaultAsync(w => w.Id == command.WeaponId);
            return await _dbContext.Ammunitions.Where(a => a.Caliber.Contains(weapon.Caliber)).ToListAsync();
            
        }
    }
}

