﻿using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StringBuilder content = new StringBuilder();
                string file = openFileDialog1.FileName;
                using (PdfReader reader = new PdfReader(file))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        content.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                    richTextBox1.Text = content.ToString();
                }
            }
        }


    }
}
