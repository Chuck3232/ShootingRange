using Domain.Common;
using StudentOrganizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ammunition : Entity
    {
        public string Caliber { get; set; }
        public string Type { get; set; }
        public string Producer { get; set; }
        public float Price { get; set; }
        public int QuantityInStock { get; set; }

        public Ammunition(string caliber, string type, string producer, float price, int quantityInStock)
        {
            SetValues(caliber, type, producer, price, quantityInStock);
        }
        public void Update(string caliber, string type, string producer, float price, int quantityInStock)
        {
            SetValues(caliber, type, producer, price, quantityInStock);
        }
        public void SetValues(string caliber, string type, string producer, float price, int quantityInStock)
        {
            SetCaliber(caliber);
            SetType(type);
            SetProducer(producer);
            SetPrice(price);
            QuantityInStock = quantityInStock;
        }
        public Ammunition(Guid AmmunitionId)
        {
            Id = AmmunitionId;
        }
        public Ammunition()
        {
        }
        public void SetCaliber(string caliber)
        {
            if (string.IsNullOrWhiteSpace(caliber))
            {
                throw new AppException("Caliber cannot be empty.");
            }
            Caliber = caliber;
        }
        public void SetType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new AppException("Type cannot be empty.");
            }
            Type = type;
        }
        public void SetProducer(string producer)
        {
            if (string.IsNullOrWhiteSpace(producer))
            {
                throw new AppException("Producer cannot be empty.");
            }
            Producer = producer;
        }
        public void SetPrice(float price)
        {
            if (string.IsNullOrWhiteSpace(price.ToString()))
            {
                throw new AppException("Price cannot be empty.");
            }
            Price = price;
        }
    }
}
