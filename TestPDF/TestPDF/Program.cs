using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Tagging;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPDF
{
    class Program
    {
        public static readonly string DEST = "./simple_table.pdf";
        public static readonly string SRC = "../../Resources/pdfdemerde.pdf";

        public static void Main(string[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            new Program().ManipulatePdf(DEST);

            Console.ReadLine();
        }

        private void ManipulatePdf(string dest)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(SRC), new PdfWriter(dest));
            Document doc = new Document(pdfDoc);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            var fields = form.GetFormFields();
            PageSize ps = pdfDoc.GetDefaultPageSize();
            Console.WriteLine(fields.Count);
            foreach(var v in fields){
                if(v.Key == "PipiCaca")
                {
                    v.Value.SetValue("Michel");
                }
                else
                {
                    Console.WriteLine("Sheesh");
                    Console.WriteLine(v.Value.GetKids().GetType());
                }
            }

            PdfPage newPage = pdfDoc.AddNewPage();
            Table table = new Table(UnitValue.CreatePercentArray(8)).UseAllAvailableWidth();

            for (int i = 0; i < 16; i++)
            {
                table.AddCell("hi");
            }
            IRenderer tableRenderer = table.CreateRendererSubTree().SetParent(doc.GetRenderer());

            LayoutResult tableLayoutResult =

                    tableRenderer.Layout(new LayoutContext(new LayoutArea(0, new Rectangle(ps.GetWidth(), 1000))));

            float totalHeight = tableLayoutResult.GetOccupiedArea().GetBBox().GetHeight();

            table.SetFixedPosition(pdfDoc.GetPageNumber(newPage), doc.GetLeftMargin(), ps.GetHeight() - totalHeight, table.GetWidth());
            doc.Add(table);
            

            doc.Close();


            pdfDoc.Close();
        }
    }
}
