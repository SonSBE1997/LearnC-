using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TreeView___Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initDataTreeViewUser();
            initDataTreeViewFamily();
        }

        private void initDataTreeViewUser()
        {
            User root = new User() { Name = "Root"};
            root.ListUsers.Add(new User() { Name = "Child 1.", ListUsers = { new User() { Name = "Child 1.1" }, new User() { Name = "Child 1.2" } } });
            root.ListUsers.Add(new User() { Name = "Child 2." });

            trvUser.Items.Add(root);
        }

        private void initDataTreeViewFamily()
        {
            Family family1 = new Family() { Name = "Family 1"};
            family1.Members.Add(new FamilyMember() { Name = "Vũ Kim Thoa" ,Age = 28});
            family1.Members.Add(new FamilyMember() { Name = "Trần Tuấn Kiệt", Age = 30 });
            family1.Members.Add(new FamilyMember() { Name = "Trần Ngọc Như", Age = 7 });

            Family family2 = new Family() { Name = "Family 2" };
            family2.Members.Add(new FamilyMember() { Name = "Lê Văn Đức", Age = 57 });
            family2.Members.Add(new FamilyMember() { Name = "Đặng Ngọc Yến", Age = 54 });
            family2.Members.Add(new FamilyMember() { Name = "Nguyễn Ngọc Oanh", Age = 29 });
            family2.Members.Add(new FamilyMember() { Name = "Lê Văn Huy", Age = 29 });
            family2.Members.Add(new FamilyMember() { Name = "Lê Thùy Dương", Age = 3 });

            trvFamily.Items.Add(family1);
            trvFamily.Items.Add(family2);
        }
    }

    public class User
    {
        public string Name { get; set; }

        public ObservableCollection<User> ListUsers { get; set; }

        public User()
        {
            ListUsers = new ObservableCollection<User>();
        }
    }

    class Family
    {
        public string Name { get; set; }

        public ObservableCollection<FamilyMember> Members { get; set; }

        public Family()
        {
            Members = new ObservableCollection<FamilyMember>();
        }
    }

    class FamilyMember
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
