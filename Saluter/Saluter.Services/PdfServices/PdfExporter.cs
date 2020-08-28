using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using Saluter.Models;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace Saluter.Services.PdfServices
{
    public class PdfExporter : IPdfExporter
    {
        public bool Export(OfferContent content, string path)
        {

            Document doc = new Document();

            //var paragraph1 = doc.AddSection().AddParagraph();

            //paragraph1.Format.Font.Color = Color.FromCmyk(100, 30, 20, 50);

            //paragraph1.AddFormattedText("SAH001", TextFormat.Underline);

            var section = doc.AddSection();
            section.Headers.Primary.AddImage(@"..\..\..\Saluter.GUI\Resources\sauter_logo.png");

            var addressFrame = section.AddTextFrame();
            addressFrame.AddParagraph("Adress: " + content.Customer.Name);
            

            var table = section.AddTable();

            table.Columns = new Columns();

            for (int i = 0; i < 5; i++)
            {
                table.Columns.AddColumn();
            }

            var rowZero = table.Rows.AddRow();
            rowZero.Cells[0].AddParagraph("ID");
            rowZero.Cells[1].AddParagraph("Name");
            rowZero.Cells[2].AddParagraph("Quantity");
            rowZero.Cells[3].AddParagraph("Unit price");
            rowZero.Cells[4].AddParagraph("Total price");

            foreach (var product in content.SelectedProducts)
            {
                var row = table.Rows.AddRow();
                row.Cells[0].AddParagraph(product.Id);
                row.Cells[1].AddParagraph(product.Name);
                row.Cells[2].AddParagraph(product.Quantity.ToString());
                row.Cells[3].AddParagraph(product.Price.ToString());
                row.Cells[4].AddParagraph(product.TotalPrice.ToString());

            }

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true)
            {
                Document = doc
            };
            pdfRenderer.RenderDocument();
          
            pdfRenderer.PdfDocument.Save(path);

            return true;
        }
    }
}
