using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class Provinces_Model
    {
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetProvinces/////////////////////////////////////

        public void GetProvinces(ObservableCollection<Provinces> Provinces)
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
                    CommandText = "GetProvinces",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Provinces per = new Provinces
                        {
                            Province_id = (int)row[0],
                            Province_name = row[1].ToString(),



                        };

                        Provinces.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }


        }

        ///////////////////////////////// end GetProvinces/////////////////////////////////////
        public String GetProvinces_name(int Province_id)
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
                    CommandText = "GetProvinces_name",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Province_id", Province_id);
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





        ///////////////////////////////// end GetProvinces/////////////////////////////////////
    }
}
