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

namespace Battleship.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void GoTN_Click(object sender, RoutedEventArgs e)
        {
            //Settings s1 = new Settings();
            //this.Content = s1;

            System.Console.WriteLine("---------------dans le mainWindows-----------");

            Homepage h1 = new Homepage();
             h1.Show();
           

        }
    }

}
