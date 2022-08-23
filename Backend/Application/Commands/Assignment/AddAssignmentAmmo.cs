using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Assignment
{
    public class AddAssignmentAmmo
    {
        public Guid CustomerId { get; set; }

        public Guid AmmoId { get; set; }
        public int AmmoQuant { get; set; }
    }
}
