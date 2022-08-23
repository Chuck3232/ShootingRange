using Application.Commands.Customer;
using Application.Commands.EntryRecord;
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
    public interface IEntryRecordServices : IService
    {
        Task AddEntryRecord(GetCustomerById command);
        List<EntryRecordDto> GetallEntryRecords();
        Task EndRecord(GetRecordById command);
    }
}
