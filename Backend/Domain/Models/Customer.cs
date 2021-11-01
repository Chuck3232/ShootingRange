using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        #nullable enable
        public FirearmsLicense? FirearmsLicense { get; set; } 
        public ShootingPatent? ShootingPatent { get; set; }

        public Customer(string firstName, string lastName, string email, Address address, FirearmsLicense? firearmsLicense, ShootingPatent? shootingPatent)
        {
            Id = Guid.NewGuid();
            Address = address;
            SetFirstName(firstName);
            SetLastName(lastName);
            SetMail(email);
            FirearmsLicense = firearmsLicense;
            ShootingPatent = shootingPatent;
        }
        public Customer()
        {
        }
        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("First name cannot be empty.");
            }
            FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Last name cannot be empty.");
            }
            LastName = lastName;
        }
        public void SetMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email cannot be empty.");
            }
            Email = email;
        }

    }
}

