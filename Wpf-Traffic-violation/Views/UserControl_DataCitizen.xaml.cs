using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_DataCitizen.xaml
    /// </summary>
    public partial class UserControl_DataCitizen : UserControl
    {
        
        public UserControl_DataCitizen()
        {
            InitializeComponent();
        }

        private void But_Add_Citizen_Click(object sender, RoutedEventArgs e)
        {
            //نرسل الصفحة الي نشتي نعرضه داخل الويندو في حال أستخدمنا الفريم
            //Window_AddCitizen window = new Window_AddCitizen(new UserControl_AddCitizen());
            Window_AddCitizen window = new Window_AddCitizen();
           

            window.ShowDialog();
              
        }

       

        private void But_Excel_Citizen_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
