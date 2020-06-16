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
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControllMenuItem.xaml
    /// </summary>
    public partial class UserControllMenuItem : UserControl
    {
        ElementMenu _constext;
        public UserControllMenuItem(ItemMenu itemMenu,ElementMenu constext)
        {
            InitializeComponent();
            _constext = constext;
            ExpanerMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;
            this.DataContext = itemMenu;
            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _constext.SwitchScreen(((SubItem)((ListBox)sender).SelectedItem).Screen);
        }
    }
}
