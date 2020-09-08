using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossThread
{
    public partial class Form1 : Form
    {
        static string time = 3600.ToString();
        public Form1()
        {
            InitializeComponent();
        }


        #region xu ly cross thread

        void DoLongTask()
        {
            Thread.Sleep(5000);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    button1.Visible = false;
        //    ////C1: Sử dụng thread khác
        //    //Thread t = new Thread(() => {
        //    //    DoLongTask();
        //    //    Invoke(new Action(() => button1.Visible = true));
        //    //});
        //    //t.Start();

        //    ////C2:sử dụng backroundworker
        //    //BackgroundWorker bw = new BackgroundWorker();
        //    //bw.DoWork += (_s, _e) => DoLongTask();
        //    //bw.RunWorkerCompleted += (_s, _e) => button1.Visible = true;
        //    //bw.RunWorkerAsync();


        //    ////C3:
        //    //Task.Factory.StartNew(() => DoLongTask()).ContinueWith(prevTask => button1.Visible = true, TaskScheduler.FromCurrentSynchronizationContext());
        //}

        //private async void button1_Click(object sender, EventArgs e)
        //{
        //    button1.Visible = false;
        //    await Task.Factory.StartNew(() => DoLongTask());
        //    button1.Visible = true;
        //} 
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            if (GetTimeFromTextBox() == null)
            {
                MessageBox.Show("You don't input time start");
                return;
            }
            label1.Text = GetTimeFromTextBox();
            (sender as Button).Visible = false;
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            Thread t = new Thread(() => {
                time = label1.Text;
                Thread.Sleep(1000);
                Invoke(new Action(() => {
                    label1.Text = ChangeTime(time);
                }));
            });

            t.IsBackground = true;
            t.Start();
        }

        string ChangeTime(string time)
        {
            string[] result = time.Split(':');

            if (time == "0:00:00")
            {
                button1.Visible = true;
                return time;
            }

            int hour = Int32.Parse(result[0]);
            int minute = Int32.Parse(result[1]);
            int second = Int32.Parse(result[2]);

            second--;
            if (second == -1)
            {
                minute--;
                second = 59;
            }

            if (minute == -1)
            {
                hour--;
                minute = 59;
            }
            string temp = hour + ":";
            if (minute < 10) temp += "0" + minute + ":";
            else temp += minute + ":";
            if (second < 10) temp += "0" + second;
            else temp += second;

            return temp;
        }

        string GetTimeFromTextBox()
        {
            int second;
            if (Int32.TryParse(textBox1.Text, out second))
            {
                int hour = 0;
                int minute = 0;
                if (second < 60) return "0:0:" + second;
                minute = second / 60;
                second -= minute * 60;
                if (minute < 60) return "0:" + minute + ":" + second;
                hour = minute / 60;
                minute -= hour * 60;
                return hour + ":" + minute + ":" + second;
            }
            return null;
        }
    }
}