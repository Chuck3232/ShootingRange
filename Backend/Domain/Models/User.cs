using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string PasswordHash { get; set; }

        public int RoleId { get;  set; }
        public virtual Role Role { get; set; }

        

        public User(string email, string firstName, string lastName  )
        {
            SetMail(email);
            SetFirstName(firstName);
            SetLastName(lastName);           
            RoleId = 5;
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
