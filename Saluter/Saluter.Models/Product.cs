using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Product> Accessories { get; set; }

        public Product(string id, string name, int price, List<Product> accessories = null)
        {
            Id = id;
            Name = name;
            Price = price;

            if (accessories != null)
            {
                Accessories = new List<Product>();
                Accessories.AddRange(accessories);
            }                
        }
    }
}
