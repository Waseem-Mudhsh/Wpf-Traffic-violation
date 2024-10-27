using System;
using System.Data.SqlClient;
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
            try
            {
                // Connection string to the database
                //string connectionString = "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True";

                // SQL backup command
                string backupCommand = $"BACKUP DATABASE Traffic_Violation_Management TO DISK = '{filename}'";

                // Execute the command
                using (con)
                {
                    SqlCommand command = new SqlCommand(backupCommand, con);
                    //con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Database backup completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while backing up the database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        public void restore(string filename)
        {

            try
            {
                SqlCommand d = new SqlCommand("ALTER DATABASE Traffic_Violation_Management SET OFFLINE WITH ROLLBACK IMMEDIATE;RESTORE DATABASE Traffic_Violation_Management FROM DISK='" + filename + "';ALTER DATABASE Traffic_Violation_Management SET ONLINE WITH ROLLBACK IMMEDIATE", con);
                d.ExecuteNonQuery();
                MessageBox.Show("تم إستعادة النسخة الإحتياطي بنجاح" + filename);
            }
            catch { MessageBox.Show("يوجد خطاء في إستعادة نسخة إحتياطي "); }

        }


    }
}
