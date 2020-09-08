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

namespace Command___Implementing
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

        #region region2
        //private void CutCommand_Excuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    txtParagraph.Cut();
        //}

        //private void CutCommand_CanExcute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = (txtParagraph != null) && (txtParagraph.SelectionLength > 0);
        //}


        //private void PasteCommand_Excuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    txtParagraph.Paste();
        //}

        //private void PasteCommand_CanExcute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = Clipboard.ContainsText();
        //}
        #endregion

        #region region1
        //private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    MessageBox.Show("New command can excute");
        //} 
        #endregion

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.F4, ModifierKeys.Alt) });

        public static readonly RoutedUICommand Save = new RoutedUICommand("Save", "Save", typeof(CustomCommands),
           new InputGestureCollection() { new KeyGesture(Key.S, ModifierKeys.Control) });
    }
}
