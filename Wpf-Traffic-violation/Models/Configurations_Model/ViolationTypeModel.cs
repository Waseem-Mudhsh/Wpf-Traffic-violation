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
    public class ViolationTypeModel
    {

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetViolationTypes/////////////////////////////////////
        public void GetViolationTypes(ObservableCollection<ViolationType> ViolationTypes)
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
                    CommandText = "GetViolationTypes",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ViolationType per = new ViolationType
                        {
                            Violation_type_id = (int)row[0],
                            Violation_type_name = row[1].ToString(),
                            Minimum_price = (int)row[2],
                            Maximum_price = (int)row[3],
                            Penalty = (int)row[4],
                            Interception_status = (bool)row[5]
                        };

                        ViolationTypes.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }

            }
        }
        ///////////////////////////////// end GetViolationTypes/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start OperarionViolationType/////////////////////////////////////
        public bool OperarionViolationType(ViolationType violationType, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[7];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Violation_type_id", SqlDbType.Int)
            {
                Value = violationType.Violation_type_id
            };
            param[1] = new SqlParameter("@Violation_type_name", SqlDbType.NVarChar, 50)
            {
                Value = violationType.Violation_type_name
            };
            param[2] = new SqlParameter("@Minimum_price", SqlDbType.Int)
            {
                Value = violationType.Minimum_price
            };
            param[3] = new SqlParameter("@Maximum_price", SqlDbType.Int)
            {
                Value = violationType.Maximum_price
            };
            param[4] = new SqlParameter("@Penalty", SqlDbType.Int)
            {
                Value = violationType.Penalty
            };
            param[5] = new SqlParameter("@Interception_status", SqlDbType.Bit)
            {
                Value = violationType.Interception_status
            };

            param[6] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opViolationType", param))
            {
                return false;

            }
            return true;
        }

        ///////////////////////////////// end string/////////////////////////////////////


        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<ViolationType> ViolationTypes)
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
                        ViolationType per = new ViolationType
                        {
                            Violation_type_id = Convert.ToInt32(row[0]),
                            Violation_type_name = row[1].ToString(),
                            Minimum_price = Convert.ToInt32(row[2]),
                            Maximum_price = Convert.ToInt32(row[3]),
                            Penalty = Convert.ToInt32(row[4]),
                            Interception_status = Convert.ToBoolean(row[0])
                        };

                        OperarionViolationType(per, "Insert");



                        ViolationTypes.Add(per); //الي بنربطه مع الجريد فيو
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
