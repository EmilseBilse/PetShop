using System;
using System.Dynamic;

namespace Ntombizodwa.PetShop.Core.Models
{
    public class Pet
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}