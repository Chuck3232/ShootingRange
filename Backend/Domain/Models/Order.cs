using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public IList<Weapon> Weapons{ get; set; }
        public IList<Ammunition> Ammunitions { get; set; }
        public int TrainigHours { get; set; }
        public Order(User user)
        {
            Id = Guid.NewGuid();
            User = user;
            TrainigHours = 0;
        }
    }
}
