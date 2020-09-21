using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models
{
    class Class_SqlConnection
    {
        public SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        public bool Operarion(String Stored_Procedure,SqlParameter[] Param)
        {
            
            using (con)
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cant Open Conncation");

                }
                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = Stored_Procedure,
                    Connection = con

                };
               if(Param != null)
                {
                    Command.Parameters.AddRange(Param);
                    
                }

                try { 
                if (Command.ExecuteNonQuery() == 0)
                {


                    return false;

                }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                }
            }


            return true;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////// start Get_row/////////////////////////////////////
        public String Get_row(String storad, int id)
        {
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
                    CommandText = storad,
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Id", id);

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
        /////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// end Get_row/////////////////////////////////////


        ///////////////////////////////// start Get_row/////////////////////////////////////
        public int Get_number(String storad, int id)
        {
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
                    CommandText = storad,
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Id", id);

                dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);

            }
            if (dt.Rows.Count > 0)
            {

                return (int)dt.Rows[0][0];

            }

            return 0;
        }
        /////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// end Get_row/////////////////////////////////////



        ///////////////////////////////// start Get_Max/////////////////////////////////////
        public int Get_Max(string tableName)
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
                    CommandText = "getMaxId",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@TableName",tableName);
             
                dt = new DataTable();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);

            }
            
            if (dt.Rows.Count > 0)
            {
              
                    return (int)dt.Rows[0][0];

            }

            return 0;
        }
        /////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// end Get_Max/////////////////////////////////////

        public DataTable GetData(string Stored_Procedure, SqlParameter[] Param)
        {
            DataTable dt = new DataTable();

           // string connstr = @"Data Source=ENG-IPRAHIM_A_M\MSSQLSERVER17;Initial Catalog=Traffic_Violation_Management;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"))
            {

                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = Stored_Procedure,
                    Connection = con
                };
                if (Param != null)
                {
                    cmd.Parameters.AddRange(Param);

                }


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            return dt;
        }
    }

}
 