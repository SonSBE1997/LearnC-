using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Windows.Forms;

namespace ReadStory
{
    public partial class ReadFile : Form
    {
        public ReadFile(FileInfo file)
        {
            InitializeComponent();
            if (file.FullName.Contains(".pdf"))
                ReadFilePDF(file);
            if (file.FullName.Contains(".txt") || file.FullName.Contains(".doc"))
                ReadFileTextDocument(file);
        }

        void ReadFileTextDocument(FileInfo file)
        {
            StreamReader reader = new StreamReader(file.FullName, Encoding.UTF8);
            try
            {
                string temp = "";
                while ((temp = reader.ReadLine()) != null)
                {
                    temp += "\r\n";
                    richTextBox1.Text += temp;
                }
            }
            catch { }
        }


        void ReadFilePDF(FileInfo file)
        {
            StringBuilder content = new StringBuilder();
            PdfReader pdfReader = new PdfReader(file.FullName);

            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
            {
                content.Append(PdfTextExtractor.GetTextFromPage(pdfReader, i));
            }
            pdfReader.Close();
            string[] result =Regex.Split(content.ToString(),"   ");
            richTextBox1.Text = string.Join("\r\n", result);
        }

    }
}
