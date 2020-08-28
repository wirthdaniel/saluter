using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Models
{
    public class OfferContent
    {
        public string OfferId { get; set; }
        public Customer Customer { get; set; }
        public string Sender { get; set; }
        public List<SelectedProduct> SelectedProducts { get; set; }
    }
}
