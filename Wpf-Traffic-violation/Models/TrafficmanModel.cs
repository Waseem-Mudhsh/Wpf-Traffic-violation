using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models
{
     class TrafficmanModel
    {
        public void GetTrafficMans(ObservableCollection<TrafficMan> TrafficMans)
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
                    CommandText = "GetTrafficMans",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        TrafficMan per = new TrafficMan
                        {
                            Traffic_man_id = (int)row[0],
                            Traffic_man_name = row[1].ToString(),
                            User_id = (int)row[2],
                            Traffic_man_grade = row[3].ToString(),
                            Status = (int)row[4]

                        };
                        //if (per.Usertype == 1)
                        //{
                        //    per.String_usertype = "النظام";
                        //}
                        //else
                        //{
                        //    per.String_usertype = "التطبيق";
                        //}
                        //if (per.Userstatus == 1)
                        //{
                        //    per.String_userstatus = "نشط";
                        //}
                        //else
                        //{
                        //    per.String_userstatus = "غير نشط";
                        //}
                        TrafficMans.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }


        }
     }
}
