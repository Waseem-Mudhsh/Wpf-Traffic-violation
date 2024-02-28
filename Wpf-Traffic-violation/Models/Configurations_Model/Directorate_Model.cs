using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Core.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models
{
    public class Directorate_Model
    {
        Provinces_Model provinces_model = new Provinces_Model();
        ///////////////////////////////// start GetDirectorate/////////////////////////////////////
        Isphelper sphelper;
        OpreationSql opreationSql;
        SP_Query sP_Query;
        ValidationRegex validationRegex;
        CacheManager<Directorate> cacheManager;
        CacheManager<Provinces> cacheManagerprov;
        public Directorate_Model()
        {
            opreationSql = new OpreationSql();
            validationRegex = new ValidationRegex();
            sphelper = new Directorates();
            sP_Query = new SP_Query();
            cacheManager = new CacheManager<Directorate>("Directorate");
            cacheManagerprov = new CacheManager<Provinces>("Provinces");


        }
        public ObservableCollection<Directorate> GetDirectorate()
        {
            ObservableCollection<Directorate> Directorates = new ObservableCollection<Directorate>();
            ObservableCollection<Directorate> getfromCach = cacheManager.GetCach as ObservableCollection<Directorate>;
            if (getfromCach != null)
            {
                Directorates = getfromCach;
            }
            else
            {
                var result = sphelper.GetCollection(sP_Query.SP_GetDirectorate, validationRegex.nameOfSp(sP_Query.SP_GetDirectorate));
                foreach (DataRow row in result)
                {
                    Directorate per = new Directorate
                    {
                        Directorate_id = (int)row[0],
                        Directorate_name = row[1].ToString(),
                        Province_id = (int)row[2]

                    };
                    per.Province_name = provinces_model.GetProvincesById(per.Province_id).Province_name;

                    Directorates.Add(per); //الي بنربطه مع الجريد فيو
                }
                cacheManager.setkey(Directorates);

            }
            return Directorates;
        }
        ///////////////////////////////// end GetDirectorate/////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start OperarionDirectorate/////////////////////////////////////

        public bool OperarionDirectorate(Directorate directorate, string operartion)
        {
            //Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[4];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Directorate_id", SqlDbType.Int)
            {
                Value = directorate.Directorate_id
            };
            param[1] = new SqlParameter("@Directorate_name", SqlDbType.NVarChar, 20)
            {
                Value = directorate.Directorate_name
            };
            param[2] = new SqlParameter("@Province_name", SqlDbType.NVarChar, 50)
            {
                Value = directorate.Province_name
            };

            param[3] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };
            var response = sphelper.Operarion(param, opreationSql.SP_Director_Opreation, validationRegex.nameOfSp(opreationSql.SP_Director_Opreation));
            if (response.Code != -1)
            {
                return false;
            }
            cacheManager.Remove();
            cacheManagerprov.Remove();
            GetDirectorate();
            provinces_model.GetProvinces();

            return true;
        }
        ///////////////////////////////// end opTrafficMan/////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start Check_Exsit/////////////////////////////////////
        public bool Check_Exsit(int value)
        {
            //Class_SqlConnection sql = new Class_SqlConnection();
            //using (sql.con)
            //{
            //    try
            //    {
            //        sql.con.Open();
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Cant Open Conncation");

            //    }
            //    SqlCommand Command = new SqlCommand
            //    {
            //        CommandType = CommandType.StoredProcedure,
            //        CommandText = "checkDirectorate",
            //        Connection = sql.con

            //    };
            //    Command.Parameters.AddWithValue("@Directorate_id", value);


            //    DataTable dt = new DataTable();
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
            //    dataAdapter.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        return true;
            //    }

            //    else
            //    {
            //        return false;
            //    }


            //}

            return false;
        }
        ///////////////////////////////// end Check_Exsit/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetDirectorate_name/////////////////////////////////////

        public String GetDirectorate_name(int Directorate_id)
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
                    CommandType = CommandType.Text,
                    CommandText = "SELECT [Directorate_name]FROM [dbo].[Directorate]  where Directorate_id= @Directorate_id",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Directorate_id", Directorate_id);
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


        ///////////////////////////////// end GetDirectorate_name/////////////////////////////////////



        ///////////////////////////////// end GetProvinces/////////////////////////////////////
        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<Directorate> Directorates)
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
                da = new OleDbDataAdapter("select * from [Directorate$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        Directorate per = new Directorate
                        {
                            Directorate_id = Convert.ToInt32(row[0]),
                            Directorate_name = row[1].ToString(),
                            Province_id = Convert.ToInt32(row[2])



                        };
                        OperarionDirectorate(per, "Insert");



                        Directorates.Add(per); //الي بنربطه مع الجريد فيو
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
