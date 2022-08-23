using Application.Commands.Customer;
using Application.Commands.EntryRecord;
using Application.Dto;
using Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRange.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/EntryRecord")]
    [ApiController]
    [Authorize]
    public class EntryRecordController : ControllerBase
    {
        public readonly IEntryRecordServices _entryRecordServices;

        public EntryRecordController(IEntryRecordServices entryRecordServices)
        {
            _entryRecordServices = entryRecordServices;
        }
        [HttpPost("{customerId}")]
        public async Task<IActionResult> EntryRecord(Guid customerId)
        {
            var command = new GetCustomerById { CustomerId = customerId };
            await _entryRecordServices.AddEntryRecord(command);
            return Ok();
        }
        [HttpPatch("{recordId}")]
        public async Task<IActionResult> EndRecord(Guid recordId)
        {
            var command = new GetRecordById { Id = recordId};
            await _entryRecordServices.EndRecord(command);
            return Ok();
        }
        [HttpGet]
        public ActionResult<List<EntryRecordDto>> GetAllEntryRecords()
        {
            return Ok(_entryRecordServices.GetallEntryRecords());
        }
    }
}
