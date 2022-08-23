using Domain.Common;
using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EntryRecord : Entity
    {
        public DateTime DateEntry { get; set; }

        public DateTime DateExit { get; set; }
        public Customer Customer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #nullable enable
        public string? FirearmsLicense { get; set; }
        #nullable enable
        public string? Adress { get; set; }

        public EntryRecord( string firstName, string lastName, Customer customer, string firearmsLicense, string adress)
        {
            DateEntry = DateTime.Now;
            DateExit = default;
            Customer = customer;
            SetFirstName(firstName);
            SetLastName(lastName);
            FirearmsLicense = firearmsLicense;
            Adress = adress;
        }
        public EntryRecord(Guid EntryRecordsId)
        {
            Id = EntryRecordsId;
        }
        public void SetDateExit()
        {
            DateExit = DateTime.Now;
        }
        public EntryRecord()
        {
        }
        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new AppException("First name cannot be empty.");
            }
            FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new AppException("Last name cannot be empty.");
            }
            LastName = lastName;
        }
    }
}
