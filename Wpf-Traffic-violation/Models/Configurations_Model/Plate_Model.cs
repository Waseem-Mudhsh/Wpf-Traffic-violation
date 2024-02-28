using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using Wpf_Traffic_violation.Core.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class Plate_Model
    {
        ValidationRegex validationRegex;
        ViolationServices violationServices;
        OpreationSql opreationSql;

        SP_Query sP_Query;
        Isphelper isphelper;
        PlateOfType_Model PlateOfType_Model = new PlateOfType_Model();
        Provinces_Model Provinces_Model = new Provinces_Model();
        public Plate_Model()
        {
            validationRegex = new ValidationRegex();
            sP_Query = new SP_Query();
            opreationSql = new OpreationSql();
            violationServices = new ViolationServices();
            isphelper = new Sphelper();
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetPlates/////////////////////////////////////

        public ObservableCollection<Plate> GetPlates()
        {
            ObservableCollection<Plate> Plates = new ObservableCollection<Plate>();
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

                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "getPlate",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Plate per = new Plate
                        {
                            Plate_id = (int)row[0],
                            Release_date = row[1].ToString(),
                            Vehicle_id = (int)row[2],
                            Plate_num = row[3].ToString(),
                            Account_id = (int)row[4],
                            Plate_type = (int)row[5],
                            Status = (int)row[6],
                            Province_id = (int)row[7]
                        };
                        per.String_Plate_type = PlateOfType_Model.GetPlatetype_name(per.Plate_type);// يعطينا  نص نوع المخالفة 
                        per.Province_name = Provinces_Model.GetProvinces_name(per.Province_id);// يعطينا  نص مكان الإصدار 
                        if (per.Status == 1)
                            per.String_Status = "نشطة";
                        else if (per.Status == 2)
                            per.String_Status = "منتهية";
                        else if (per.Status == 3)
                            per.String_Status = "مفقودة";
                        Plates.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }
            return Plates;

        }
        public ObservableCollection<PlateDetails> GetPlatesDetails()
        {
            ObservableCollection<PlateDetails> Plates = new ObservableCollection<PlateDetails>();
            Plates = violationServices.GetPlate();

            return Plates;

        }



        ///////////////////////////////// end GetPlates/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start OperarionPlate/////////////////////////////////////

        public bool OperarionPlate(Plate Plates, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[8];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@ID", SqlDbType.Int)
            {
                Value = Plates.Plate_id
            };
            param[1] = new SqlParameter("@Release_date", SqlDbType.NVarChar, 15)
            {
                Value = Plates.Release_date
            };
            param[2] = new SqlParameter("@vehicle_id", SqlDbType.Int)
            {
                Value = Plates.Vehicle_id
            };
            param[3] = new SqlParameter("@Plate_num", SqlDbType.NVarChar, 20)
            {
                Value = Plates.Plate_num
            };
            param[4] = new SqlParameter("@plate_type", SqlDbType.Int)
            {
                Value = Plates.Plate_type
            };
            param[5] = new SqlParameter("@Status", SqlDbType.Int)
            {
                Value = Plates.Status
            };
            param[6] = new SqlParameter("@Province_id", SqlDbType.Int)
            {
                Value = Plates.Province_id
            };

            param[7] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("OperarionPlate", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionPlate/////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
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
                    CommandText = "checkPlate",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@ID", value);


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
        ///////////////////////////////// end Check_Exsit/////////////////////////////////////
        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<Plate> Plates)
        {

            OleDbConnection con;
            OleDbDataAdapter da;
            DataTable dt;
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a Excel File";
            op.Filter = "AllFiles | *.* | Excel Files |*.XLSX";
            if (op.ShowDialog() == true)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + op.FileName + "; Extended Properties=Excel 12.0");
                da = new OleDbDataAdapter("select * from [Plates$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Plate per = new Plate
                        {
                            Plate_id = Convert.ToInt32(row[0]),
                            Release_date = row[1].ToString(),
                            Vehicle_id = Convert.ToInt32(row[2]),
                            Plate_num = row[3].ToString(),
                            Plate_type = Convert.ToInt32(row[4]),
                            Status = Convert.ToInt32(row[5]),
                            Province_id = Convert.ToInt32(row[6])

                        };
                        OperarionPlate(per, "Insert");



                        Plates.Add(per); //الي بنربطه مع الجريد فيو
                    }
                    string message = "عدد السجلات المستوردة = " + dt.Rows.Count;
                    string caption = "عملية الاستيراد";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }


        }

        internal ObservableCollection<PlateOfType> GetplatType()
        {
            ObservableCollection<PlateOfType> plateOfTypes = new ObservableCollection<PlateOfType>();
            try
            {
                var result = isphelper.GetCollection(sP_Query.GetplateType, validationRegex.nameOfSp(sP_Query.GetplateType));
                if (result.Count > 0)
                {
                    foreach (DataRow row in result)
                    {
                        var platetype = new PlateOfType()
                        {
                            Plate_type_id = (int)row[0],
                            Plate_type_name = (string)row[1],
                        };

                        plateOfTypes.Add(platetype);
                    }
                }


            }
            catch (Exception)
            {

            }



            return plateOfTypes;
        }

        public RrivewViolation GetReviewOfplate(RrivewViolation rrivewViolation)
        {
            RrivewViolation rivewViolation = new RrivewViolation();

            try
            {
                Hashtable keys = new Hashtable();
                keys.Add("vehicleId", rrivewViolation.vehicleId);
                keys.Add("violationType", rrivewViolation.violationType);
                keys.Add("violationprov", rrivewViolation.violationprov);
                keys.Add("DateReview", rrivewViolation.DateReview);
                var param = isphelper.prpareParam(keys);
                var result = isphelper.GetCollectionByParam(sP_Query.Getreviewviolation, "Getreviewviolation", param);
                if (result.Data.Count <= 0)
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@vehicleId", SqlDbType.Int)
                    {
                        Value = rrivewViolation.vehicleId,
                    };
                    par[1] = new SqlParameter("@violationType", SqlDbType.NVarChar)
                    {
                        Value = rrivewViolation.violationType,

                    };
                    par[2] = new SqlParameter("@violationprov", SqlDbType.NVarChar)
                    {
                        Value = rrivewViolation.violationprov,
                    };

                    var res = isphelper.Operarion(par, opreationSql.opReviewViolation, "opReviewViolation");
                    return null;
                }
                else
                {
                    foreach (DataRow item in result.Data)
                    {
                        rivewViolation.DateReview = DateTime.Parse(Convert.ToString((DateTime)item[4]), CultureInfo.InvariantCulture).ToShortDateString();
                        ;
                    }
                }

            }
            catch (Exception)
            {

            }



            return rivewViolation;
        }
        /////////////////////////////////end GetExcel/////////////////////////////////////
    }
}
