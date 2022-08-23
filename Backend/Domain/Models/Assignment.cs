using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Assignment : Entity
    {
        public User User { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        #nullable enable
        public WeaponOrder? WeaponOrder { get; set; }
        public AmmoOrder? AmmoOrder { get; set; }
        public bool Instuctor { get; set; }
       

        public Assignment(User user,
                          Order order,
                          WeaponOrder? weapon,
                          AmmoOrder? ammoOrder,
                          bool instuctor,
                          string type)
        {
            User = user;
            Order = order;
            Status = "open";
            WeaponOrder = weapon;
            AmmoOrder = ammoOrder;
            Instuctor = instuctor;
            Type = type;
        }
        public void Decline()
        {
            Status = "rejected";
        }

        public Assignment()
        { }
    }
}
