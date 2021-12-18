using Application.Commands.Ammunition;
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
        public IQueryable<Ammunition> GetallAmmo()
        {
            return _dbContext.Ammunitions;
        }

        public async Task<List<Ammunition>> GetAmmoToWeapon(GetAmmoToWeapon command)
        {
            var weapon = await _dbContext.Weapons.FirstOrDefaultAsync(w => w.Id == command.WeaponId);
            return await _dbContext.Ammunitions.Where(a => a.Caliber.Contains(weapon.Caliber)).ToListAsync();
            
        }
    }
}

