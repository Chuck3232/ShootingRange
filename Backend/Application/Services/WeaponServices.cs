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

        public Task<Weapon> GetAsync(Guid id)
        {
            return _dbContext.Weapons.Where(w=>w.Id==id)
                .Include(w=>w.Name)
                .Include(w=>w.Price)
                .FirstOrDefaultAsync();
        }

        public  IQueryable<Weapon> GetallWeapons()
        {
            return _dbContext.Weapons;
        }
    }
}