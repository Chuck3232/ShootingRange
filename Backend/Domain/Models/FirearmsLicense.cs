using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FirearmsLicense
    { 
        public string NumberOfLicense { get; set; }
        public string TypeOfLicense { get; set; }
        public string LicensingAuthority { get; set; }

        public FirearmsLicense(string numberOfLicense, string typeOfLicense, string licensingAuthority)
        {
            NumberOfLicense = numberOfLicense;
            TypeOfLicense = typeOfLicense;
            LicensingAuthority = licensingAuthority;
        }
    }
}
