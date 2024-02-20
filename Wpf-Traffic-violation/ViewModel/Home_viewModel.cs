using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Traffic_violation.ViewModel
{
    class Home_viewModel :BindableBase
    {

        #region Objects And Variables
        string violationtotal;
        public string Violationtotal
        {
            get
            {
                return violationtotal;
            }
            set
            {
                if (violationtotal != value)
                {
                    violationtotal = value;
                    RaisePropertyChanged("Violationtotal");
                }
            }
        }
        string violationPayment;
        public string ViolationPayment
        {
            get
            {
                return violationPayment;
            }
            set
            {
                if (violationPayment != value)
                {
                    violationPayment = value;
                    RaisePropertyChanged("ViolationPayment");
                }
            }
        }
        string commtotal;
        public string Commtotal
        {
            get
            {
                return commtotal;
            }
            set
            {
                if (commtotal != value)
                {
                    commtotal = value;
                    RaisePropertyChanged("Commtotal");
                }
            }
        }
        string commtotalnot;
        public string Commtotalnot
        {
            get
            {
                return commtotalnot;
            }
            set
            {
                if (commtotalnot != value)
                {
                    commtotalnot = value;
                    RaisePropertyChanged("Commtotalnot");
                }
            }
        }
        string opjtotal;
        public string Opjtotal
        {
            get
            {
                return opjtotal;
            }
            set
            {
                if (opjtotal != value)
                {
                    opjtotal = value;
                    RaisePropertyChanged("Opjtotal");
                }
            }
        }
        string opjtotalnot;
        public string Opjtotalnot
        {
            get
            {
                return opjtotalnot;
            }
            set
            {
                if (opjtotalnot != value)
                {
                    opjtotalnot = value;
                    RaisePropertyChanged("Opjtotalnot");
                }
            }
        }







        #endregion
        #region Proprties
        #endregion
        #region Construcor
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
