using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace FilePDFDemo
{
    public class CreatePdfFile
    {
        private static CreatePdfFile instance;

        public static CreatePdfFile Instance
        {
            get
            {
                if (instance == null)
                    instance = new CreatePdfFile();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CreatePdfFile() { }

        public void Create(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            Document document = new Document(PageSize.A4, 72, 36, 36, 36);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);
            document.AddLanguage("Vietnamese");
            document.AddTitle("Demo pdf file");
            document.AddCreator("SBE");
            document.Open();
            //đăng ký font có trong windows
            #region GetFontNameInWindowFonts
            //var totalFont = FontFactory.RegisterDirectory(@"C:\Windows\Fonts");
            //StringBuilder sb = new StringBuilder();
            //foreach (var item in FontFactory.RegisteredFonts)
            //{
            //    sb.Append(item + "\n");
            //}
            #endregion

            string paragraph = "This is pdf file! The PDF file has Vietnamese Language\nTiếng việt trong tệp tin pdf\nTrong tệp tin có chứa nhiều thứ: list và image";

            BaseFont baseFont = BaseFont.CreateFont(@"VietFont\vuArial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(baseFont, 13, Font.NORMAL, BaseColor.MAGENTA);
            document.Add(new Paragraph(paragraph, font));


            //list in pdf file
            #region List
            RomanList romanList = new RomanList(true, 20);
            romanList.IndentationLeft = 10f;
            romanList.Add("one");
            romanList.Add("two");
            romanList.Add("three");
            romanList.Add("four");
            romanList.Add("five");


            List list = new List(List.ORDERED, 20f);
            list.IndentationLeft = 20f;
            list.SetListSymbol("\u2022"); // unicode symbol
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");
            list.Add("roman list:");
            list.Add(romanList);
            #endregion

            //insert image to pdf file
            Image img1 = Image.GetInstance(@"Resources/image1.jpg");
            Image img2 = Image.GetInstance(@"Resources/image2.jpg");

            //img1.ScalePercent(8f);
            //img1.SetAbsolutePosition(document.PageSize.Width - 300f, document.PageSize.Height - 200f);
            img1.ScaleToFit(300f, 300f);
            img1.Border = Rectangle.BOX;
            img1.BorderColor = BaseColor.GREEN;
            img1.BorderWidth = 5f;
            img2.ScalePercent(8f);

            document.Add(img1);
            document.Add(img2);

            document.Add(list);
            document.Close();
        }
    }
}
