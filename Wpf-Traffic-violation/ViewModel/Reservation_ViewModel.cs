using System;
using System.Collections.ObjectModel;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Reservation_Model;

namespace Wpf_Traffic_violation.ViewModel
{
    public class Reservation_ViewModel : BindableBase
    {

        #region Proprties
        Reservation reservation = new Reservation();
        ObservableCollection<ReservationModel> grid_Reservation;
        ObservableCollection<ReservationModel> grid_paidReservation;
        ObservableCollection<ReservationModel> grid_enterReservation;
        ObservableCollection<ReservationModel> grid_ExReservation;
        ReservationModel isSelectedReservation;
        #endregion

        public Reservation_ViewModel()
        {
            //Grid_Reservation = new ObservableCollection<ReservationModel>(reservation.GetAllReservation());
            //Grid_ExReservation = Grid_Reservation.Select(x => { x.IsRelease = true; return x; }) as ObservableCollection<ReservationModel>;
            //Grid_ExReservation = Grid_Reservation.Select(x => { x.IsEnter = true; return x; }) as ObservableCollection<ReservationModel>;


        }
        public ObservableCollection<ReservationModel> Grid_Reservation
        {
            get => grid_Reservation;
            set => SetProperty(grid_ExReservation, value, "Grid_Reservation");

        }
        public ObservableCollection<ReservationModel> Grid_ExReservation
        {
            get => grid_Reservation;
            set => SetProperty(grid_Reservation, value, "Grid_Reservation");

        }

        public ReservationModel IsSelectedReservation
        {
            get => isSelectedReservation;
            set => SetProperty(isSelectedReservation, value, "IsSelectedReservation");

        }
        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
        #region Construcor

        #endregion

        private void SetProperty(object propData, object value, string PropName)
        {
            if (propData != value)
            {
                propData = value;
                RaisePropertyChanged(PropName);
            }
        }
    }
}
