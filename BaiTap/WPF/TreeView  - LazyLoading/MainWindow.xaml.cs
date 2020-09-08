using System;
using System.Collections.Generic;
using System.IO;
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

namespace TreeView____LazyLoading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DriveInfo []driveInfo = DriveInfo.GetDrives();
            foreach (DriveInfo item in driveInfo)
            {
                trvMain.Items.Add(CreateTreeItem(item));

            }
        }


        private void trvMain_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            if (item.Items.Count == 1 && item.Items[0] is String) item.Items.Clear();
            DirectoryInfo directoryExplorer = null;
            if (item.Tag is DriveInfo) directoryExplorer = (item.Tag as DriveInfo).RootDirectory;
            if (item.Tag is DirectoryInfo) directoryExplorer = item.Tag as DirectoryInfo;
            try
            {
                foreach (DirectoryInfo directory in directoryExplorer.GetDirectories())
                {
                    item.Items.Add(CreateTreeItem(directory));
                }
            }
            catch { }
        }

        public TreeViewItem CreateTreeItem(object o)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = o.ToString();
            item.Tag = o;
            item.Items.Add("Adding...");
            return item;
        }
    }
}
