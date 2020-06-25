using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Data
{
    public class InMemoryProductData : IProductData
    {
        public List<Product> Products { get; set; } = new List<Product>()
        {
            new Product("BUN020F300", "3way valve", 12000),
            new Product("BUN032F300", "3way valve", 14000),
            new Product("BUN050F300", "3way valve", 16000),
            new Product("EGT347F300", "Duct temperature sensor", 7000),
            new Product("TFL201F300", "Frost protection thermostat", 22000),
            new Product("EY-RC500F001", "Room controller unit", 62000),
        };

        public List<Product> GetProductsById(string id)
        {
            List<Product> products = new List<Product>();

            products.AddRange(Products.Where(x => x.Id.Contains(id.ToUpper())).ToList());

            return products;
        }

        public List<Product> GetProductsByName(string name)
        {
            List<Product> products = new List<Product>();

            products.AddRange(Products.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList());

            return products;
        }
    }
}
