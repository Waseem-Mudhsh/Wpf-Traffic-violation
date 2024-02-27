using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Core.DataBase.Storedprocedures;
using Wpf_Traffic_violation.MagrationDB;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models
{
    public class Street_Model
    {
        CacheManager<Streets> cacheManager;
        ValidationRegex validationRegex;
        ViolationServices violationServices;
        Provinces_Model provinces_Model;
        SP_Query sP_Query;
        Isphelper isphelper;
        OpreationSql opreationSql;
        public Street_Model()
        {
            validationRegex = new ValidationRegex();
            sP_Query = new SP_Query();
            violationServices = new ViolationServices();
            isphelper = new configuration();
            opreationSql = new OpreationSql();
            provinces_Model = new Provinces_Model();
            cacheManager = new CacheManager<Streets>("Street");
        }

        ///////////////////////////////// start GetStreets/////////////////////////////////////
        Directorate_Model directorate_Model = new Directorate_Model();
        public ObservableCollection<Streets> GetStreets()
        {
            ObservableCollection<Streets> Streets = new ObservableCollection<Models.Streets>();
            ObservableCollection<Streets> getStreetFromchach = cacheManager.GetCach as ObservableCollection<Streets>;

            if (getStreetFromchach != null)
            {
                Streets = getStreetFromchach;
            }
            else
            {
                var result = isphelper.GetCollection(sP_Query.GetSteetCollection, "GetStreets");
                if (result.Count > 0)
                {
                    foreach (DataRow row in result)
                    {
                        Streets per = new Streets
                        {
                            Street_id = (int)row[0],
                            Street_name = row[1].ToString(),
                            Directerate_id = (int)row[2]
                        };
                        per.Directerate_name = directorate_Model.GetDirectorate_name(per.Directerate_id);
                        per.Province_name = provinces_Model.GetProvinces_nameBydirecterateId(per.Directerate_id);
                        Streets.Add(per);
                    }
                    cacheManager.setkey(Streets);
                }


            }



            return Streets;
        }
        ///////////////////////////////// end GetStreets/////////////////////////////////////
        ///////////////////////////////// start OperarionDirectorate/////////////////////////////////////

        public bool OperarionStreets(Streets Street, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[4];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Street_id", SqlDbType.Int)
            {
                Value = Street.Street_id
            };
            param[1] = new SqlParameter("@Street_name", SqlDbType.NVarChar, 25)
            {
                Value = Street.Street_name
            };
            param[2] = new SqlParameter("@Directerate_id", SqlDbType.Int)
            {
                Value = Street.Directerate_id
            };

            param[3] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };


            if (!isphelper.Operarion(param, opreationSql.opStreets, "opStreets").Data)
            {
                return false;

            }
            cacheManager.Remove();
            return true;
        }
        ///////////////////////////////// end opTrafficMan/////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start Check_Exsit/////////////////////////////////////
        public bool Check_Exsit(int value)
        {
            Hashtable key = new Hashtable();
            key.Add("Operation", "GetStreet_name");
            key.Add("Id", value);
            var param = isphelper.prpareParam(key);
            var dt = isphelper.GetCollectionByParam(sP_Query.GetNamerow, "GetNamerow", param);

            if (dt.Data.Count > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        ///////////////////////////////// end Check_Exsit/////////////////////////////////////
        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<Streets> Streets)
        {

            OleDbConnection con;
            OleDbDataAdapter da;
            DataTable dt;
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a Excel File";
            op.Filter = " Excel Files |*.XLSX";
            if (op.ShowDialog() == true)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + op.FileName + "; Extended Properties=Excel 12.0");
                da = new OleDbDataAdapter("select * from [Street$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        Streets per = new Streets
                        {
                            Street_id = Convert.ToInt32(row[0]),
                            Street_name = row[1].ToString(),
                            Directerate_id = Convert.ToInt32(row[2])
                        };
                        OperarionStreets(per, "Insert");



                        Streets.Add(per); //الي بنربطه مع الجريد فيو
                    }
                    string message = "عدد السجلات المستوردة = " + dt.Rows.Count;
                    string caption = "عملية الاستيراد";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }


        }

        public Street GetStreetByName(string name)
        {
            var result = new Street();
            try
            {
                //cacheManager.setCacheName("Street");
                ObservableCollection<Streets> getstreet = cacheManager.GetCach as ObservableCollection<Streets>;
                if (getstreet != null)
                {
                    foreach (Streets str in getstreet)
                    {
                        if (Convert.ToString(str.Street_name) == name)
                        {
                            result.Street_id = str.Street_id;
                            result.Street_name = str.Street_name;
                            result.Directerate_id = str.Directerate_id;
                            break;
                        }

                    }

                }
                else
                {
                    Hashtable key = new Hashtable();
                    key.Add("name", name.Trim());
                    var param = isphelper.prpareParam(key);
                    var streets = isphelper.GetCollectionByParam(sP_Query.GetStreetbyName, "GetStreetbyId", param);

                    foreach (DataRow str in streets.Data)
                    {
                        if (Convert.ToString(str[1]) == name.Trim())
                        {
                            result.Street_id = (int)str[0];
                            result.Street_name = (string)str[1];
                            result.Directerate_id = (int)str[2];
                            break;
                        }

                    }


                }

            }
            catch (Exception)
            {

            }
            return result;
        }

        /////////////////////////////////end GetExcel/////////////////////////////////////
    }
}
