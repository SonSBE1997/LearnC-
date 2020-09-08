using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai10
{
    public partial class Form1 : Form
    {
        string country;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        void EmptyOption()
        {
            rbtnTokyo.Checked = false;
            rbtnLondon.Checked = false;
            rbtnWashingtonDC.Checked = false;
            rbtnParis.Checked = false;
            rbtnRome.Checked = false;
        }

        private void rbntEngland_CheckedChanged(object sender, EventArgs e)
        {
            SelectCountry("England");
        }

        private void rbtnFrance_CheckedChanged(object sender, EventArgs e)
        {
            SelectCountry("France");
        }

        private void rbtnJapan_CheckedChanged(object sender, EventArgs e)
        {
            SelectCountry("Japan");
        }

        private void rbtnUSA_CheckedChanged(object sender, EventArgs e)
        {
            SelectCountry("The USA");
        }

        private void rbtnItaly_CheckedChanged(object sender, EventArgs e)
        {
            SelectCountry("Italy");
        }

        private void rbtnTokyo_CheckedChanged(object sender, EventArgs e)
        {
            CheckCapitalOfCountry("Japan", "Tokyo");
        }

        private void rbtnLondon_CheckedChanged(object sender, EventArgs e)
        {
            CheckCapitalOfCountry("England", "London");
        }

        private void rbtnWashingtonDC_CheckedChanged(object sender, EventArgs e)
        {
            CheckCapitalOfCountry("The USA", "Washington DC");
        }

        private void rbtnParis_CheckedChanged(object sender, EventArgs e)
        {
            CheckCapitalOfCountry("France", "Paris");
        }

        private void rbtnRome_CheckedChanged(object sender, EventArgs e)
        {
            CheckCapitalOfCountry("Italy", "Rome");
        }

        void SelectCountry(string c)
        {
            country = c;
            label1.Text = "Hãy chọn thành phố cho " + country;
            EmptyOption();
        }

        void CheckCapitalOfCountry(string c, string city)
        {
            if (country == c) label1.Text = "Chúc mừng bạn, Thủ đô của " + country + " là " + city;
            else label1.Text = "Bạn sai rồi, Thủ đô của " + country + " không phải là " + city;
        }
    }
}
