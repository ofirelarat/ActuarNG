using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.IO;

namespace PDFGeneratorLogic
{
    public class PDFGenerator
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }

        public PDFGenerator()
        {
        
        }

        public void GenerateNewPersonPDF()
        {
            string templateHTML = File.ReadAllText("resources/new-person.html");
            string generatedHTML = tokenizeHTML(templateHTML);

            htmlToPDF(generatedHTML);
        }

        private void htmlToPDF(string generatedHTML)
        {
            byte[] bytes;
            StringReader stringReader = new StringReader(generatedHTML);

            String FONT = "assets/fonts/arial.ttf";
            XMLWorkerFontProvider fontImp = new XMLWorkerFontProvider(XMLWorkerFontProvider.DONTLOOKFORFONTS);
            fontImp.Register(FONT);

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, stringReader);

                pdfDoc.Close();

                bytes = memoryStream.ToArray();
                memoryStream.Close();
            }

            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
            System.IO.File.WriteAllBytes(testFile, bytes);
        }

        private string tokenizeHTML(string htmlTemplate) {
            string generatedHTML = htmlTemplate.Replace($"#name#", Name)
                                            .Replace($"#age#", Age)
                                            .Replace($"#gender#", Gender);

            return generatedHTML;
        }
    }
}
