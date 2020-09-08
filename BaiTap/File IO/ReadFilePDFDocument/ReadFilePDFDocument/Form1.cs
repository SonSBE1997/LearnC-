using System;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ReadFilePDFDocument
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            txtFile.Text = openFile.FileName;
            rtxbContent.Clear();

            StringBuilder text = new StringBuilder();
            PdfReader reader = new PdfReader(openFile.FileName);
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string line = PdfTextExtractor.GetTextFromPage(reader, i, strategy);
                //line = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(line)));
                text.Append(line);
            }

            rtxbContent.Text = text.ToString();
            reader.Close();

        }
    }
}
