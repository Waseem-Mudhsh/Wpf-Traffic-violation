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
    public class ReasonsToObjection_Model
    {
        ///////////////////////////////// start GetReasonToObjection/////////////////////////////////////



        public ObservableCollection<ReasonsToObject> GetReasonToObjection()
        {
            ObservableCollection<ReasonsToObject> ReasonToobjections = new ObservableCollection<ReasonsToObject>();
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
                    CommandText = "GetReasonToObjection",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ReasonsToObject per = new ReasonsToObject
                        {
                            Reason_inter_id = (int)row[0],
                            Reason = row[1].ToString(),

                        };

                        ReasonToobjections.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }

            return ReasonToobjections;
        }

        ///////////////////////////////// end GetReasonToObjection/////////////////////////////////////
        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////

        public bool OperarionReasonToOblection(ReasonsToObject Reasons, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[3];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Reason_inter_id", SqlDbType.Int)
            {
                Value = Reasons.Reason_inter_id
            };
            param[1] = new SqlParameter("@Reason", SqlDbType.NVarChar, 50)
            {
                Value = Reasons.Reason
            };

            param[2] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opReasonToObjection", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionReasonToOblection/////////////////////////////////////

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
                    CommandText = "checkReasonToObjection",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Reason_inter_id", value);


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



        public void GetExcel(ObservableCollection<ReasonsToObject> ReasonsToObjects)
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

                        ReasonsToObject per = new ReasonsToObject
                        {
                            Reason_inter_id = Convert.ToInt32(row[0]),
                            Reason = row[1].ToString(),

                        };
                        OperarionReasonToOblection(per, "Insert");



                        ReasonsToObjects.Add(per); //الي بنربطه مع الجريد فيو
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
