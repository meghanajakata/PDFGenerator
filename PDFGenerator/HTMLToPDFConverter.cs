using Razor.Templating.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace PDFGenerator
{
    public  class HTMLToPDFGenerator
    {
        public static byte[] GeneratePDF(string stringData)
        {
            Document document = new Document();
            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance(document, stream);
                document.Open();
                HTMLWorker hTMLWorker = new HTMLWorker(document);
                StringReader stringReader = new StringReader(stringData);
                hTMLWorker.Parse(stringReader);
                document.Close();
                return stream.ToArray();
            }
        }
    }
}
