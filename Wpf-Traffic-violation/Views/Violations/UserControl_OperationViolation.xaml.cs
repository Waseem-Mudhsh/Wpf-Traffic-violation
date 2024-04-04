using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_OperationViolation.xaml
    /// </summary>
    public partial class UserControl_OperationViolation : UserControl
    {
        public UserControl_OperationViolation()
        {
            InitializeComponent();
            Window MainWindow = System.Windows.Application.Current.MainWindow;
            PresentationSource MainWindowPresentationSource = PresentationSource.FromVisual(MainWindow);
            Matrix m = MainWindowPresentationSource.CompositionTarget.TransformToDevice;
            var DpiWidthFactor = m.M11;
            var DpiHeightFactor = m.M22;
            double ScreenHeight = SystemParameters.PrimaryScreenHeight * DpiHeightFactor;
            double ScreenWidth = SystemParameters.PrimaryScreenWidth * DpiWidthFactor;
            this.trkSetWidthAdjust.Width = ScreenWidth - 240;//assigning the width for the panel
            this.TrkAnalysisDataGrid.Height = ScreenHeight - 160;//assigning the Height for the DataGrid

        }

        private void But_Add_Violation_Click(object sender, RoutedEventArgs e)
        {
            Window_AddViolation win = new Window_AddViolation();
            win.ShowDialog();
        }


        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var item = checkBox.DataContext; // This gives you the item bound to the row
                                                 // Do something with the item...
            }

        }



    }
}
