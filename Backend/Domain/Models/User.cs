using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public Role Role { get; set; }
        public string Email { get;  set; }

        public User(string firstName, string lastName, Role role, string email)
        {
            Id = Guid.NewGuid();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetMail(email);
            Role = role;
           
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
