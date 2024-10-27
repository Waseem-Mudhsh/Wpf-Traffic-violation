using System.Collections.ObjectModel;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models.Reservation_Model
{
    public class Reservation
    {
        ViolationServices services;
        ViolationServices violationServices;
        ExcelReader _excelReader = new ExcelReader();
        helper _helper = new helper();
        Isphelper sphelper;
        SP_Query sP_Query;
        ValidationRegex validationRegex;
        public Reservation()
        {

            validationRegex = new ValidationRegex();
            sphelper = new Directorates();
            sP_Query = new SP_Query();
            violationServices = new ViolationServices();
            services = new ViolationServices();
        }
        public ObservableCollection<ReservationModel> GetAllReservation()
        {
            return new ObservableCollection<ReservationModel>();
        }
    }
}
