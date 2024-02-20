using NPOI.OpenXml4Net.OPC.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class QureyIdNumberModel
    {
        ViolationServices services;
        ViolationServices violationServices;
        ExcelReader _excelReader = new ExcelReader();
        helper _helper = new helper();
        Isphelper sphelper;
        SP_Query sP_Query;
        ValidationRegex validationRegex;
        public QureyIdNumberModel()
        {

            validationRegex = new ValidationRegex();
            sphelper = new Directorates();
            sP_Query = new SP_Query();
            violationServices = new ViolationServices();
            services = new ViolationServices();
        }

        ///////////////////////////////// start GetCitizens/////////////////////////////////////
        public Vehicle GetVehicleCard( int Id)
        {
            Vehicle Vehicle = new Vehicle();
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
                SqlCommand Command1 = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetVehicleCard",
                    Connection = con

                };
                Command1.Parameters.AddWithValue("@Id", Id);
                DataTable dt1 = new DataTable();
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(Command1);
                dataAdapter1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow row in dt1.Rows)
                    {

                        Vehicle.Potty_id = (int)row[0];
                        Vehicle.Vehicle_engine_num = (int)row[1];
                        Vehicle.Vehicle_color = row[2].ToString();
                        Vehicle.Vehicle_shape = row[3].ToString();
                        Vehicle.Vehicle_model = row[4].ToString();
                        Vehicle.Vehicle_customs_num = (int)row[5];
                        Vehicle.Company_manu_name = row[6].ToString();
                        Vehicle.Status_v = (int)row[7];
                        Vehicle.Release_palc_c = (int)row[8];
                        Vehicle.Release_date_c = row[9].ToString();
                        Vehicle.Vehicle_card_id = (int)row[10];
                        Vehicle.Release_date = row[11].ToString();
                        Vehicle.Release_plase = (int)row[12];
                        Vehicle.Noties = row[13].ToString();
                        Vehicle.Status = (int)row[14];
                        Vehicle.Citizen_id = (int)row[15];
                        Vehicle.String_Citizen = row[16].ToString();
                        Vehicle.String_Provinces = new Class_SqlConnection().Get_row("GetProvince_name", Vehicle.Release_palc_c);
                        Vehicle.String_Provinces_vc = new Class_SqlConnection().Get_row("GetProvince_name", Vehicle.Release_plase);


                    }
                }

            }
            return Vehicle;
        }
        ///////////////////////////////// end GetCitizens/////////////////////////////////////

        ///////////////////////////////// start GetViolation/////////////////////////////////////

        //public ObservableCollection<Violation> GetViolationQurey(Violation violation)
        //{
        //    ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
        //    try
        //    {
        //        if (violation.Plate_Num != "")
        //        {
        //             Violations = services.GetViolation(Convert.ToString( violation.Plate_Num),violation.Provinceid,violation.Plate_TypeId);
        //        }
        //        else
        //        {
        //            Violations = services.GetViolationByplatNum(violation.Plate_Num);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //    return Violations;
        //}
        public ObservableCollection<Violation> GetViolationQurey(Violation violation)
        {
            Hashtable key = new Hashtable();
            key.Add("vehicle_id", violation.Plate_Num);
            key.Add("Provinceid", violation.Provinceid);
            key.Add("Plate_id", violation.Plate_TypeId);
            var Getparam = sphelper.prpareParam(key);
            ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
            var response = sphelper.GetCollectionByParam(sP_Query.QueryViolation, "QueryViolation", Getparam);
            if (response.Data.Count > 0)
            {
                foreach (DataRow row in response.Data)
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

        public ObservableCollection<Violation> GetViolation( int Id)
        {
            
            
           ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
           
            //SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            ////Class_SqlConnection sql = new Class_SqlConnection();
            //using (con)
            //{
            //    try
            //    {
            //        con.Open();
            //    }
            //    catch (Exception)
            //    {

            //        MessageBox.Show("Cant Open con");
            //    }
            //    //SqlCommand Command = new SqlCommand("Select * from Person", con);
            //    SqlCommand Command = new SqlCommand
            //    {
            //        CommandType = CommandType.StoredProcedure,
            //        CommandText = "getViolationById",
            //        Connection = con

            //    };
            //    Command.Parameters.AddWithValue("@Id", Id);
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
            //    dataAdapter.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            Violation per = new Violation
            //            {
            //                Violation_id = (int)row[0]
            //             ,
            //                Violation_date = row[1].ToString()
            //             ,
            //                Violation_photo1 = Convert.ToByte(row[2].ToString())
            //             ,
            //                Violation_photo2 = Convert.ToByte(row[3].ToString())
            //             ,
            //                Plate_id = (int)row[4]
            //             ,
            //                Street_id = (int)row[5]
            //             ,
            //                Teaffic_man_id = (int)row[6]
            //             ,
            //                Violation_type_id = (int)row[7]
            //             ,
            //                Notise = row[8].ToString()
            //             ,
            //                Violation_penalty = (int)row[9]
            //             ,
            //                Payment_status = (int)row[10]
            //             ,
            //                Plate_Type = row[11].ToString()
            //             ,
            //                String_Street = row[12].ToString()
            //            ,
            //                String_TrafficMan = row[13].ToString()
            //            ,
            //                String_ViolationType = row[14].ToString()
            //            };
            //            per.Amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", per.Violation_type_id);
            //            per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", Id);
            //            per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
            //            Violations.Add(per); //الي بنربطه مع الجريد فيو
            //        }
            //    }
            //}

            return Violations;
        }

        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////

    }
}
