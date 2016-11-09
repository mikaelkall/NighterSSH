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
using System.ComponentModel;

namespace NighterSSH
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (username.Text.ToString().Length < 2 || ppassword.Password.ToString().Length < 2 || address.Text.ToString().Length < 2)
            {
                PopupBox PopupBox = new PopupBox();
                PopupBox.pText = "You must enter something \n          in the fields";
                PopupBox.Show();
                //this.Close();
                return;
            }

            MCSSH.Form1 F = new MCSSH.Form1(address.Text.ToString(),username.Text.ToString(),ppassword.Password.ToString());
            
            try
            {
                this.Visibility = System.Windows.Visibility.Hidden;
                F.ShowDialog();
                this.Close();
            }
            catch 
            {
                try
                {
                    this.Close();
                }
                catch { }
            }

       

    

        }
    }
}
