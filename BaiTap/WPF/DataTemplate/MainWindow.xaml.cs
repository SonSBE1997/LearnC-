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

namespace DataTemplate
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn1.DataContext = "ảnh 1";
            btn2.DataContext = "ảnh 2";

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btn3.Content = "ảnh 3";
            btn4.Content = "ảnh 4";
            btn5.Content = new SourceButton() {Content="ảnh 5" ,ImageSource = "file:///D:/ảnh/[SIEU HOT] CUTE GIRLS 2/Cute Girls P2 (765).jpg" };
            btn6.Content = new SourceButton() { Content = "ảnh 6", ImageSource = "file:///D:/ảnh/[SIEU HOT] CUTE GIRLS 2/Cute Girls P2 (78).jpg" };
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            btn4.Content = "Change content success";
        }
    }

    class SourceButton
    {
        public string Content { get; set; }
        public string ImageSource { get; set; }
    }
}