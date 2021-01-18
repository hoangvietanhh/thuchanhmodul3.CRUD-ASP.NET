using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thuchanhmodul3.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id)
        {
            Id = id;
        }

        public Product(int id, string name, float price) 
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}