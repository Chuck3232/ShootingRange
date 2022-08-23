using Application.Commands.Weapon;
using Application.Dto;
using Domain;
using Domain.Models;
using StudentOrganizer.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Interface
{

    public interface IWeaponServices : IService
    {   
        Task AddWeapon(WeaponDto command);
        IEnumerable<WeaponDto> GetallWeapons();
        Task DeleteWeapon(GetWeaponById command);
        Task ResetNumberOfUse(GetWeaponById command);
        List<WeaponDto> GetAllWeaponsToCustomer();
        Task EditWeapon(EditWeapon command);
    }
}
