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
using TireDB.WPFClient.Windows;

namespace TireDB.WPFClient
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void TireClick(object sender, RoutedEventArgs e)
        {
            TireWindow tireWindow = new TireWindow();
            tireWindow.Show();
        }
        private void TireSpecClick(object sender, RoutedEventArgs e)
        {
            TireSpecWindow tireSpecWindow = new TireSpecWindow();
            tireSpecWindow.Show();
        }
        private void BrandClick(object sender, RoutedEventArgs e)
        {
            BrandWndow brandWndow = new BrandWndow();
            brandWndow.Show();
        }

        private void StatClick(object sender, RoutedEventArgs e)
        {
            StatWindow statWindow= new StatWindow();
            statWindow.Show();
        }
    }
}
