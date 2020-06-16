using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.Models;

namespace Wpf_Traffic_violation.ViewModel
{
    class Trafficman_ViewModel : BindableBase
    {

        #region Objects And Variables
        Models.TrafficmanModel userModel = new TrafficmanModel();
        #endregion
        #region Proprties
        ObservableCollection<TrafficMan> grid_trafficmans;
        public ObservableCollection<TrafficMan> Grid_trafficmans //يربط مع الجرد فيو 
        {
            get
            {
                return grid_trafficmans;
            }
            set
            {
                if (grid_trafficmans != value)
                {
                    grid_trafficmans = value;
                    RaisePropertyChanged("Grid_trafficmans");
                }
            }
        }
        TrafficMan currunt_trafficman; //selectedItemيربط مع 
        public TrafficMan Currunt_trafficman
        {
            get
            {
                return currunt_trafficman;
            }
            set
            {
                if (currunt_trafficman != value)
                {
                    currunt_trafficman = value;
                    RaisePropertyChanged("Currunt_trafficman");
                }
            }
        }

        #endregion
        #region Proprties
        #endregion
        #region Construcor
        public Trafficman_ViewModel()
        {
            Grid_trafficmans = new ObservableCollection<TrafficMan>();
            userModel.GetTrafficMans(Grid_trafficmans);
            //Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            //Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            //Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            //Savecommand = new RelayCommand(par => Save());
        }
        #endregion
        #region Methodes And Events
        #endregion
        #region Commands
        #endregion













        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
