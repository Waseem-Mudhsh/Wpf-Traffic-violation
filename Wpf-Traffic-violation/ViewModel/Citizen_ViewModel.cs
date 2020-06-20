using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
   public class Citizen_ViewModel : BindableBase
    {

        Window_AddCitizen win;
        #region Objects And Variables
        Models.CitizenModel citizenModel = new CitizenModel();
        #endregion
        #region Proprties
        ObservableCollection<Citizen> grid_Citizen;
        public ObservableCollection<Citizen> Grid_Citizens //يربط مع الجرد فيو 
        {
            get
            {
                return grid_Citizen;
            }
            set
            {
                if (grid_Citizen != value)
                {
                    grid_Citizen = value;
                    RaisePropertyChanged("Grid_Citizens");
                }
            }
        }
        Citizen currunt_Citizen; //selectedItemيربط مع 
     
        public Citizen Currunt_Citizen
        {
            get
            {
                return currunt_Citizen;
            }
            set
            {
                if (currunt_Citizen != value)
                {
                    currunt_Citizen = value;
                    RaisePropertyChanged("Currunt_Citizen");
                }
            }
        }

        
        #endregion
        #region Construcor
        public Citizen_ViewModel()
        {
            Grid_Citizens = new ObservableCollection<Citizen>();
            citizenModel.GetCitizens(Grid_Citizens);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(),par =>CanSave());
            Closecommand = new RelayCommand(par => close());
        }
        #endregion
        #region Methodes And Events



        public void Add()
        {
            Currunt_Citizen = new Citizen { Citizen_identitytype="شخصية", Citizen_blood_type= "+ O", String_social_status = "عازب" };
            win = new Window_AddCitizen { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;
            win = new Window_AddCitizen { DataContext = this };
            win.ShowDialog();

        }
        bool CanEdit() => Currunt_Citizen != null;





        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                CitizenModel.OperarionCitizen(Currunt_Citizen, "Delete");
                Grid_Citizens.Remove(Currunt_Citizen);
            }
            else
            {
                return;
            }


        }
        bool CanDelet() => Currunt_Citizen != null;
        void Save()
        {
            try { 
            Currunt_Citizen.Citizen_date_pirth = win.Datepicker_date.Text;

            if (win.Radiobutton_gender.IsChecked!=true)
            {
                Currunt_Citizen.String_gender = "أنثى";
            }
            else
            {
                Currunt_Citizen.String_gender = "ذكر";
            }
            if(Currunt_Citizen.String_social_status=="عازب")
            {
                Currunt_Citizen.Citizen_social_status = true;
            }
            else
            {
                Currunt_Citizen.Citizen_social_status = false;
            }


            if (IsEditing&&citizenModel.Check_Exsit(Currunt_Citizen.Citizen_id))
            {
                CitizenModel.OperarionCitizen(Currunt_Citizen, "Update");
                IsEditing = false;
                
                string message = "تمت عملية التعديل بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
                close();
            }
            else if (citizenModel.Check_Exsit(Currunt_Citizen.Citizen_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
                win.textBox_citizenid.Focus();
                win.textBox_citizenid.SelectionStart = 0;
                win.textBox_citizenid.SelectionLength = win.textBox_citizenid.Text.Length;
            }
            else
            {
                CitizenModel.OperarionCitizen(Currunt_Citizen, "Insert");
                Grid_Citizens.Add(Currunt_Citizen);
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

            }

            }// end try
            catch (Exception e)
            {
                MessageBox.Show("Error reading from "+ e.Message);

                close();

            }

            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_Citizen != null &&!Currunt_Citizen.HasErrors;
        void close()
        {
            Currunt_Citizen = null;
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
