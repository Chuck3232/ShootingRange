using Application.Commands.Weapon;
using Domain;
using StudentOrganizer.Infrastructure.IServices;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Interface
{

    public interface IWeaponService : IService
    {   
        Task AddWeapon(AddWeapon command);
        IQueryable<Weapon> GetallWeapons();
        Task DeleteWeapon(GetWeaponById command);
        Task ResetNumberOfUse(GetWeaponById command);
    }
}
