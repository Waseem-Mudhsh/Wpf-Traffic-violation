using Microsoft.Win32;
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

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_BackUp.xaml
    /// </summary>
    public partial class UserControl_BackUp : UserControl
    {
        public UserControl_BackUp()
        {
            InitializeComponent();
        }

        private void but_OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == true)
            {
                string sFileName = choofdlog.FileName;
                text_OpenFolder.Text = sFileName;
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }

        }
    }
}
