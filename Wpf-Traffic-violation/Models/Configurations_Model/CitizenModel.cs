using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace Wpf_Traffic_violation.Models
{
    public class CitizenModel
    {

        ///////////////////////////////// start GetCitizens/////////////////////////////////////

        

        public void GetCitizens(ObservableCollection<Citizen> Citizens)
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
                    CommandText = "GetCitizens",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Citizen per = new Citizen
                        {
                            Citizen_id = (int)row[0],
                            Citizen_name = row[1].ToString(),
                            Citizen_address = row[2].ToString(),
                            Citizen_date_pirth = row[3].ToString(),
                            Citizen_religion = row[4].ToString(),
                            Citizen_blood_type = row[5].ToString(),
                            User_id = (int)row[6],
                            Citizen_nationality = row[7].ToString(),
                            String_gender = row[8].ToString(),
                            Citizen_identitytype = row[9].ToString(),
                            Citizen_phone = row[10].ToString(),
                            Citizen_social_status = (bool)row[11]
                        };
                        if (per.Citizen_social_status== true)
                        {
                            per.String_social_status = "عازب";
                        }
                        else
                        {
                            per.String_social_status = "متزوج";
                        }
                      
                        Citizens.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }

            }
        }
        ///////////////////////////////// end GetCitizens/////////////////////////////////////

        ///////////////////////////////// start Operarioncitizen/////////////////////////////////////

       

        public static bool OperarionCitizen(Citizen citizen, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[12];
 

            param[0] = new SqlParameter("@Citizen_id", SqlDbType.Int)
            {
                Value = citizen.Citizen_id
            };
            param[1] = new SqlParameter("@Citizen_name", SqlDbType.NVarChar, 50)
            {
                Value = citizen.Citizen_name
            };
            param[2] = new SqlParameter("@Citizen_address", SqlDbType.NVarChar, 50)
            {
                Value = citizen.Citizen_address
            };
            param[3] = new SqlParameter("@Citizen_date_pirth", SqlDbType.NVarChar,30)
            {
                Value = citizen.Citizen_date_pirth
            };
            param[4] = new SqlParameter("@Citizen_religion", SqlDbType.NVarChar,30)
            {
                Value = citizen.Citizen_religion
            };
            param[5] = new SqlParameter("@Citizen_blood_type", SqlDbType.NVarChar,5)
            {
                Value = citizen.Citizen_blood_type
            };
            param[6] = new SqlParameter("@Citizen_social_status", SqlDbType.Bit)
            {
                Value = citizen.Citizen_social_status
            };
           
            param[7] = new SqlParameter("@Citizen_nationality", SqlDbType.NVarChar,30)
            {
                Value = citizen.Citizen_nationality
            };
            param[8] = new SqlParameter("@Citizen_gender", SqlDbType.NVarChar, 30)
            {
                Value = citizen.String_gender
            };
            param[9] = new SqlParameter("@Citizen_identitytype", SqlDbType.NVarChar, 30)
            {
                Value = citizen.Citizen_identitytype
            };
            param[10] = new SqlParameter("@Citizen_phone", SqlDbType.NVarChar, 30)
            {
                Value = citizen.Citizen_phone
            };
            param[11] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opCitizen", param))
            {
                return false;

            }



            return true;
        }
        ///////////////////////////////// end Operarioncitizen/////////////////////////////////////

        /////////////////////////////////start Check_Exsit /////////////////////////////////////
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
                    CommandText = "checkcitizen",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Citizen_id", value);


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


        /////////////////////////////////end Check_Exsit/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start get_Directorate/////////////////////////////////////
        public void get_Directorate(ObservableCollection<String> Directorate,String city)
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
                    CommandText = "get_Directorate",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Directorate.Add(row[0].ToString()); //الي بنربطه مع الجريد فيو
                    }
                }

            }
        }
        ///////////////////////////////// end get_Directorate/////////////////////////////////////

        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<Citizen> Citizens)
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

                        Citizen per = new Citizen
                        {
                            Citizen_id = Convert.ToInt32(row[0]),
                            Citizen_name = row[1].ToString(),
                            Citizen_address = row[2].ToString(),
                            Citizen_date_pirth = row[3].ToString(),
                            Citizen_religion = row[4].ToString(),
                            Citizen_blood_type = row[5].ToString(),
                            User_id = Convert.ToInt32(row[6]),
                            Citizen_nationality = row[7].ToString(),
                            String_gender = row[8].ToString(),
                            Citizen_identitytype = row[9].ToString(),
                            Citizen_phone = row[10].ToString(),
                            Citizen_social_status = Convert.ToBoolean(row[11])
                        };
                        OperarionCitizen(per, "Insert");



                        Citizens.Add(per); //الي بنربطه مع الجريد فيو
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
