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
        Product GetProductById(string id);

        Product GetProductByName(string name);
    }
}
