using Microsoft.Win32;
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

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for Window_AddDataSystem.xaml
    /// </summary>
    public partial class Window_AddDataSystem : Window
    {
        public Window_AddDataSystem()
        {
            InitializeComponent();
        }

        private void but_SelectLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                logo.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void But_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
