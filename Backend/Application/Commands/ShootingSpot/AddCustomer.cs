using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ShootingSpot
{
    public class AddCustomer
    {
        public Guid spotId { get; set; }
        public Guid customerId { get; set; }
    }
}
