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
using System.Windows.Shapes;
using System.Collections;
using System.Threading;

namespace NighterSSH
{
    /// <summary>
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class Console : Window
    {

        public Console()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

    }

    /// <summary>
    ///  This loads three view
    /// </summary>
    public class Init_TreeView
    {

        // This method that will be called when the thread is started
        public void TreeView()
        {
                      
        }
    }
}










