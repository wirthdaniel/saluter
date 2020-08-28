using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Data
{
    public interface ICustomerData
    {
        List<Customer> GetCustomerByName(string name);

        List<Customer> GetAllCustomers();
    }
}
