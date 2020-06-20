using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{

    public class User_ViewModel : BindableBase
    {

         Window_AddUser win;

        #region Objects And Variables

        Models.UserModel userModel = new UserModel();
        Models.TrafficmanModel trafficMan = new TrafficmanModel();
        #endregion
        #region Proprties
        //ObservableCollection<User> grid_Users;
        //   public  ObservableCollection<User> Grid_Users //يربط مع الجرد فيو 
        //   {
        //       get
        //       {
        //           return grid_Users;
        //       }
        //       set
        //       {
        //           if (grid_Users != value)
        //           {
        //               grid_Users = value;
        //               RaisePropertyChanged("Grid_Users");
        //           }
        //       }
        //   }


        public ObservableCollection<User> grid_Users { get; set; }
        public ObservableCollection<TrafficMan>get_Trafficman { get; set; }
        User currunt_User; //selectedItemيربط مع 
        public User Currunt_User
        {
            get
            {
                return currunt_User;
            }
            set
            {
                if (currunt_User != value)
                {
                    currunt_User = value;
                    RaisePropertyChanged("Currunt_User");
                }
            }
        }
      






        #endregion
        #region Construcor
        public User_ViewModel()
        {
            grid_Users = new ObservableCollection<User>();
            grid_Users = userModel.GetUsers();
            get_Trafficman = new ObservableCollection<TrafficMan>();
            trafficMan.GetTrafficMans(get_Trafficman);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());
        }
        #endregion
        #region Methodes And Events



        public void Add()
        {
            Random rand = new Random();
            Currunt_User = new User { Userid=rand.Next(),String_usertype="النظام" };
            win = new Window_AddUser { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;
            win = new Window_AddUser { DataContext = this };
            win.ShowDialog();

        }
        bool CanEdit() => Currunt_User != null;





        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                UserModel.OperarionUser(Currunt_User, "Delete");
                grid_Users.Remove(Currunt_User);
            }
            else
            {
                return;
            }

           
        }
        bool CanDelet() => Currunt_User != null;
        void Save()
        {//ComboBoxes.Combo_usertype
            
           if (Currunt_User.String_usertype=="النظام")
            {
                Currunt_User.Usertype = 1;
            }
           else if(Currunt_User.String_usertype == "التطبيق")
            {
                Currunt_User.Usertype = 2;
            }
            //else
            //{
            //    Currunt_User.Usertype = 3;
            //}
            if (IsEditing && userModel.Check_Exsit(Currunt_User.Userid))
            {

                UserModel.OperarionUser(Currunt_User, "Update");
                IsEditing = false;
                close();
                string message = "تمت عملية التعديل بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message,caption,buttons,icon);
            }
            else if (userModel.Check_Exsit(Currunt_User.Userid))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
               
                win.textBox_id.Focus();
                win.textBox_id.SelectionStart = 0;
                win.textBox_id.SelectionLength = win.textBox_id.Text.Length;
            }



            else
            {
                UserModel.OperarionUser(Currunt_User, "Insert");
                grid_Users.Add(Currunt_User);
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
                
            }

           

            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_User != null &&!Currunt_User.HasErrors;
        void close()
        {
            Currunt_User = null;
            win.Close();
        }
        void GetExcel()
        {
            grid_Users = new ObservableCollection<User>();
            grid_Users = userModel.GetExcel();
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
