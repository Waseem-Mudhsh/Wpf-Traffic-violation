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
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation
{
    /// <summary>
    /// Interaction logic for ElementMenu.xaml
    /// </summary>
    public partial class ElementMenu : UserControl
    {
        public ElementMenu()
        {
            InitializeComponent();
             var menuRegister = new List<SubItem>();
            //UserControl user = new UserControl();
            //user = UserControlsubSetting.xaml;
            
            
            menuRegister.Add(new SubItem("المخالفات", new UserControlsubSetting()));
            //menuRegister.Add(new SubItem("الإعتراضات"));
            //menuRegister.Add(new SubItem("البلاغات"));
            //menuRegister.Add(new SubItem("الحسابات"));
            var item = new ItemMenu("التقارير", menuRegister, MaterialDesignThemes.Wpf.PackIconKind.Register);
            var menuAcconts = new List<SubItem>();
            menuAcconts.Add(new SubItem("المخالفات", new UserControlsubSetting()));
            //menuAcconts.Add(new SubItem("Customer"));
            //menuAcconts.Add(new SubItem("Providers"));
            //menuAcconts.Add(new SubItem("Employees"));
            //menuAcconts.Add(new SubItem("Products"));
            var item0 = new ItemMenu("الحسابات", menuAcconts, MaterialDesignThemes.Wpf.PackIconKind.Register);
            var menuSchedule = new List<SubItem>();

            menuSchedule.Add(new SubItem("إضافة بلاغ", new UserControlsubSetting()));
            menuSchedule.Add(new SubItem("فحص بلاغ", new UserControlsubSetting()));
            //menuSchedule.Add(new SubItem("Employees"));
            //menuSchedule.Add(new SubItem("Products"));
            var item1 = new ItemMenu("البلاغات", menuSchedule, MaterialDesignThemes.Wpf.PackIconKind.Schedule);
            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("إضافة أعتراض", new UserControlsubSetting()));
            menuReports.Add(new SubItem("فحص أعتراض", new UserControlsubSetting()));
            //menuReports.Add(new SubItem("Employees"));
            //menuReports.Add(new SubItem("Products"));
            var item2 = new ItemMenu("الإعتراضات", menuReports, MaterialDesignThemes.Wpf.PackIconKind.Report);
            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("إضافة مخالفة", new UserControlsubSetting()));
            menuExpenses.Add(new SubItem("أستعلام مخالفة", new UserControlsubSetting()));
            menuExpenses.Add(new SubItem("سداد مخالفة", new UserControlsubSetting()));
            menuExpenses.Add(new SubItem("حركة مخالفة", new UserControlsubSetting()));
            var item3 = new ItemMenu("المخالفات", menuExpenses, MaterialDesignThemes.Wpf.PackIconKind.ExpandAll);
            var menuFinancialr = new List<SubItem>();
            menuFinancialr.Add(new SubItem("التهئة", new UserControlsubSetting()));
            menuFinancialr.Add(new SubItem("المستخدمين", new UserControlsubSetting()));
            menuFinancialr.Add(new SubItem("الاقفالات", new UserControlsubSetting()));
            menuFinancialr.Add(new SubItem("الغاء الترحيل", new UserControlsubSetting()));
            menuFinancialr.Add(new SubItem("الاقفالات", new UserControlsubSetting()));
            menuFinancialr.Add(new SubItem("صيانة النظام", new UserControlsubSetting()));
            menuFinancialr.Add(new SubItem("تنبيهات النظام", new UserControlsubSetting()));
            menuFinancialr.Add(new SubItem("توقيعات التقارير", new UserControlsubSetting()));
            var item4 = new ItemMenu("الإعدادت", menuFinancialr, MaterialDesignThemes.Wpf.PackIconKind.Finance);
            var menuHome = new List<SubItem>();
          
            Menu.Children.Add(new UserControllMenuItem(item4,this));
            Menu.Children.Add(new UserControllMenuItem(item3,this));
            Menu.Children.Add(new UserControllMenuItem(item2,this));//Menu that name stackpanel
            Menu.Children.Add(new UserControllMenuItem(item1,this));
            Menu.Children.Add(new UserControllMenuItem(item0,this));
            Menu.Children.Add(new UserControllMenuItem(item,this));

            

        }
        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            StackPanelmain.Children.Clear();
            StackPanelmain.Children.Add(screen);

        }

        //public static UserControl xaml { get; internal set; }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void But_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
