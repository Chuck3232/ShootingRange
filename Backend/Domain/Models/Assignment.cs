using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Assignment
    { 
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
        #nullable enable
        public Weapon? Weapon { get; set; }
        public Ammunition? Ammunition { get; set; }
        public bool Instuctor { get; set; }

        public Assignment(Customer customer, User user, Order order, Weapon? weapon, Ammunition? ammunition, bool instuctor)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            User = user;
            Order = order;
            Weapon = weapon;
            Ammunition = ammunition;
            Instuctor = instuctor;
        }
    }
}
