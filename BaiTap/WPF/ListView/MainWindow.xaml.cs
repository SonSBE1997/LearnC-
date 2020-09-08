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

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Liv> list;
        List<Employee> list1;
        public MainWindow()
        {
            InitializeComponent();
            AddSourceListView1();
            AddSourceListView2();
        }
        private void AddSourceListView1()
        {
            list = new List<Liv>();
            list.Add(new Liv() { Content = "Click here", Text = "C#" });
            list.Add(new Liv() { Content = "Click here", Text = "HTML5 / CSS3" });
            list.Add(new Liv() { Content = "Click here", Text = "JS" });
            list.Add(new Liv() { Content = "Click here", Text = "Java" });
            li.ItemsSource = list;

        }

        private void AddSourceListView2()
        {
            list1 = new List<Employee>() {
                new Employee() {Name = "Nguyễn Văn Tú" , Age= 27,Email="tu12@gmail.com"  ,Province="Hải Dương" ,Sex  =SexType.Male , Text = "C++"},
                new Employee() {Name = "Vũ Minh Tuấn" , Age= 22,Email="TuanVu@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.Male},
                new Employee() {Name = "Vũ Ngọc Anh" , Age= 23,Email="NgocAnh@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.FeMale},
                new Employee() {Name = "Lưu Thu Thủy" , Age= 21,Email="ThuThuy@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.FeMale},
                new Employee() {Name = "Trần Thùy Trang" , Age= 22,Email="Trang@gmail.com"  ,Province="Hải Phòng" ,Sex  =SexType.FeMale},
                new Employee() {Name = "Vương Trí Kiệt" , Age= 26,Email="KietVT@gmail.com"  ,Province="Vình Phúc" ,Sex  =SexType.Male}
            };
            li1.ItemsSource = list1;


            li2.ItemsSource = list1;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(li2.ItemsSource);
            PropertyGroupDescription description = new PropertyGroupDescription("Sex");
            view.GroupDescriptions.Add(description);
        }
    }

    class Liv
    {
        public string Content { get; set; }
        public string Text { get; set; }
    }

    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public SexType Sex { get; set; }
        public string Text { get; set; }
    }

    enum SexType { Male, FeMale }
}