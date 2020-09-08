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

namespace ListView___Sort_Filter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> listEmployee;
        List<Employee> listEmployee2;
        List<Employee> listEmployee3;
        bool isSort;
        bool isSort2;

        public MainWindow()
        {
            InitializeComponent();
            isSort = false;
            isSort2 = false;
            initEmployee();
        }

        private void initEmployee()
        {
            listEmployee = new List<Employee>() {
                new Employee() {Name = "Nguyễn Văn Tú" , Age= 27,Email="tu12@gmail.com"  ,Province="Hải Dương" ,Sex  =SexType.Male},
                new Employee() {Name = "Vũ Minh Tuấn" , Age= 22,Email="TuanVu@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.Male},
                new Employee() {Name = "Vũ Ngọc Anh" , Age= 23,Email="NgocAnh@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.FeMale},
                new Employee() {Name = "Lưu Thu Thủy" , Age= 21,Email="ThuThuy@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.FeMale},
                new Employee() {Name = "Trần Thùy Trang" , Age= 22,Email="Trang@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.FeMale},
                new Employee() {Name = "Vương Trí Kiệt" , Age= 26,Email="KietVT@gmail.com"  ,Province="Vình Phúc" ,Sex  =SexType.Male}
            };
            listEmployee2 = new List<Employee>();
            listEmployee3 = new List<Employee>();
            foreach (Employee item in listEmployee)
            {
                listEmployee2.Add(item);
                listEmployee3.Add(item);
            }
            livEmployee.ItemsSource = listEmployee;
            livEmployee2.ItemsSource = listEmployee2;
            listView.ItemsSource = listEmployee3;
            //Filter
            CollectionView viewFilter = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            viewFilter.Filter = UserFilter;
            //group
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(livEmployee2.ItemsSource);
            view.GroupDescriptions.Add(new PropertyGroupDescription("Sex"));
        }

        private bool UserFilter(object obj)
        {
            if (String.IsNullOrEmpty(obj.ToString())) return true;
            return (obj as Employee).Name.IndexOf(txbFilter.Text, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(livEmployee.ItemsSource);
            view.SortDescriptions.Clear();
            if (isSort)
            {
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription(header.Content.ToString(), System.ComponentModel.ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription(header.Content.ToString(), System.ComponentModel.ListSortDirection.Descending));
            }
            isSort = !isSort;
        }

        private void GridViewColumnHeader_Click_1(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(livEmployee2.ItemsSource);
            view.SortDescriptions.Clear();
            if (isSort2)
            {
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription(header.Content.ToString(), System.ComponentModel.ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription(header.Content.ToString(), System.ComponentModel.ListSortDirection.Descending));
            }
            isSort2 = !isSort2;

        }

        private void txbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }

        private void txbFilter_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox txb = sender as TextBox;
            txb.Text = "";
            txb.FontStyle = FontStyles.Normal;

        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas.SetZIndex(txbFilter,0);
            Canvas.SetZIndex((sender as TextBlock), 1);
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public SexType Sex { get; set; }
    }

    enum SexType { Male, FeMale }
}
