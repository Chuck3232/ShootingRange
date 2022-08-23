using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WeaponOrder : Entity
    {
        public Weapon Weapon { get; set; }
      
        public WeaponOrder(Weapon weapon)
        {
            Weapon = weapon;
        }
        public WeaponOrder()
        {
           
        }
    }
}
