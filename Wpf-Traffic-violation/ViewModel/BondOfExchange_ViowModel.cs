using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Account_Model;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    public class BondOfExchange_ViowModel : BindableBase
    {

        #region Objects And Variables
        BondOfExchangeModel BondOfExchangeModel = new BondOfExchangeModel();
        Window_AddBondOfExchange win;
        AccountModel AccountModel= new AccountModel();
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

        ObservableCollection<BondOfExchange> grid_BondOfExchange;
        public ObservableCollection<BondOfExchange> Grid_BondOfExchange
        {
            get
            {
                return grid_BondOfExchange;
            }
            set
            {
                if (grid_BondOfExchange != value)
                {
                    grid_BondOfExchange = value;
                    RaisePropertyChanged("Grid_BondOfExchange");
                }
            }
        }

        ObservableCollection<Bond_Exchange_detail> grid_Bond_Exchange_detail;
        public ObservableCollection<Bond_Exchange_detail> Grid_Bond_Exchange_detail
        {
            get
            {
                return grid_Bond_Exchange_detail;
            }
            set
            {
                if (grid_Bond_Exchange_detail != value)
                {
                    grid_Bond_Exchange_detail = value;
                    RaisePropertyChanged("Grid_Bond_Exchange_detail");
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

        Account selected_AccountFrom;
        public Account Selected_AccountFrom
        {
            get
            {
                return selected_AccountFrom;
            }
            set
            {
                if (selected_AccountFrom != value)
                {
                    selected_AccountFrom = value;
                    RaisePropertyChanged("Selected_AccountFrom");
                }
            }
        }
        Account selected_AccountTo;
        public Account Selected_AccountTo
        {
            get
            {
                return selected_AccountTo;
            }
            set
            {
                if (selected_AccountTo != value)
                {
                    selected_AccountTo = value;
                    RaisePropertyChanged("Selected_AccountTo");
                }
            }
        }


        BondOfExchange current_BondOfExchange;
        public BondOfExchange Current_BondOfExchange
        {
            get
            {
                return current_BondOfExchange;
            }
            set
            {
                if (current_BondOfExchange != value)
                {
                    current_BondOfExchange = value;
                    RaisePropertyChanged("Current_BondOfExchange");
                }
            }
        }

        Bond_Exchange_detail current_Bond_Exchange_detail;
        public Bond_Exchange_detail Current_Bond_Exchange_detail
        {
            get
            {
                return current_Bond_Exchange_detail;
            }
            set
            {
                if (current_Bond_Exchange_detail != value)
                {
                    current_Bond_Exchange_detail = value;
                    RaisePropertyChanged("Current_Bond_Exchange_detail");
                }
            }
        }




        #endregion
        #region Construcor
        public BondOfExchange_ViowModel()
        {
            Grid_BondOfExchange = new ObservableCollection<BondOfExchange>();
            BondOfExchangeModel.GetBondOfExchanges(Grid_BondOfExchange);

            Grid_Account = new ObservableCollection<Account>();
            AccountModel.GetAccounts(Grid_Account);

           
            // Current_BondOfExchange.String_Accountfrom
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            DeletDetailcommand = new RelayCommand(par => DeletDetaile(), par => CanDeletDetaile());
            AddDetailcommand = new RelayCommand(par => AddDetaile(), par => CanAddDetaile());
            Closecommand = new RelayCommand(par => close());
           


            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 14;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events

        public void Add()
        {
            
               Grid_Bond_Exchange_detail = new ObservableCollection<Bond_Exchange_detail>();
           Current_Bond_Exchange_detail = new Bond_Exchange_detail();
            
            int maxid = new Class_SqlConnection().Get_Max("BondOfExchange");

            Current_BondOfExchange = new BondOfExchange {Bond_Exchange_id=maxid };
            Current_BondOfExchange.Bond_Exchange_amount = 0;
            win = new Window_AddBondOfExchange { DataContext = this };
            win.ShowDialog();
        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;

        void Edit()
        {
            IsEditing = true;

            Grid_Bond_Exchange_detail = new ObservableCollection<Bond_Exchange_detail>();
            BondOfExchangeModel.GetBond_Exchange_details(Grid_Bond_Exchange_detail, Current_BondOfExchange.Bond_Exchange_id);


            win = new Window_AddBondOfExchange { DataContext = this };
            win.ShowDialog();
        }
        bool CanEdit() => Current_BondOfExchange != null && PermissionUser.Update_opretion == true;

        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                BondOfExchangeModel.OperarionBondOfExchange(Current_BondOfExchange,Grid_Bond_Exchange_detail, "Delete");

                string message1 = "تمت عملية الحذف بنجاح";
                string caption1 = "عملية الحذف";
                MessageBoxImage icon1 = MessageBoxImage.Information;
                MessageBoxButton buttons1 = MessageBoxButton.OK;
                MessageBox.Show(message1, caption1, buttons1, icon1);

                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 14;
                Current_Activity.Activity_record_num = Current_BondOfExchange.Bond_Exchange_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }
            else
            {
                return;
            }
        }
        bool CanDelet() => Current_BondOfExchange != null && PermissionUser.Delete_opretion == true;

        void Save()
        {
            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;

            Current_Activity.Form_id = 14;
            Current_Activity.Activity_record_num = Current_BondOfExchange.Bond_Exchange_id;
            MessageBox.Show(Current_BondOfExchange.Bond_Exchange_statement);
            //////////////////////////////////////////////////////////
            Current_BondOfExchange.Account_from_id = Selected_AccountFrom.Account_id;
            Current_BondOfExchange.Account_to_id = Selected_AccountTo.Account_id;
            Current_BondOfExchange.Bond_Exchange_status = false;
            Current_BondOfExchange.Post_date = "-";
            if (IsEditing && BondOfExchangeModel.Check_Exsit(Current_BondOfExchange.Bond_Exchange_id))
            {

                BondOfExchangeModel.OperarionBondOfExchange(Current_BondOfExchange,Grid_Bond_Exchange_detail,"Update");
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
            else if (BondOfExchangeModel.Check_Exsit(Current_BondOfExchange.Bond_Exchange_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);


            }

            else
            {
                BondOfExchangeModel.OperarionBondOfExchange(Current_BondOfExchange,Grid_Bond_Exchange_detail,"Insert");
                
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

            Grid_BondOfExchange.Clear();
            BondOfExchangeModel.GetBondOfExchanges(Grid_BondOfExchange);


            //Enable_Grid = false;
        }
        bool CanSave() => Current_BondOfExchange != null && Grid_Bond_Exchange_detail != null && !Current_BondOfExchange.HasErrors;

       

        void DeletDetaile()
        {
            Current_BondOfExchange.Bond_Exchange_amount -= Current_Bond_Exchange_detail.Bond_Exchange_detail_amount;
            Grid_Bond_Exchange_detail.Remove(Current_Bond_Exchange_detail);
            Current_Bond_Exchange_detail = new Bond_Exchange_detail();
        }
        bool CanDeletDetaile() =>true;
        //bool CanDeletDetaile() => Current_Bond_Exchange_detail != null;
        void AddDetaile()
        {
           int maxid= new Class_SqlConnection().Get_Max("Bond_Exchange_detail");
            Current_Bond_Exchange_detail.Bond_Exchange_detail_id = maxid;
            Current_Bond_Exchange_detail.Bond_Exchange_id = Current_BondOfExchange.Bond_Exchange_id;
            Current_BondOfExchange.Bond_Exchange_amount += Current_Bond_Exchange_detail.Bond_Exchange_detail_amount;
            Grid_Bond_Exchange_detail.Add(Current_Bond_Exchange_detail);
            Current_Bond_Exchange_detail = new Bond_Exchange_detail();
        }
        bool CanAddDetaile() =>true;
      //  bool CanAddDetaile() => Current_Bond_Exchange_detail.Bond_Exchange_detail_statement != "" && Current_Bond_Exchange_detail.Bond_Exchange_detail_amount != 0;

        void close()
        {
            Current_BondOfExchange = null;
            Current_Bond_Exchange_detail = null;
            win.Close();
        }

        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; private set; }
        public RelayCommand AddDetailcommand { get; private set; }
        public RelayCommand DeletDetailcommand { get; private set; }
        #endregion



        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
