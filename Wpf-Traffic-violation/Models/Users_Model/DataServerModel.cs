using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models.Users_Model
{
   public class DataServerModel
    {
        SqlConnection con;

        public DataServerModel()
        {
             con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("Cant Open con");
            }


        }
        public void setBackup(string filename)
        {
           
            //Class_SqlConnection sql = new Class_SqlConnection();
            using (con)
            {
                
                 SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "BACKUP DATABASE Traffic_Violation_Management TO DISK='" + filename + ".BAK'",
                    Connection = con

                };

                 Command.ExecuteNonQuery();
                     MessageBox.Show("تم عمل نسخة إحتياطي بنجاح" + filename);
            }

        }


        public void restore(string filename)
        {

            try
            {
                SqlCommand d = new SqlCommand("ALTER DATABASE Traffic_Violation_Management SET OFFLINE WITH ROLLBACK IMMEDIATE;RESTORE DATABASE Traffic_Violation_Management FROM DISK='" + filename+ "';ALTER DATABASE Traffic_Violation_Management SET ONLINE WITH ROLLBACK IMMEDIATE", con);
                d.ExecuteNonQuery();
                MessageBox.Show("تم إستعادة النسخة الإحتياطي بنجاح" + filename);
            }
            catch { MessageBox.Show("يوجد خطاء في إستعادة نسخة إحتياطي "); }

        }


    }
}
