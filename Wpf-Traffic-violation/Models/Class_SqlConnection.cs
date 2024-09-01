using System;
using System.Data;
using System.Data.SqlClient;
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models
{
    class Class_SqlConnection
    {
        public SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        ValidationRegex validationRegex;
        ViolationServices violationServices;
        SP_Query sP_Query;
        Isphelper isphelper;
        public Class_SqlConnection()
        {
            validationRegex = new ValidationRegex();
            sP_Query = new SP_Query();
            violationServices = new ViolationServices();
            isphelper = new Sphelper();
        }
        public bool Operarion(String Stored_Procedure, SqlParameter[] Param)
        {





            return true;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////// start Get_row/////////////////////////////////////
        public String Get_row(String storad, int id)
        {
            var result = isphelper.GetNameOfRow(sP_Query.GetNamerow, storad, "GetNamerow", id);



            if (result.Count > 0)
            {

                return result[0][0].ToString();

            }

            return "غير موجود";
        }
        /////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// end Get_row/////////////////////////////////////


        ///////////////////////////////// start Get_row/////////////////////////////////////
        public int Get_number(String storad, int id)
        {
            //var response= isphelper(sP_Query.GetNamerow, storad, "GetNamerow", id);

            // using (con)
            // {
            //     try
            //     {
            //         con.Open();
            //     }
            //     catch (Exception)
            //     {

            //         MessageBox.Show("Cant Open con");
            //     }

            //     SqlCommand Command = new SqlCommand
            //     {
            //         CommandType = CommandType.StoredProcedure,
            //         CommandText = storad,
            //         Connection = con

            //     };
            //     Command.Parameters.AddWithValue("@Id", id);

            //     dt = new DataTable();
            //     SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
            //     dataAdapter.Fill(dt);

            // }
            // if (dt.Rows.Count > 0)
            // {

            //     return (int)dt.Rows[0][0];

            // }

            return 0;
        }
        /////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// end Get_row/////////////////////////////////////



        ///////////////////////////////// start Get_Max/////////////////////////////////////
        public int Get_Max(string tableName, string colmnName = null)
        {

            try
            {
                var result = isphelper.GetMax(sP_Query.getMaxId, validationRegex.nameOfSp(sP_Query.getMaxId), tableName, colmnName);
                if (result.Count > 0)
                {

                    return Convert.ToInt32(result[0][0]); ;

                }

            }
            catch (Exception ex)
            {

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
