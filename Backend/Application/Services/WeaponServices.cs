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
    public class WeaponServices : IWeaponServices
    {
        private readonly ApplicationDbContext _dbContext;

        public WeaponServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddWeapon(WeaponDto command)
        {
            var weapon = new Weapon(command.Name, command.Type, command.Caliber, command.DateOfProduction, command.Price);
            await _dbContext.AddAsync(weapon);
            await _dbContext.SaveChangesAsync();
        }



        public IEnumerable<WeaponDto> GetallWeapons()
        {

            var weapons = _dbContext.Weapons;
            var weaponsDto = weapons.Select(w => new WeaponDto
            {
                Id = w.Id,
                Name = w.Name,
                Type = w.Type,
                Caliber = w.Caliber,
                NumberOfUse = w.NumberOfUse,
                DateOfProduction = w.DateOfProduction,
                Price = w.Price,
                InStock = w.InStock
            });
            return weaponsDto.ToList();
        }

        public List<WeaponDto> GetAllWeaponsToCustomer()
        {
            var weapons = _dbContext.Weapons.Where(w => w.InStock == true);
            var weaponsDto = weapons.Select(w => new WeaponDto
            {
                Id = w.Id,
                Name = w.Name,
                Type = w.Type,
                Caliber = w.Caliber,
                NumberOfUse = w.NumberOfUse,
                DateOfProduction = w.DateOfProduction,
                Price = w.Price,
                InStock = w.InStock
            });
            return weaponsDto.ToList();
            
        }
        public async Task EditWeapon(EditWeapon command)
        {
            var weapon = await _dbContext.Weapons.FirstOrDefaultAsync(a => a.Id == command.Id);
            if (weapon == null)
                throw new KeyNotFoundException("Weapon doesn't exist");
            weapon.Update(command.Name, command.Type, command.Caliber, command.DateOfProduction, command.Price, command.InStock);
       
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteWeapon(GetWeaponById command)
        {
            var weaponToDelete = await _dbContext.Weapons.FirstOrDefaultAsync(w=>w.Id==command.WeaponId);
            if (weaponToDelete == null)
               throw new KeyNotFoundException("Weapon doesn't exist"); 
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