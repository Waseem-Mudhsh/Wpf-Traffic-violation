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
using Wpf_Traffic_violation.Models.Configurations_Model;

namespace Wpf_Traffic_violation.Models
{
    public class Directorate_Model
    {
        Provinces_Model provinces_model = new Provinces_Model();
        ///////////////////////////////// start GetDirectorate/////////////////////////////////////

        public void GetDirectorate(ObservableCollection<Directorate> Directorates)
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

                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetDirectorate",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Directorate per = new Directorate
                        {
                            Directorate_id = (int)row[0],
                            Directorate_name = row[1].ToString(),
                            Province_id = (int)row[2]



                        };
                        per.Province_name = provinces_model.GetProvinces_name(per.Province_id);

                        Directorates.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }


        }
        ///////////////////////////////// end GetDirectorate/////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start OperarionDirectorate/////////////////////////////////////

        public bool OperarionDirectorate(Directorate directorate, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[4];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Directorate_id", SqlDbType.Int)
            {
                Value = directorate.Directorate_id
            };
            param[1] = new SqlParameter("@Directorate_name", SqlDbType.NVarChar, 20)
            {
                Value = directorate.Directorate_name
            };
            param[2] = new SqlParameter("@Province_id", SqlDbType.NVarChar, 50)
            {
                Value = directorate.Province_id
            };

            param[3] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opDirectorate", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end opTrafficMan/////////////////////////////////////
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
                    CommandText = "checkDirectorate",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Directorate_id", value);


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

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetDirectorate_name/////////////////////////////////////

        public String GetDirectorate_name(int Directorate_id)
        {
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            DataTable dt;
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
                    CommandText = "GetDirectorate_name",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Directorate_id", Directorate_id);
                dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();


            }
            return "غير موجود";
        }



        ///////////////////////////////// end GetDirectorate_name/////////////////////////////////////



        ///////////////////////////////// end GetProvinces/////////////////////////////////////
        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<Directorate> Directorates)
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
                da = new OleDbDataAdapter("select * from [page$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        Directorate per = new Directorate
                        {
                            Directorate_id = Convert.ToInt32(row[0]),
                            Directorate_name = row[1].ToString(),
                            Province_id = Convert.ToInt32(row[2])



                        };
                        OperarionDirectorate(per, "Insert");



                        Directorates.Add(per); //الي بنربطه مع الجريد فيو
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
