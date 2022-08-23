using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order : Entity
    {
        public Customer Customer { get; set; }
        public ShootingSpot Spot { get; set; }
        public  ICollection<WeaponOrder> Weapons{ get; set; }
        public  ICollection<AmmoOrder> AmmoOrders { get; set; }
        public string Status { get; set; }
        public int TrainigHours { get; set; }
        public bool IsInstructor { get; set; }
        public float Price { get; set; }
        public Order(Customer customer, ShootingSpot spot)
        {
            Customer = customer;
            Spot = spot;
            Status = "open";
            TrainigHours = 0;
            IsInstructor = false;
        }
        public void Close(float price, int trainigHours)
        {
            TrainigHours = trainigHours;
            Price = price;
            Status = "closed";
        }
        public Order()
        { }


    }
}
