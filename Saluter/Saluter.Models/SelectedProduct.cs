using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Models
{
    public class SelectedProduct : Product
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public SelectedProduct(string id, string name, int price, int quantity, double totalPrice, List<Product> accessories = null) : base(id, name, price, accessories)
        {
            Price = price;
            TotalPrice = totalPrice;
            Quantity = quantity;

        }
    }
}
