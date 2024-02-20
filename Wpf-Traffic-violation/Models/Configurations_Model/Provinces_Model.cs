using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Core.helper;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class Provinces_Model
    {
        CacheManager<Provinces> cacheManager;
        Isphelper sphelper;
        SP_Query sP_Query;
        ValidationRegex validationRegex;
        public Provinces_Model()
        {
            validationRegex = new ValidationRegex();
            sphelper = new Directorates();
            sP_Query = new SP_Query();
            cacheManager = new CacheManager<Provinces>("Provinces");
        }
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetProvinces/////////////////////////////////////

        public ObservableCollection<Provinces> GetProvinces()
        {
            ObservableCollection<Provinces> Provinces = new ObservableCollection<Models.Provinces>();

            try
            {
                ObservableCollection<Provinces> getfromcach = cacheManager.GetCach as ObservableCollection<Provinces>;
                if (getfromcach != null)
                {
                    Provinces = getfromcach;
                }
                else
                {
                    var result = sphelper.GetCollection(sP_Query.Get_Province, validationRegex.nameOfSp(sP_Query.Get_Province));
                    if (result.Count > 0)
                    {
                        foreach (DataRow row in result)
                        {
                            Provinces per = new Provinces
                            {
                                Province_id = (int)row[0],
                                Province_name = row[1].ToString(),
                            };

                            Provinces.Add(per); //الي بنربطه مع الجريد فيو
                        }
                    }
                    cacheManager.setkey(Provinces);

                }

            }
            catch (Exception)
            {

            }

            return Provinces;
        }

        ///////////////////////////////// end GetProvinces/////////////////////////////////////
        public String GetProvinces_name(int Province_id)
        {

            try
            {
                ObservableCollection<Provinces> getfromcach = cacheManager.GetCach as ObservableCollection<Provinces>;
                if (getfromcach != null)
                {
                    foreach (var item in getfromcach)
                    {
                        if (item.Province_id == Province_id) return item.Province_name;

                    }
                }
                else
                {
                    Hashtable keys = new Hashtable();
                    keys.Add("Province_id", Province_id);
                    var getparam = sphelper.prpareParam(keys);
                    var result = sphelper.GetCollectionByParam(sP_Query.SP_getprovincNameById, validationRegex.nameOfSp(sP_Query.SP_getprovincById), getparam);
                    if (result.Data.Count > 0)
                    {
                        return result.Data[0][0].ToString();

                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return "غير موجود";
        }

        public String GetProvinces_nameBydirecterateId(int Directorate_id)
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
                    CommandText = "SELECT pro.Province_name from  [dbo].[Directorate] dire  with (nolock) \r\n inner join Province pro with (nolock) \r\n\t\t\t  on dire.Province_id=pro.Province_id\r\n\t\t\t\r\n\t\t\t  where Directorate_id= @Directorate_id",
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



        public Provinces GetProvincesById(int Province_id)
        {

            Response<Provinces> response = new Response<Provinces>();
            Provinces provinces = new Provinces();
            Hashtable keys = new Hashtable();

            keys.Add("Province_id", Province_id);
            var getparam = sphelper.prpareParam(keys);
            var result = sphelper.GetCollectionByParam(sP_Query.SP_getprovincById, validationRegex.nameOfSp(sP_Query.SP_getprovincById), getparam);

            if (!(result.Data.Count <= 0))
            {
                foreach (DataRow row in result.Data)
                {

                    provinces.Province_id = (int)row[0];
                    provinces.Province_name = row[1].ToString();

                }
                response.SetData(provinces);
            }
            else
            {
                response.Message = "غير موجود";

            }
            return response.Data;

        }



        ///////////////////////////////// end GetProvinces/////////////////////////////////////
    }
}
