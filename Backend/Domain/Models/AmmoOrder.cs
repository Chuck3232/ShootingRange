using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AmmoOrder : Entity
    {  
        public Ammunition Ammunition { get; set; }
        public int Quantity { get; set; }

        public AmmoOrder(Ammunition ammunition, int quantity)
        {
            Ammunition = ammunition;
            Quantity = quantity;
        }

        public AmmoOrder()
        {
            
        }
    }
}
