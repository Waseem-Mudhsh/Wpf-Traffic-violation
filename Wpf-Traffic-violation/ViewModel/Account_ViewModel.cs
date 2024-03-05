using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    public class Account_ViewModel : BindableBase
    {

        #region Objects And Variables
        AccountModel AccountModel = new AccountModel();
        Window_AddAccont win;
        ActivityModel ActivityModel = new ActivityModel();
        PermissionUser PermissionUser;
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

        ObservableCollection<Account> grid_Account;
        public ObservableCollection<Account> Grid_Accounts //يربط مع الجرد فيو 
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
                    RaisePropertyChanged("Grid_Accounts");
                }
            }
        }

        Account currunt_Account; //selectedItemيربط مع 

        public Account Currunt_Account
        {
            get
            {
                return currunt_Account;
            }
            set
            {
                if (currunt_Account != value)
                {
                    currunt_Account = value;
                    RaisePropertyChanged("Currunt_Account");
                }
            }
        }


        ObservableCollection<Account> grid_AccountParent;
        public ObservableCollection<Account> Grid_AccountParent//يربط مع الجرد فيو 
        {
            get
            {
                return grid_AccountParent;
            }
            set
            {
                if (grid_AccountParent != value)
                {
                    grid_AccountParent = value;
                    RaisePropertyChanged("Grid_AccountParent");
                }
            }
        }

        Account selected_Parent; //selectedItemيربط مع 

        public Account Selected_Parent
        {
            get
            {
                return selected_Parent;
            }
            set
            {
                if (selected_Parent != value)
                {
                    selected_Parent = value;
                    Currunt_Account.Account_parent = Selected_Parent.Account_id;
                    Currunt_Account.Account_id = AccountModel.GetCreate_Account(Selected_Parent.Account_id);
                    Currunt_Account.String_AccParent = Selected_Parent.Account_name;
                    RaisePropertyChanged("Selected_Parent");
                }
            }
        }
        #endregion
        #region Construcor
        public Account_ViewModel()
        {

            asyncAccounts();





            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();



            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
        private async Task asyncAccounts()
        {
            Grid_Accounts = new ObservableCollection<Account>();
            Grid_Accounts = await Task.Run(() => AccountModel.GetAccounts());

            Grid_AccountParent = new ObservableCollection<Account>();
            Grid_AccountParent = await Task.Run(() => AccountModel.GetAccountParent());
        }
        public void Add()
        {

            Grid_AccountParent = new ObservableCollection<Account>();
            Grid_AccountParent = AccountModel.GetAccountParent();

            Currunt_Account = new Account();
            Selected_Parent = new Account();

            win = new Window_AddAccont { DataContext = this };
            win.ShowDialog();
        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {

            Grid_AccountParent = new ObservableCollection<Account>();
            Grid_AccountParent = AccountModel.GetAccountParent();
            IsEditing = true;
            win = new Window_AddAccont { DataContext = this };
            win.acc_id.IsEnabled = false;
            win.acc_order.IsEnabled = false;
            win.acc_typ.IsEnabled = false;
            //win.acc_parent.Text = Currunt_Account.Account_parent.ToString();
            //win.acc_parentName.Text = Currunt_Account.String_AccParent;
            if (Currunt_Account.Account_type == 1)
                win.co1.IsSelected = true;
            else if (Currunt_Account.Account_type == 2)
                win.co2.IsSelected = true;

            win.ShowDialog();

        }
        bool CanEdit() => Currunt_Account != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                //////////////////////////////////////////////////////////////
                if (!AccountModel.Check_Parint(Currunt_Account.Account_parent))
                {
                    Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                    Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                    Current_Activity.User_id = Properties.Settings.Default.Userid;
                    Current_Activity.Form_id = 11;
                    Current_Activity.Activity_record_num = Currunt_Account.Account_id;

                    //////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////
                    Current_Activity.Activity_operation_num = 3;
                    ActivityModel.OperarionActivity(current_Activity, "Insert");
                    ////////////////////////////////////////////////////////////
                    if (AccountModel.OperarionAccount(Currunt_Account, "Delete"))
                    {
                        Grid_Accounts.Remove(Currunt_Account);
                        asyncAccounts();
                        string message1 = "تمت عملية الحذف بنجاح";
                        string caption1 = "عملية الحذف";
                        MessageBoxImage icon1 = MessageBoxImage.Information;
                        MessageBoxButton buttons1 = MessageBoxButton.OK;
                        MessageBox.Show(message1, caption1, buttons1, icon1);
                    }
                    else
                    {
                        string message1 = "يوجد سجلات مرتبطة بهذا الحساب";
                        string caption1 = "تأكيد";
                        MessageBoxButton buttons1 = MessageBoxButton.OK;

                        MessageBoxImage icon1 = MessageBoxImage.Error;


                        MessageBox.Show(message1, caption1, buttons1, icon1);
                    }
                }
                else
                {
                    string message1 = "يوجد حسابات مرتبطة بهذا الحساب";
                    string caption1 = "تأكيد";
                    MessageBoxButton buttons1 = MessageBoxButton.OK;

                    MessageBoxImage icon1 = MessageBoxImage.Error;


                    MessageBox.Show(message1, caption1, buttons1, icon1);
                }

            }
            else
            {
                return;
            }
        }
        bool CanDelet() => Currunt_Account != null && PermissionUser.Delete_opretion == true;
        void Save()
        {
            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;

            Current_Activity.Form_id = 12;
            Current_Activity.Activity_record_num = Currunt_Account.Account_id;

            //////////////////////////////////////////////////////////





            if (win.co1.IsSelected == true)
                Currunt_Account.Account_type = 1;
            else if (win.co2.IsSelected == true)
                Currunt_Account.Account_type = 2;


            if (IsEditing && AccountModel.Check_Exsit(Currunt_Account.Account_id))
            {

                AccountModel.OperarionAccount(Currunt_Account, "Update");
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
            else if (AccountModel.Check_Exsit(Currunt_Account.Account_id))
            {

                Currunt_Account.Account_status = true;
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);


            }

            else
            {
                Currunt_Account.Account_date = DateTime.Now.Date.ToShortDateString();
                AccountModel.OperarionAccount(Currunt_Account, "Insert");
                Grid_Accounts.Add(Currunt_Account);
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


            Grid_Accounts = AccountModel.GetAccounts();


            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_Account != null && !Currunt_Account.HasErrors;
        void close()
        {
            Currunt_Account = null;
            win.Close();
        }
        void GetExcel()
        {
            // Currunt_Account = new Account();
            AccountModel.GetExcel(Grid_Accounts);
            Grid_Accounts = new ObservableCollection<Account>();
            Grid_Accounts = AccountModel.GetAccounts();

        }


        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; private set; }
        public RelayCommand Excelcommand { get; private set; }
        #endregion










        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
