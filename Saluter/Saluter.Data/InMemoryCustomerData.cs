using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saluter.Models;

namespace Saluter.Data
{
    public class InMemoryCustomerData : ICustomerData
    {
        readonly ObservableCollection<Customer> customers = new ObservableCollection<Customer>()
        {
            new Customer("Szatmári"),
            new Customer("Gábőr"),
            new Customer("Nivelco"),
            new Customer("Sonnerus"),
            new Customer("Mile")
        }; 

        public List<Customer> GetAllCustomers()
        {
            return customers.OrderBy(x => x.Name).ToList();
        }

        public List<Customer> GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
