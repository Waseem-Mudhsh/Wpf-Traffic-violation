using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models
{
    public class VehicleModel
    {
        public ObservableCollection<Vehicle> GetVehicles()
        {
            ObservableCollection<Vehicle> Vehicles = new ObservableCollection<Vehicle>();
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
                    CommandText = "GetVehicle",
                    Connection = con

                };
                DataTable dt1;
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Vehicle per = new Vehicle
                        {
                            Potty_id = (int)row[0],
                            Vehicle_engine_num = (int)row[1],
                            Vehicle_color = row[2].ToString(),
                            Vehicle_shape = row[3].ToString(),
                            Vehicle_model = row[4].ToString(),
                            Vehicle_customs_num = (int)row[5],
                            Company_manu_name = row[6].ToString(),
                            Status_v = (int)row[7],
                            Release_palc_c = (int)row[8],
                            Release_date_c = row[9].ToString()
                        };

                        dt1 = new VehicleModel().GetVehicle_card(per.Potty_id);

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow row1 in dt1.Rows)
                            {
                                per.Vehicle_card_id = (int)row1[0];
                                per.Release_date = row1[1].ToString();
                                per.Release_plase = (int)row1[2];
                                per.Citizen_id = (int)row1[3];
                                per.Noties = row1[4].ToString();
                                per.Status = (int)row1[5];
                                per.String_Provinces_vc = new Class_SqlConnection().Get_row("GetProvince_name", per.Release_plase);
                                per.String_Citizen = new Class_SqlConnection().Get_row("getCitizenName", per.Citizen_id);
                            }
                        }
                        per.String_Provinces = new Class_SqlConnection().Get_row("GetProvince_name", per.Release_palc_c);
                        
                        if (per.Status == 1)
                            per.String_Status = "نشطة";
                        else if (per.Status == 2)
                            per.String_Status = "منتهية";
                        else if (per.Status == 3)
                            per.String_Status = "مفقودة";

                        if (per.Status_v == 1)
                            per.String_Status_v = "نشطة";
                        else if(per.Status_v == 2)
                            per.String_Status_v = "غير نشط";

                        dt1 = null;

                        Vehicles.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }

            }
            return Vehicles;
        }


        public DataTable GetVehicle_card(int vehicle_id)
        {
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
                    CommandText = "GetVehicle_card",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@id", vehicle_id);
                DataTable dt2 = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt2);
                return dt2;
            }


        }

        ///////////////////////////////// start OperarionPlate/////////////////////////////////////

        public bool OperarionVehicle(Vehicle Vehicle, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[17];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Potty_id", SqlDbType.Int)
            {
                Value = Vehicle.Potty_id
            };
            param[1] = new SqlParameter("@Vehicle_engine_num", SqlDbType.Int)
            {
                Value = Vehicle.Vehicle_engine_num
            };
            param[2] = new SqlParameter("@Vehicle_color", SqlDbType.NVarChar, 10)
            {
                Value = Vehicle.Vehicle_color
            };
            param[3] = new SqlParameter("@Vehicle_shape", SqlDbType.NVarChar, 20)
            {
                Value = Vehicle.Vehicle_shape
            };
            param[4] = new SqlParameter("@Vehicle_model ", SqlDbType.NVarChar, 20)
            {
                Value = Vehicle.Vehicle_model
            };
            param[5] = new SqlParameter("@Vehicle_customs_num", SqlDbType.Int)
            {
                Value = Vehicle.Vehicle_customs_num
            };
            param[6] = new SqlParameter("@company_manu_name", SqlDbType.NVarChar, 30)
            {
                Value = Vehicle.Company_manu_name
            };
            param[7] = new SqlParameter("@Status_v", SqlDbType.Int)
            {
                Value = Vehicle.Status_v
            };
            param[8] = new SqlParameter("@Release_palc_c", SqlDbType.Int)
            {
                Value = Vehicle.Release_palc_c
            };
            param[9] = new SqlParameter("@Release_date_c", SqlDbType.NVarChar, 50)
            {
                Value = Vehicle.Release_date_c
            };
            param[10] = new SqlParameter("@Vehicle_card_id", SqlDbType.Int)
            {
                Value = Vehicle.Vehicle_card_id
            };
            param[11] = new SqlParameter("@Release_date", SqlDbType.NVarChar, 50)
            {
                Value = Vehicle.Release_date
            };
            param[12] = new SqlParameter("@Release_plase", SqlDbType.Int)
            {
                Value = Vehicle.Release_plase
            };
            param[13] = new SqlParameter("@Citizen_id", SqlDbType.Int)
            {
                Value = Vehicle.Citizen_id
            };
            param[14] = new SqlParameter("@Noties", SqlDbType.NVarChar, 50)
            {
                Value = Vehicle.Noties
            };
            param[15] = new SqlParameter("@Status ", SqlDbType.Int)
            {
                Value = Vehicle.Status
            };
            param[16] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opVehicle", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionPlate/////////////////////////////////////
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
                    CommandText = "checkVehicle",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@vehicle_id", value);


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



        public void GetExcel(ObservableCollection<Vehicle> Vehicles)
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
                da = new OleDbDataAdapter("select * from [Vehicle$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        Vehicle per = new Vehicle
                        {
                            Potty_id = Convert.ToInt32(row[0]),
                            Vehicle_engine_num = Convert.ToInt32(row[1]),
                            Vehicle_color = row[2].ToString(),
                            Vehicle_shape = row[3].ToString(),
                            Vehicle_model = row[4].ToString(),
                            Vehicle_customs_num = Convert.ToInt32(row[5]),
                            Company_manu_name = row[6].ToString(),
                            Status_v = Convert.ToInt32(row[7]),
                            Release_palc_c = Convert.ToInt32(row[8]),
                            Release_date_c = row[9].ToString(),
                            Vehicle_card_id = Convert.ToInt32(row[10]),
                            Release_date = row[11].ToString(),
                            Release_plase = Convert.ToInt32(row[12]),
                            Citizen_id = Convert.ToInt32(row[13]),
                            Noties = row[14].ToString(),
                            Status = Convert.ToInt32(row[15])
                        };
                        OperarionVehicle(per, "Insert");



                        Vehicles.Add(per); //الي بنربطه مع الجريد فيو
                    }
                    string message = "عدد السجلات المستوردة = " + dt.Rows.Count;
                    string caption = "عملية الاستيراد";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }


        }

        /////////////////////////////////end GetExcel/////////////////////////////////////
    }
}
