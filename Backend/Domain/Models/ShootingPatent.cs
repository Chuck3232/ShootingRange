using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ShootingPatent
    {
        public string Series { get; set; }
        public string Number { get; set; }
        public string Permission { get; set; }

        public ShootingPatent(string series, string number, string permission)
        {
            Series = series;
            Number = number;
            Permission = permission;
        }
    }
}
