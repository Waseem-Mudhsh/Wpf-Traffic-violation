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

        public Window_AddUser win;

        #region Objects And Variables

        Models.UserModel userModel = new UserModel();
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
        public static ObservableCollection<User> grid_Users= new ObservableCollection<User>(UserModel.GetUsers());
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
        User save_User;
        public User Save_User
        {
            get
            {
                return save_User;
            }
            set
            {
                if (save_User != value)
                {
                    save_User = value;
                    RaisePropertyChanged("Save_User");
                }
            }
        }




        #endregion
        #region Construcor
        public User_ViewModel()
        {
            //grid_Users = new ObservableCollection<User>(userModel.GetUsers(grid_Users));
            //userModel.GetUsers(grid_Users);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save());
        }
        #endregion
        #region Methodes And Events
      
       

        public void Add()
        {
            //Currunt_User = new User();
            win = new Window_AddUser();
              win.ShowDialog();
          



        }
        bool CanAdd() => true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
          
            IsEditing = true;

        }
        bool CanEdit() => Currunt_User != null;





        void Delet()
        {

            UserModel.OperarionUser(Currunt_User, "Delete");
            grid_Users.Remove(Currunt_User);
        }
        bool CanDelet() => Currunt_User != null;
        void Save()
        {

            UserModel.OperarionUser(Currunt_User, "Insert");
            grid_Users.Add(Currunt_User);
            MessageBox.Show("Insert Done");


            //if (Currunt_User.String_usertype.ToString()=="النظام")
            //{
            //    Currunt_User.Usertype = 1;
            //}
            //else
            //{
            //    Currunt_User.Usertype = 2;
            //}


            //if (!userModel.Check_Exsit(Currunt_User.Userid))
            //{

            //    //(currunt_User.String_usertype == "النظام")?currunt_User.Usertype = 1 :currunt_User.Usertype = 2;
            //    UserModel.OperarionUser(Currunt_User, "Insert");
            //    grid_Users.Add(Currunt_User);
            //    MessageBox.Show("Insert Done");
            //}
            //else if (IsEditing && userModel.Check_Exsit(Currunt_User.Userid))
            //{
            //    UserModel.OperarionUser(Currunt_User, "Update");
            //    IsEditing = false;
            //    MessageBox.Show("Update Done");
            //    return;
            //}

            //else
            //{
            //    MessageBox.Show("Data is alrealy recorded");
            //}
            //User_ViewModel userViewModle1 = new User_ViewModel();

            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_User != null;
        #endregion
        #region Commands

        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        #endregion









        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
