using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    public class ReceiptViewModel : BindableBase
    {
        
        #region Objects And Variables
        ReceiptModel ReceiptModel = new ReceiptModel();
        AccountModel AccountModel = new AccountModel();
        ActivityModel ActivityModel = new ActivityModel();
        PermissionUser PermissionUser;
        Window_AddReceipt win;
        #endregion
        #region Proprties
        Activity current_Activity;
        public Activity Current_Activity
        {
            get
            {
                return current_Activity;
            }
            set
            {
                if (current_Activity != value)
                {
                    current_Activity = value;
                    RaisePropertyChanged("Current_Activity");
                }
            }
        }

        
         ObservableCollection<Receipt> grid_Receipt;
        public ObservableCollection<Receipt> Grid_Receipt
        {
            get
            {
                return grid_Receipt;
            }
            set
            {
                if (grid_Receipt != value)
                {
                    grid_Receipt = value;
                    RaisePropertyChanged("Grid_Receipt");
                }
            }
        }

        ObservableCollection<Account> grid_Account;
        public ObservableCollection<Account> Grid_Account
        {
            get
            {
                return grid_Account;
            }
            set
            {
                if (grid_Account != value)
                {
                    grid_Account = value;
                    RaisePropertyChanged("Grid_Account");
                }
            }
        }

        Receipt current_Receipt;
        public Receipt Current_Receipt
        {
            get
            {
                return current_Receipt;
            }
            set
            {
                if (current_Receipt != value)
                {
                    current_Receipt = value;
                    RaisePropertyChanged("Current_Receipt");
                }
            }
        }

        Account selected_Account;
        public Account Selected_Account
        {
            get
            {
                return selected_Account;
            }
            set
            {
                if (selected_Account != value)
                {
                    selected_Account = value;
                    RaisePropertyChanged("Selected_Account");
                }
            }
        }



        #endregion
        #region Construcor
        public ReceiptViewModel()
        {
            asyncReceipt();
           

            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 15;
           

            Current_Activity = new Activity();


        }
        #endregion
        #region Methodes And Events
        async Task asyncReceipt()
        {
            Grid_Receipt = new ObservableCollection<Receipt>();
            Grid_Receipt= await Task.Run(() => ReceiptModel.GetReceipts());

            Grid_Account = new ObservableCollection<Account>();
            Grid_Account = await Task.Run(() => AccountModel.GetAccounts());
        }
        public void Add()
        {
            int maxId = new Class_SqlConnection().Get_Max("Receipt");


            Current_Receipt = new Receipt { Receipt_id = maxId };
            
            win = new Window_AddReceipt { DataContext = this };
            win.ShowDialog();
        }
        bool CanAdd() => true;//&& PermissionUser.Add_opretion == true;

        void Edit()
        {
            IsEditing = true;

            foreach (Account a in Grid_Account)
            {
                
                if (a.Account_id == Current_Receipt.Account_id)
                    Selected_Account = a;
            }


            win = new Window_AddReceipt { DataContext = this };
            win.ShowDialog();
        }
        bool CanEdit() => true;
            //Current_Receipt != null && PermissionUser.Update_opretion == true;

        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
               
                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 15;
                Current_Activity.Activity_record_num = Current_Receipt.Receipt_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

                ReceiptModel.OperarionReceipt(Current_Receipt, "Delete");

                Grid_Receipt.Clear();
                Grid_Receipt= ReceiptModel.GetReceipts();

                string message1 = "تمت عملية الحذف بنجاح";
                string caption1 = "عملية الحذف";
                MessageBoxImage icon1 = MessageBoxImage.Information;
                MessageBoxButton buttons1 = MessageBoxButton.OK;
                MessageBox.Show(message1, caption1, buttons1, icon1);


            }
            else
            {
                return;
            }
        }
        bool CanDelet() => Current_Receipt != null && PermissionUser.Delete_opretion == true;

        void Save()
        {
            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;

            Current_Activity.Form_id = 15;
            Current_Activity.Activity_record_num = Current_Receipt.Receipt_id;
           
            //////////////////////////////////////////////////////////

            Current_Receipt.Account_id = Selected_Account.Account_id;

            Current_Receipt.Receipt_status = false;
            Current_Receipt.Post_date = "-";
            if (IsEditing && ReceiptModel.Check_Exsit(Current_Receipt.Receipt_id))
            {

                ReceiptModel.OperarionReceipt(Current_Receipt,"Update");
                IsEditing = false;
                close();
                string message = "تمت عملية التعديل بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 2;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

            }
            else if (ReceiptModel.Check_Exsit(Current_Receipt.Receipt_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
            }
            else
            {
                ReceiptModel.OperarionReceipt(Current_Receipt, "Insert");

                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية الإضافة";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 1;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

            }

            Grid_Receipt.Clear();
            Grid_Receipt=ReceiptModel.GetReceipts();


            //Enable_Grid = false;
        }
        bool CanSave() => Current_Receipt != null && !Current_Receipt.HasErrors;

        void close()
        {
            Current_Receipt = null;
            win.Close();
        }

        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; private set; }
       
        #endregion



        
        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
