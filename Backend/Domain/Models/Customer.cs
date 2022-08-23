using Domain.Common;
using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuldingNumber { get; set; }
        #nullable enable
        public string? FirearmsLicense { get; set; } 


        public Customer(string firstName, string lastName, string email, string city, string street, string buldingnumber, string? firearmsLicense )
        {
            SetValues(firstName, lastName, email, city, street, buldingnumber, firearmsLicense);           
        }
        public void Update(string firstName, string lastName, string email, string city, string street, string buldingnumber, string? firearmsLicense)
        {
            SetValues(firstName, lastName, email, city, street, buldingnumber, firearmsLicense);
        }
        private void SetValues(string firstName, string lastName, string email, string city, string street, string buldingnumber, string? firearmsLicense)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetMail(email);
            SetCity(city);
            SetStreet(street);
            SetBuldingNumber(buldingnumber);
            FirearmsLicense = firearmsLicense;
        }
        public Customer(Guid CustomerId)
        {
            Id = CustomerId;
        }
        public Customer()
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
        public void SetMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new AppException("Email cannot be empty.");
            }
            Email = email;
        }
        public void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new AppException("City cannot be empty.");
            }
            City = city;
        }
        public void SetStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new AppException("Street cannot be empty.");
            }
            Street = street;
        }
        public void SetBuldingNumber(string buldingNumber)
        {
            if (string.IsNullOrWhiteSpace(buldingNumber))
            {
                throw new AppException("BuldingNumber cannot be empty.");
            }
            BuldingNumber = buldingNumber;
        }

    }
}

