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
using Wpf_Traffic_violation.Models;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        private List<KeyValuePair<string, int>> violationsTypeSelected;
        private Receipt current_Receipt;

        public ReceiptWindow(Receipt receipt)
        {
            InitializeComponent();
            //txtCustomerName.Text = receipt.CustomerName;
            //txtTransactionDate.Text = receipt.TransactionDate.ToString("yyyy-MM-dd");
            //txtAmount.Text = receipt.Amount.ToString("C");
        }

        public ReceiptWindow(List<KeyValuePair<string, int>> violationsTypeSelected, Receipt current_Receipt)
        {
            this.violationsTypeSelected = violationsTypeSelected;
            this.current_Receipt = current_Receipt;
        }
    }
}
