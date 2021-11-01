using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dto
{
	public class WeaponDto
	{
        public string Name { get; set; }
        public string Type { get; set; }
        public string Caliber { get; set; }
        public int NumberOfUse { get; set; }
        public string DateOfProduction { get; set; }
        public float Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}
