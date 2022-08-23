using Application.Commands.ShootingSpot;
using Application.Dto;
using Domain.Models;
using StudentOrganizer.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IShootingSpotServices : IService
    {
        Task AddShootingSpot(AddShootingSpot command);
        Task AddCustomerAndCreateOrder(AddCustomer command);
        Task EndOrder(EndOrder command);

        IQueryable<ShootingSpot> GetAllSpots();
    }
}
