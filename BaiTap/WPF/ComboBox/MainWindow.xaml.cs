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

namespace ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Food> listItemComboBox;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listItemComboBox = new List<Food>() {
                new Food("Milk",10000),
                new Food("Cocacola",8000),
                new Food("C2",7000)
            };
            cb2.ItemsSource = listItemComboBox;
            //cb2.DisplayMemberPath = "Name";
            cb2.SelectedValuePath = "Price";
            cb2.SelectionChanged += Cb2_SelectionChanged;


            cb3.ItemsSource = typeof(Colors).GetProperties();
        }

        private void Cb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(cb2.SelectedValue.ToString());
        }

        class Food
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public Food(string name, int price)
            {
                this.Name = name;
                this.Price = price;
            }
        }
    }
}
