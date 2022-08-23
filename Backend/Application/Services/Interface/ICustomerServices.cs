using Application.Commands.Customer;
using Application.Dto;
using StudentOrganizer.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface ICustomerServices : IService
    {
        Task AddCustomer(CustomerDto command);
        Task UpdateCustomer(CustomerUpdate command);
        Task DeleteCustomer(GetCustomerById command);
        List<CustomerDto> GetallCustomers();
    }
}
