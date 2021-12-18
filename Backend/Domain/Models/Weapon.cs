using StudentOrganizer.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Weapon : Entity
    {        
        public string Name { get; set; }
        public string Type { get; set; }
        public string Caliber { get; set; }
        public int NumberOfUse { get; set; }
        public string DateOfProduction { get; set; }
        public float Price { get; set; }
        public int QuantityInStock { get; set; }

        public Weapon(string name, string type, string caliber, string dateOfProduction, float price)
        {
            SetName(name);
            Type = type;
            SetCaliber(caliber);
            NumberOfUse = 0;
            SetDateOfProduction(dateOfProduction);
            QuantityInStock = 1;
            SetPrice(price);
        }
        public Weapon(Guid WeaponId)
        {
            Id = WeaponId;
        }

        public Weapon()
        {            
        }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("First name cannot be empty.");
            }
            Name = name;
        }
        public void SetCaliber(string caliber)
        {
            if (string.IsNullOrWhiteSpace(caliber))
            {
                throw new Exception("Caliber cannot be empty.");
            }
            Caliber = caliber;
        }
        public void SetDateOfProduction(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                throw new Exception("Date cannot be empty.");
            }
            DateOfProduction = date;
        }
        public void SetPrice(float price)
        {
            if (float.IsNaN(price))
            {
                throw new Exception("Price is NaN");
            }
            Price=price;
        }
    }
}
