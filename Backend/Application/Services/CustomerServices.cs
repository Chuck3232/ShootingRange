using Application.Commands.Customer;
using Application.Dto;
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
    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task AddCustomer(CustomerDto command)
        {
            var customer = new Customer(command.FirstName, command.LastName, command.Email, command.City, command.Street, command.BuldingNumber, command.FirearmsLicense);
            await _dbContext.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }
        public List<CustomerDto> GetallCustomers()
        {
            var customers = _dbContext.Customers;
            var customersDto = customers.Select(a => new CustomerDto
            {
                CustomerId = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                City = a.City,
                Street = a.Street,
                BuldingNumber = a.BuldingNumber,
                FirearmsLicense = a.FirearmsLicense
            }); ;
            return customersDto.ToList();
        }
        public async Task UpdateCustomer(CustomerUpdate command)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == command.Id);
            if (customer == null)
                throw new KeyNotFoundException("Customer doesnt't exist");
            customer.Update(command.FirstName, command.LastName, command.Email, command.City, command.Street, command.BuldingNumber, command.FirearmsLicense);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteCustomer(GetCustomerById command)
        {
            var weaponToDelete = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == command.CustomerId);
            if (weaponToDelete == null)
                throw new KeyNotFoundException("Customer doesn't exist");
            _dbContext.Remove(_dbContext.Customers.Where(c => c.Id == command.CustomerId).FirstOrDefault());
            await _dbContext.SaveChangesAsync();
        }
    }
}
