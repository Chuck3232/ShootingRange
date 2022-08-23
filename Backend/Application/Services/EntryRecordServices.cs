using Application.Commands.Customer;
using Application.Commands.EntryRecord;
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
    public class EntryRecordServices : IEntryRecordServices
    {
        private readonly ApplicationDbContext _dbContext;

        public EntryRecordServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEntryRecord(GetCustomerById command)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == command.CustomerId);
            if (customer == null)
                throw new KeyNotFoundException("Customer doesnt't exist");
            var address = new String(customer.City +" "+ customer.Street + " " + customer.BuldingNumber);
            var entryRecord = new EntryRecord(customer.FirstName, customer.LastName, customer, customer.FirearmsLicense, address);
            await _dbContext.AddAsync(entryRecord);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EndRecord(GetRecordById command)
        {
            var record = await _dbContext.EntryRecords.FirstOrDefaultAsync(r => r.Id == command.Id);
            if (record == null)
                throw new KeyNotFoundException("Record doesnt't exist");
            record.DateExit = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }
        public List<EntryRecordDto> GetallEntryRecords()
        {
            var records = _dbContext.EntryRecords.Include(r => r.Customer);          
            var recordsDto = records.Select(r => new EntryRecordDto
            {
                Id = r.Id,
                DateEntry = r.DateEntry.ToString("yyyy'-'MM'-'dd' 'HH':'mm"),
                DateExit = r.DateExit.ToString("yyyy'-'MM'-'dd' 'HH':'mm"),
                CustomerId = r.Customer.Id,
                FirstName = r.FirstName,
                LastName = r.LastName,
                FirearmsLicense = r.FirearmsLicense,
                Adress = r.Adress
        });
         
            return recordsDto.ToList();
        }
    }
}
