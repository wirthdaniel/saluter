using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.Services.PdfServices
{
    public interface IPdfExporter
    {
        bool Export(OfferContent content, string path);
    }
}
