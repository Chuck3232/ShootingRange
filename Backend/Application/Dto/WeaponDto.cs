
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dto
{
	public class WeaponDto
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Caliber { get; set; }
        public int NumberOfUse { get; set; }
        public string DateOfProduction { get; set; }
        public float Price { get; set; }
        public bool InStock { get; set; }
    }
}
