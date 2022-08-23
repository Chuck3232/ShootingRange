using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AmmoOrderDto
    {
        public Guid AmmunitionId { get; set; }
        public string Caliber { get; set; }
        public string Type { get; set; }
        public string Producer { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public float Sum { get; set; }

    }
}
