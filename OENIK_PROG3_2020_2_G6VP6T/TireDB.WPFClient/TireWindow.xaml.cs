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
using TireDB.WPFClient.ViewModels;

namespace TireDB.WPFClient
{
    /// <summary>
    /// Interaction logic for TireWindow.xaml
    /// </summary>
    public partial class TireWindow : Window
    {
        public TireWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
