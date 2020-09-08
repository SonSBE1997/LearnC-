using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionarySpeaking
{
    public partial class Form1 : Form
    {
        //
        DictionaryManager manager;
        SpeakText English;
        SpeakText VietNam;
        bool isLoading1 = true;
        bool isLoading2 = true;


        public Form1()
        {
            InitializeComponent();
            ChangeLoad();

            WebBrowser browserVietNam = new WebBrowser();
            browserVietNam.Width = 0;
            browserVietNam.Height = 0;
            browserVietNam.Visible = false;
            browserVietNam.ScriptErrorsSuppressed = true;
            browserVietNam.Navigate(Cons.VietNamLink);
            browserVietNam.DocumentCompleted += BrowserVietNam_DocumentCompleted;


            WebBrowser browserEnglish = new WebBrowser();
            browserEnglish.Width = 0;
            browserEnglish.Height = 0;
            browserEnglish.Visible = false;
            browserEnglish.ScriptErrorsSuppressed = true;
            browserEnglish.Navigate(Cons.EnglishLink);
            browserEnglish.DocumentCompleted += BrowserEnglish_DocumentCompleted;

            this.Controls.Add(browserVietNam);
            this.Controls.Add(browserEnglish);

            English = new SpeakText(browserEnglish);
            VietNam = new SpeakText(browserVietNam);


            manager = new DictionaryManager();
            manager.LoadDataToComboBox(cbListWord);
            cbListWord.DisplayMember = "Key";
        }

        private void BrowserEnglish_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isLoading2 = false;
            ChangeLoad();
        }

        private void BrowserVietNam_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isLoading1 = false;
            ChangeLoad();
        }

        void ChangeLoad()
        {
            this.Enabled = !(isLoading2 && isLoading1);
        }

        //
        private void cbListWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListWord.DataSource == null) return;
            DictionaryData data = cbListWord.SelectedItem as DictionaryData;
            txbMeaning.Text = data.Meaning;
            txbExplaination.Text = data.Explaination;
        }

        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            //manager.Serialize();
        }

        //
        private void btnSpeakEnglish_Click(object sender, EventArgs e)
        {
            DictionaryData data = cbListWord.SelectedItem as DictionaryData;
            English.Speak(data.Key);
        }

        //
        private void btnSpeakVN_Click(object sender, EventArgs e)
        {
            DictionaryData data = cbListWord.SelectedItem as DictionaryData;
            VietNam.Speak(data.Meaning);
        }

        //
        private void btnSpeak_Click(object sender, EventArgs e)
        {
            DictionaryData data = cbListWord.SelectedItem as DictionaryData;
            VietNam.Speak(data.Explaination);
        }
    }
}
