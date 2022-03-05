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
            //On récupère les fields du formulaire dans le doc
            var fields = form.GetFormFields();
            
            //On itère sur tous les fields et on met le field qui a pour nom "PipiCaca" à "Michel"
            foreach(var v in fields){
                if(v.Key == "PipiCaca")
                {
                    v.Value.SetValue("Michel");
                }
            }
            //On crée une nouvelle page
            PdfPage newPage = pdfDoc.AddNewPage();

            //On crée une table qui a 8 colonnes qui prendront équitablement la width de la table
            Table table = new Table(UnitValue.CreatePercentArray(8)).UseAllAvailableWidth();

            //On rajoute 16 (8*2) "hi". En gros 2 lignes de "hi"
            for (int i = 0; i < 16; i++)
            {
                table.AddCell("hi");
            }

            //Trickery pour choper la hauteur de la table
            PageSize ps = pdfDoc.GetDefaultPageSize();
            IRenderer tableRenderer = table.CreateRendererSubTree().SetParent(doc.GetRenderer());

            LayoutResult tableLayoutResult =

                    tableRenderer.Layout(new LayoutContext(new LayoutArea(0, new Rectangle(ps.GetWidth(), 1000))));

            float totalHeight = tableLayoutResult.GetOccupiedArea().GetBBox().GetHeight();

            //On met la table à la page qu'on vient de rajouter, et on la met tout en haut (on doit avoir la taille de la table donc tout le code au dessus >:(
            table.SetFixedPosition(pdfDoc.GetPageNumber(newPage), doc.GetLeftMargin(), ps.GetHeight() - totalHeight, table.GetWidth());

            //On rajoute la table au document
            doc.Add(table);
            

            doc.Close();


            pdfDoc.Close();
        }
    }
}
