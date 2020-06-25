using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Data
{
    public interface IProductData
    {
        List<Product> GetProductsById(string id);

        List<Product> GetProductsByName(string name);
    }
}
