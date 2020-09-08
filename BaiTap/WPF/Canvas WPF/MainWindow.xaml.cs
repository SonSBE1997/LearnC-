using System;
using System.Collections.Generic;
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

namespace Canvas_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas.SetZIndex(btn1, 1);
            Canvas.SetZIndex(btn2, 2);
        }

        private void btn2_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas.SetZIndex(btn1, 3);
            Canvas.SetZIndex(btn2, 2);
        }
    }
}
