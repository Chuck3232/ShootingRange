using Application.Commands.Ammunition;
using Application.Dto;
using Domain.Models;
using StudentOrganizer.Infrastructure.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IAmmunitionServices : IService
    {
        Task AddAmmo(AddAmmo command);
        List<AmmunitionDto> GetallAmmo();
        Task<List<Ammunition>> GetAmmoToWeapon(GetAmmoToWeapon command);
        Task EditAmmo(AddAmmo command);
        List<AmmunitionDto> GetAmmoToCustomer();
    }
}
