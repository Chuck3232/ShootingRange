using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Ammunition
{
    public class GetAmmoById
    {
        public Guid AmmoId { get; set; }
        public int NewQuantity { get; set; }
        public float price { get; set; }
    }
}
