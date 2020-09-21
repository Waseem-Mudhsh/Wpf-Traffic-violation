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
    public class ActivityModel
    {
        ///////////////////////////////// start GetActivitys/////////////////////////////////////
      //  ObservableCollection<Activity> Activitys = new ObservableCollection<Activity>();


        public void GetActivitys(ObservableCollection<Activity> Activitys)
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
                    CommandText = "GetActivitys",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow row in dt.Rows)
                    {
                        Activity per = new Activity
                        {   Activity_id= (int)row[0],
                            User_id = (int)row[1],
                            Form_id = (int)row[2],
                            Activity_operation_num = (int)row[3],
                            Activity_record_num = (int)row[4],
                            Activity_date = row[5].ToString(),
                          
                        };
                        if (per.Activity_operation_num == 1)
                        {
                            per.String_Activity_operation_num= "اضافة";
                        }
                        else if (per.Activity_operation_num == 2)
                        {
                            per.String_Activity_operation_num = "تعديل";
                        }
                        else if (per.Activity_operation_num == 3)
                        {
                            per.String_Activity_operation_num = "حذف";
                        }

                        Activitys.Add(per); 
                    }
                }
              
            }
        }
        ///////////////////////////////// end GetActivitys/////////////////////////////////////


        ///////////////////////////////// start OperarionActivity/////////////////////////////////////

        public bool OperarionActivity(Activity Activity, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@Activity_id", SqlDbType.Int)
            {
                Value = Activity.Activity_id
            };
            param[1] = new SqlParameter("@User_id", SqlDbType.Int)
            {
                Value = Activity.User_id
            };
            param[2] = new SqlParameter("@Form_id", SqlDbType.Int)
            {
                Value = Activity.Form_id
            };
            param[3] = new SqlParameter("@Activity_operation_num", SqlDbType.Int)
            {
                Value = Activity.Activity_operation_num
            };
            param[4] = new SqlParameter("@Activity_record_num", SqlDbType.Int)
            {
                Value = Activity.Activity_record_num
            };
            param[5] = new SqlParameter("@Activity_date", SqlDbType.NVarChar, 50)
            {
                Value = Activity.Activity_date
            };
            param[6] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };
            if (!sql.Operarion("opActivity", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionReasonToOblection/////////////////////////////////////

    }
}
