using Application.Commands.Ammunition;
using Application.Commands.User;
using Domain.Models;
using StudentOrganizer.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IAmmunitionServices : IService
    {
        Task AddAmmo(AddAmmo command);
        IQueryable<Ammunition> GetallAmmo();
        Task<List<Ammunition>> GetAmmoToWeapon(GetAmmoToWeapon command);
    }
}
