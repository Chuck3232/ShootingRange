using Application.Commands.Weapon;
using Application.Dto;
using Application.Services.Interface;
using Domain;
using Infrascture.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly ApplicationDbContext _dbContext;

        public WeaponService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddWeapon(AddWeapon command)
        {
            var weapon = new Weapon(command.Name, command.Type, command.Caliber, command.DateOfProduction, command.Price);
            await _dbContext.AddAsync(weapon);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Weapon> GetallWeapons()
        {
            return _dbContext.Weapons;
        }

        public async Task DeleteWeapon(GetWeaponById command)
        {
            //var weaponToDelete = await _dbContext.Weapons.FirstOrDefaultAsync(w=>w.Id==command.WeaponId);
            //if (weaponToDelete == null)
            //    return new Exception("weapon doesn't exist"); 
            _dbContext.Remove(_dbContext.Weapons.Where(w => w.Id == command.WeaponId).FirstOrDefault());
            await _dbContext.SaveChangesAsync();
        }

        public async Task ResetNumberOfUse(GetWeaponById command)
        {
            var weapon = await _dbContext.Weapons.FirstOrDefaultAsync(w => w.Id == command.WeaponId);
            weapon.NumberOfUse = 0;
            await _dbContext.SaveChangesAsync();
        }
    }
}