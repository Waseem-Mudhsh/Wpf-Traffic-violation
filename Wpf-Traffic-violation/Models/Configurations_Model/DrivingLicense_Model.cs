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

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class DrivingLicense_Model
    {
        //Citizen citizen = new Citizen();
        //CategoriesOfLicenses_Model class_license = new CategoriesOfLicenses_Model();


        ///////////////////////////////// start GetPlates/////////////////////////////////////

        public ObservableCollection<DrivingLicense> GetDrivingLicenses()
        {
            ObservableCollection<DrivingLicense> DrivingLicenses = new ObservableCollection<DrivingLicense>();
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
                    CommandText = "GetDeivingLicense",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DrivingLicense per = new DrivingLicense
                        {
                            Driving_license_id = (int)row[0],
                            Release_date = row[1].ToString(),
                            Citizen_id = (int)row[2],
                            Class_license_id = (int)row[3],
                            Date_frist_license = row[4].ToString(),
                            Driving_license_notice = row[5].ToString(),
                            Status = row[6].ToString()

                        };
                        per.String_citizen = new Class_SqlConnection().Get_row("getCitizenName", per.Citizen_id);

                        per.String_Class_license = new Class_SqlConnection().Get_row("GetClass_license_name", per.Class_license_id);

                        DrivingLicenses.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }
            return DrivingLicenses;

        }
        ///////////////////////////////// end GetPlates/////////////////////////////////////
        ///////////////////////////////// start OperarionPlate/////////////////////////////////////

        public bool OperarionDrivingLicense(DrivingLicense DrivingLicenses, string operartion)
        {
            if (string.IsNullOrWhiteSpace(DrivingLicenses.Driving_license_notice))
            {
                DrivingLicenses.Driving_license_notice = "لا شي";
            }
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[8];
            

            param[0] = new SqlParameter("@Driving_license_id", SqlDbType.Int)
            {
                Value = DrivingLicenses.Driving_license_id
            };
            param[1] = new SqlParameter("@Release_date", SqlDbType.NVarChar, 50)
            {
                Value = DrivingLicenses.Release_date
            };
            param[2] = new SqlParameter("@Citizen_id", SqlDbType.Int)
            {
                Value = DrivingLicenses.Citizen_id
            };
            param[3] = new SqlParameter("@Class_license_id", SqlDbType.Int)
            {
                Value = DrivingLicenses.Class_license_id
            };
            param[4] = new SqlParameter("@Date_frist_license", SqlDbType.NVarChar, 50)
            {
                Value = DrivingLicenses.Date_frist_license
            };
            param[5] = new SqlParameter("@Driving_license_notice", SqlDbType.NVarChar,50)
            {
                Value = DrivingLicenses.Driving_license_notice
            };
            param[6] = new SqlParameter("@Status", SqlDbType.NVarChar, 10)
            {
                Value = DrivingLicenses.Status
            };

            param[7] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opDirivnglicense", param))
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
                    CommandText = "checkDrivingLicense",
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



        public void GetExcel(ObservableCollection<DrivingLicense> DrivingLicenses)
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
                da = new OleDbDataAdapter("select * from [DrivingLicenses$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        DrivingLicense per = new DrivingLicense
                        {
                            Driving_license_id = Convert.ToInt32(row[0]),
                            Release_date = row[1].ToString(),
                            Citizen_id = Convert.ToInt32(row[2]),
                            Class_license_id = Convert.ToInt32(row[3]),
                            Date_frist_license = row[4].ToString(),
                            Driving_license_notice = row[5].ToString(),
                            Status = row[6].ToString(),

                        };
                        OperarionDrivingLicense(per, "Insert");



                        DrivingLicenses.Add(per); //الي بنربطه مع الجريد فيو
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
