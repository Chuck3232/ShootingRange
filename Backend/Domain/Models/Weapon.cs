using Domain.Common;
using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Weapon : Entity
    {        
        public string Name { get; set; }
        public string Type { get; set; }
        public string Caliber { get; set; }
        public int NumberOfUse { get; set; }
        public string DateOfProduction { get; set; }
        public float Price { get; set; }
        public bool InStock { get; set; }

        public Weapon(string name, string type, string caliber, string dateOfProduction, float price)
        {
            SetName(name);
            SetType(type);
            SetCaliber(caliber);
            NumberOfUse = 0;
            SetDateOfProduction(dateOfProduction);
            InStock = true;
            SetPrice(price);
        }
        public void Update(string name, string type, string caliber, string dateOfProduction, float price, bool inStock)
        {
            SetName(name);
            SetType(type);
            SetCaliber(caliber);
            SetDateOfProduction(dateOfProduction);
            InStock = inStock;
            SetPrice(price);
        }
        public Weapon(Guid WeaponId)
        {
            Id = WeaponId;
        }

        public Weapon()
        {            
        }
        public void SetType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new AppException("Type name cannot be empty.");
            }
            Type = type;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new AppException("First name cannot be empty.");
            }
            Name = name;
        }
        public void SetCaliber(string caliber)
        {
            if (string.IsNullOrWhiteSpace(caliber))
            {
                throw new AppException("Caliber cannot be empty.");
            }
            Caliber = caliber;
        }
        public void SetDateOfProduction(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                throw new AppException("Date cannot be empty.");
            }
            DateOfProduction = date;
        }
        public void SetPrice(float price)
        {
            if (float.IsNaN(price))
            {
                throw new AppException("Price is NaN");
            }
            Price=price;
        }
    }
}
