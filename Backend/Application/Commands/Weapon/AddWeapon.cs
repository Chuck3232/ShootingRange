using Newtonsoft.Json;
using System;

namespace Application.Commands.Weapon
{
    public class AddWeapon
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Caliber { get; set; }
        [JsonIgnore]
        public int NumberOfUse { get; set; }
        public string DateOfProduction { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public int QuantityInStock { get; set; }
    }
}
