using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Ntombizodwa.PetShop.Core.Models
{
    public class Pet
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public Insurance Insurance { get; set; }
        public Owner Owner { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public List<Color> Colors { get; set; }
    }
}