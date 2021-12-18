using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Commands.Ammunition
{
    public class AddAmmo
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Caliber { get; set; }
        public string Type { get; set; }
        public string Producer { get; set; }
        public float Price { get; set; }
        public int QuantityInStock { get; set; }

    }
}
