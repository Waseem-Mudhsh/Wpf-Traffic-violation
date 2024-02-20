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
using Unity;
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //IUnityContainer _container;

        //readonly ViolationInterface _userServices;
        public MainWindow( )
        {
            InitializeComponent();

          //base.DataContext= unityContainer;
        }
        private void SwitchScreen(UserControl Screen)
        {

        }

        private void UserControl_Login_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
