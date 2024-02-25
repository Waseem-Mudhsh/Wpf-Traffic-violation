using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class VoilationModel
    {

        ViolationServices violationServices;
        ExcelReader _excelReader = new ExcelReader();
        helper _helper = new helper();
        Isphelper sphelper;
        SP_Query sP_Query;
        ValidationRegex validationRegex;
        public VoilationModel()
        {
            validationRegex = new ValidationRegex();
            sphelper = new Directorates();
            sP_Query = new SP_Query();
            violationServices = new ViolationServices();



        }

        ///////////////////////////////// start GetViolation/////////////////////////////////////



        public ObservableCollection<Violation> GetViolation()
        {
            ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
            var response = sphelper.GetCollection(sP_Query.getViolation, "getViolation");
            if (response.Count > 0)
            {
                foreach (DataRow row in response)
                {
                    Violation per = new Violation
                    {
                        Violation_id = (int)row[0]
                     ,
                        Violation_date = row[1].ToString()
                     ,
                        Plate_id = (int)row[2]
                     ,
                        Street_id = (int)row[3]
                     ,
                        Teaffic_man_id = (int)row[4]
                     ,
                        Violation_type_id = (int)row[5]
                     ,
                        Notise = row[6].ToString()
                     ,
                        Violation_penalty = (int)row[7]
                     ,
                        Payment_status = (int)row[8]
                     ,
                        Plate_Num = (string)row[9]
                     ,
                        VounchrNum = (int)row[10]
                      ,
                        Provinceid = (int)row[11]
                     ,
                        Plate_Type = (string)row[12]
                        ,
                        String_ViolationType = (string)row[13]
                        ,
                        String_TrafficMan = (string)row[14]
                        ,
                        String_Street = (string)row[15]
                        ,
                        Amount = (int)row[16]
                      ,
                        String_Status = ((int)row[8] == 1) ? "مسدد" : "غير مسدد"

                    };
                    //per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", per.Plate_id);
                    //per.Plate_Type = new Class_SqlConnection().Get_row("getPlateTypenames", per.Plate_id);
                    //per.String_ViolationType = new Class_SqlConnection().Get_row("GetViolationtype_name", per.Violation_type_id);
                    //per.String_TrafficMan = new Class_SqlConnection().Get_row("GetTrafficMan_name", per.Teaffic_man_id);
                    //per.String_Street = new Class_SqlConnection().Get_row("GetStreet_name", per.Street_id);
                    //per.Amount =  per.Violation_penalty;
                    //per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
                    Violations.Add(per); //الي بنربطه مع الجريد فيو
                }
            }

            return Violations;

        }

        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////
        //public ObservableCollection<Violation> GetViolation()//تجرية المزامنة
        //{
        //    ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
        //    SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        //    //Class_SqlConnection sql = new Class_SqlConnection();
        //    using (con)
        //    {
        //        try
        //        {
        //            con.Open();
        //        }
        //        catch (Exception)
        //        {

        //            MessageBox.Show("Cant Open con");
        //        }
        //        //SqlCommand Command = new SqlCommand("Select * from Person", con);
        //        SqlCommand Command = new SqlCommand
        //        {
        //            CommandType = CommandType.StoredProcedure,
        //            CommandText = "getViolation",
        //            Connection = con

        //        };
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
        //        dataAdapter.Fill(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                Violation per = new Violation
        //                {
        //                    Violation_id = (int)row[0]
        //                 ,
        //                    Violation_date = row[1].ToString()
        //                 ,
        //                    Violation_photo1 = Convert.ToByte(row[2].ToString())
        //                 ,
        //                    Violation_photo2 = Convert.ToByte(row[3].ToString())
        //                 ,
        //                    Plate_id = (int)row[4]
        //                 ,
        //                    Street_id = (int)row[5]
        //                 ,
        //                    Teaffic_man_id = (int)row[6]
        //                 ,
        //                    Violation_type_id = (int)row[7]
        //                 ,
        //                    Notise = row[8].ToString()
        //                 ,
        //                    Violation_penalty = (int)row[9]
        //                 ,
        //                    Payment_status = (int)row[10]
        //                };
        //                per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", per.Plate_id);
        //                per.Plate_Type = new Class_SqlConnection().Get_row("getPlateTypenames", per.Plate_id);
        //                per.String_ViolationType = new Class_SqlConnection().Get_row("GetViolationtype_name", per.Violation_type_id);
        //                per.String_TrafficMan = new Class_SqlConnection().Get_row("GetTrafficMan_name", per.Teaffic_man_id);
        //                per.String_Street = new Class_SqlConnection().Get_row("GetStreet_name", per.Street_id);
        //                per.Amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", per.Violation_type_id) + per.Violation_penalty;
        //                per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
        //                Violations.Add(per); //الي بنربطه مع الجريد فيو
        //            }
        //        }
        //    }

        //    return Violations;
        //}
        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////
        //public  ObservableCollection<Violation> GetViolation()//تجرية المزامنة
        //{
        //    ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
        //   Violations = violationServices.GetAllViolation();

        //    return Violations;

        //}
        public ObservableCollection<Violation> GetAllViolationReport(string typrviolation, string from_date, string to_date)//تجرية المزامنة
        {
            ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();

            try
            {
                var From = Convert.ToDateTime(from_date);
                var To = Convert.ToDateTime(to_date);
                Violations = violationServices.GetAllViolationReport(typrviolation, From, To);
            }
            catch (Exception)
            {


            }

            return Violations;


        }
        public ObservableCollection<ReceiptReportModel> GetViolationByReceiptDetailes(string typrviolation, string from_date, string to_date)
        {
            ObservableCollection<ReceiptReportModel> result = new ObservableCollection<ReceiptReportModel>();
            try
            {

                to_date = (to_date == null) ? from_date : to_date;
                //var From = Convert.ToDateTime(from_date);
                //var To = Convert.ToDateTime(to_date);
                Hashtable key = new Hashtable();
                key.Add("fromData", from_date);
                key.Add("toData", to_date);
                var param = sphelper.prpareParam(key);
                var violations = sphelper.GetCollectionByParam(sP_Query.Rep_VilationbyRecipt, "Rep_VilationbyRecipt", param);
                if (violations.Code == 3) return result = null;
                foreach (DataRow item in violations.Data)
                {
                    var model = new ReceiptReportModel
                    {
                        ReceiptId = (int)item[0],
                        VehicleId = (string)item[1],
                        ViolationPenalty = (int)item[2],
                        PaymentStatus = (int)item[3],
                        NameOfPaid = (string)item[4],
                        PlateType = (string)item[5],
                        Provinceid = (int)item[6],
                        ReasonOfPaid = ((string)item[7] == null) ? " " : (string)item[7],
                        ViolationTypcount = (int)item[8],

                    };

                    result.Add(model);
                }

                //return violationServices.GetAllViolationByReceiptDetailes(typrviolation, From, To);

            }
            catch (Exception e)
            {
                MessageBox.Show("Have Exception " + e);

            }
            return result;


        }
        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////
        public bool updateVilation(int violationID)
        {

            bool result = violationServices.updateVilation(violationID);
            return result;
        }
        public bool OperarionViolation(Violation Violation, string operartion)
        {
            //var excuteOperation= violationServices.Oper

            return true;
        }

        public bool ExcutOperarionViolationBulk(Violation Violation, int operationType, int rowCount, int cont)
        {
            bool excute = false;
            var violationData = _helper.CreateViolation(Violation);
            if (operationType == 1)
            {
                excute = violationServices.Insertbulk(violationData, rowCount, cont);
            }

            return excute;
        }
        public bool ExcutOperarionViolation(Violation Violation, int operationType)
        {
            bool excute;
            var violationData = _helper.CreateViolation(Violation);


            if (operationType == 1)
            {
                excute = violationServices.Insert(violationData);
            }
            else if (operationType == 2)
            {
                excute = violationServices.Edite(violationData);
            }
            else if (operationType == 3)
            {
                excute = violationServices.Delete(violationData);
            }
            else
            {
                return false;
            }


            return excute;
        }
        ///////////////////////////////// end OperarionReasonToOblection/////////////////////////////////////
        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////





        ///////////////////////////////// start Check_Exsit/////////////////////////////////////
        public bool Check_Exsit(int value)
        {
            Class_SqlConnection sql = new Class_SqlConnection();
            using (sql.con)
            {
                try
                {
                    sql.con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cant Open Conncation");

                }
                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "checkViolation",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Violation_id", value);


                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }


            }
        }
        public bool GetExcel(ObservableCollection<Violation> Violations)
        {
            OpenFileDialog op = new OpenFileDialog();


            op.Title = "Select a Excel File";
            op.Filter = "AllFiles | *.* | Excel Files |*.XLSX";
            if (op.ShowDialog() == true)
            {
                var data = _excelReader.ReadExcelFile(op.FileName);
                if (data)
                {
                    return true;
                }


            }



            return false;

        }


        //Install-Package EPPlus

        /////////////////////////////////end GetExcel/////////////////////////////////////


        public ObservableCollection<Violation> GetViolation_not_payment(int id)//تجرية المزامنة
        {
            ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            //Class_SqlConnection sql = new Class_SqlConnection();
            using (con)
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {

                    MessageBox.Show("Cant Open con");
                }
                //SqlCommand Command = new SqlCommand("Select * from Person", con);
                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "getViolation_not_payment",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@citizen_id", id);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Violation per = new Violation
                        {
                            Violation_id = (int)row[0]
                         ,
                            Violation_date = row[1].ToString()
                         ,
                            Violation_photo1 = Convert.ToByte(row[2].ToString())
                         ,
                            Violation_photo2 = Convert.ToByte(row[3].ToString())
                         ,
                            Plate_id = (int)row[4]
                         ,
                            Street_id = (int)row[5]
                         ,
                            Teaffic_man_id = (int)row[6]
                         ,
                            Violation_type_id = (int)row[7]
                         ,
                            Notise = row[8].ToString()
                         ,
                            Violation_penalty = (int)row[9]
                         ,
                            Payment_status = (int)row[10]
                        };
                        per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", per.Plate_id);
                        per.Plate_Type = new Class_SqlConnection().Get_row("getPlateTypenames", per.Plate_id);
                        per.String_ViolationType = new Class_SqlConnection().Get_row("GetViolationtype_name", per.Violation_type_id);
                        per.String_TrafficMan = new Class_SqlConnection().Get_row("GetTrafficMan_name", per.Teaffic_man_id);
                        per.String_Street = new Class_SqlConnection().Get_row("GetStreet_name", per.Street_id);
                        per.Amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", per.Violation_type_id) + per.Violation_penalty;
                        per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
                        Violations.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }

            return Violations;
        }

        public Violation GetViolationForEdit(int violation_id)
        {
            Violation current_Violation = new Violation();


            Hashtable keys = new Hashtable();
            keys.Add("violationId", violation_id);
            var getparam = sphelper.prpareParam(keys);

            var response = sphelper.GetCollectionByParam(sP_Query.getviolationFoEdit, "getviolationFoEdit", getparam);
            if (response.Data.Count > 0)
            {
                {
                    foreach (DataRow row in response.Data)
                    {
                        current_Violation = new Violation
                        {
                            Violation_id = (int)row[0]
                         ,
                            Violation_date = row[1].ToString()
                         ,
                            Plate_id = (int)row[2]
                         ,
                            Street_id = (int)row[3]
                         ,
                            Teaffic_man_id = (int)row[4]
                         ,
                            Violation_type_id = (int)row[5]
                         ,
                            Notise = row[6].ToString()
                         ,
                            Violation_penalty = (int)row[7]
                         ,
                            Payment_status = (int)row[8]
                         ,
                            Plate_Num = (string)row[9]
                         ,
                            VounchrNum = (int)row[10]
                          ,
                            Provinceid = (int)row[11]
                         ,
                            Plate_Type = (string)row[12]
                            ,
                            String_ViolationType = (string)row[13]
                            ,
                            String_TrafficMan = (string)row[14]
                            ,
                            String_Street = (string)row[15]
                            ,
                            Amount = (int)row[16]
                          ,
                            String_Status = ((int)row[8] == 1) ? "مسدد" : "غير مسدد"

                        };


                    }


                }
            }
            else
            {
                current_Violation = null;
            }

            return current_Violation;



        }



        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////

    }
}
