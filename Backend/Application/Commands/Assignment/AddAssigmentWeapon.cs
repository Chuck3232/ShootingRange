using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Assignment
{
    public class AddAssigmentWeapon
    {
        public Guid CustomerId { get; set; }
        #nullable enable
        public Guid WeaponId { get; set; }

    }
}
