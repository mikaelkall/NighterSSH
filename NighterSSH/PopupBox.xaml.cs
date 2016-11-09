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

namespace NighterSSH
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PopupBox : Window
    {
        public static DependencyProperty TextProperty = DependencyProperty.Register("pText", typeof(string), typeof(PopupBox), new PropertyMetadata("Hello world"));

        public string pText
        {
            get { return (string)GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public PopupBox()
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
            this.Close();
        }




        

    }
}
