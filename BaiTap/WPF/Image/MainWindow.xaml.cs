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
using System.IO;

namespace Image
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            img.Source = img.Source.ToString() == "file:///D:/ảnh/[SIEU HOT] CUTE GIRLS 2/Cute Girls P2 (78).jpg" ? new BitmapImage(new Uri("D:\\ảnh\\[SIEU HOT] CUTE GIRLS 2\\Cute Girls P2 (765).jpg")) : new BitmapImage(new Uri("D:\\ảnh\\[SIEU HOT] CUTE GIRLS 2\\Cute Girls P2 (78).jpg"));
        }
    }
}
