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

                if (Command.ExecuteNonQuery() == 0)
                {


                    return false;

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

    }

}
