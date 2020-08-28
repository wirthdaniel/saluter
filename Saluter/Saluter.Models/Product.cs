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
        public List<int> Prices { get; set; }
        public List<Product> Accessories { get; set; }

        public Product(string id, string name, int price, List<Product> accessories = null)
        {
            Id = id;
            Name = name;
            Prices = new List<int>() { price, price * 2 };

            if (accessories != null)
            {
                Accessories = new List<Product>();
                Accessories.AddRange(accessories);
            }                
        }

        
    }

}
