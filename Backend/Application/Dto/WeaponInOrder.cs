using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class WeaponInOrder
    {
        public Guid WeaponId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Caliber { get; set; }
        public string DateOfProduction { get; set; }
        public float Price { get; set; }

    }
}
