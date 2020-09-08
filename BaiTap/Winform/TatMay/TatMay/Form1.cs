using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatMay
{
    public partial class Form1 : Form
    {

        decimal timeToShutDown;
        StatusBar status = new StatusBar();
        StatusBarPanel dowmTimePanel = new StatusBarPanel();
        StatusBarPanel infoBarPanel = new StatusBarPanel();
        public Form1()
        {
            InitializeComponent();
            numHour.Value = 1;
            this.Controls.Add(status);
            createStatusBar();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numSecond.Value >= 60)
            {
                numMin.Value++;
                numSecond.Value = 0;
            }
        }


        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            if (numMin.Value >= 60)
            {
                numHour.Value++;
                numMin.Value = 0;
            }
        }


        private void btnShutdown_Click(object sender, EventArgs e)
        {
            readTime();
            Shutdown(" -s -t " + timeToShutDown);
            infoBarPanel.Text = "Shutting down after";
            timer1.Start();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            readTime();
            Shutdown(" -r -t " + timeToShutDown);
            infoBarPanel.Text = "Restarting after";
            timer1.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Shutdown(" -a");
            infoBarPanel.Text = "Waiting....";
            dowmTimePanel.Text = "";
            timer1.Stop();
        }

        private void Shutdown(string command)
        {
            System.Diagnostics.Process.Start("shutdown", command);
        }

        private void readTime()
        {
            timeToShutDown = numHour.Value * 3600 + numMin.Value * 60 + numSecond.Value;
        }

        private void createStatusBar()
        {
            status.SizingGrip = false;
            status.ShowPanels = true;
            infoBarPanel.Text = "Waiting....";
            dowmTimePanel.Text = "";
            status.Panels.Add(infoBarPanel);
            status.Panels.Add(dowmTimePanel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeToShutDown--;
            int hour = 0, minute = 0, second = 0;

            second = (int)timeToShutDown;
            hour = (int)timeToShutDown / 3600;
            second = (int)(timeToShutDown - hour * 3600);
            minute = (int)second / 60;
            second -= minute * 60;

            dowmTimePanel.Text = hour.ToString() + " : " + minute.ToString() + " : " + second.ToString();
        }
    }
}
