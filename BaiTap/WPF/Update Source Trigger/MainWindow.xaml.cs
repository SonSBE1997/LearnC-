using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Update_Source_Trigger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private string dataName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DataName
        {
            get
            {
                return dataName;
            }

            set
            {
                dataName = value;
                OnPropertyChanged("DataName");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataName = "Listen and Feeling";
            this.DataContext = this;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
