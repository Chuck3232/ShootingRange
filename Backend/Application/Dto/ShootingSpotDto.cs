using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ShootingSpotDto
    {
        public int Distance { get; set; }
        #nullable enable
        public DateTime DateEntry { get; set; }
        #nullable enable
        public DateTime DateExit { get; set; }
        #nullable enable
        public Customer? Customer { get; set; }
        #nullable enable
        public Weapon? Weapon { get; set; }
        #nullable enable
        public AmmoOrder? AmmoOrder { get; set; }
        public User? Instructor { get; set; }
    }
}
