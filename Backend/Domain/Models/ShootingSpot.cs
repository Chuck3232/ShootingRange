using Domain.Common;
using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ShootingSpot : Entity
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


        public ShootingSpot(int distance)
        {
            DateEntry = DateTime.Now;
            SetDistance(distance);
        }
        public void Reset()
        {
            Customer = null;
            Weapon = null;
            AmmoOrder = null;
            Instructor = null;
        }
        public void SetDistance(int distance)
        {
            if (string.IsNullOrWhiteSpace(distance.ToString()))
            {
                throw new AppException("Distance cannot be empty.");
            }
            Distance = distance;
        }
    }
}
