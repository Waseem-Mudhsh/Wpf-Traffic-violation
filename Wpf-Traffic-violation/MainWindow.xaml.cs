using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //IUnityContainer _container;

        //readonly ViolationInterface _userServices;
        public MainWindow()
        {
            InitializeComponent();
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
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
