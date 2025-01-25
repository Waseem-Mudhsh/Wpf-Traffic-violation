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
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models
{
    public class PlateOfType_Model
    {
        //SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        CacheManager<PlateOfType> cacheManager;
        ValidationRegex validationRegex;
        ViolationServices violationServices;
        SP_Query sP_Query;
        Isphelper isphelper;
        OpreationSql opreationSql;

        public PlateOfType_Model()
        {
            validationRegex = new ValidationRegex();
            sP_Query = new SP_Query();
            violationServices = new ViolationServices();
            isphelper = new Sphelper();
            opreationSql = new OpreationSql();
            cacheManager = new CacheManager<PlateOfType>("platetype");
        }
        ///////////////////////////////// start GetPlateOfType/////////////////////////////////////



        public ObservableCollection<PlateOfType> GetPlateOfType()
        {
            ObservableCollection<PlateOfType> PlateOfTypes = new ObservableCollection<PlateOfType>();

            try
            {
                ObservableCollection<PlateOfType> plattypechach = new ObservableCollection<PlateOfType>();
                ObservableCollection<PlateOfType> getplatypechach = cacheManager.GetCach as ObservableCollection<PlateOfType>;
                if (getplatypechach != null)
                {
                    PlateOfTypes = getplatypechach;
                }
                else
                {
                    var result = isphelper.GetCollection(sP_Query.GetplateType, validationRegex.nameOfSp(sP_Query.GetplateType));
                    if (result.Count > 0)
                    {
                        foreach (DataRow row in result)
                        {
                            var platetype = new PlateOfType()
                            {
                                Plate_type_id = (int)row[0],
                                Plate_type_name = (string)row[1],
                            };

                            PlateOfTypes.Add(platetype);
                        }
                    }

                    cacheManager.setkey(PlateOfTypes);

                }



            }
            catch (Exception)
            {

            }

            return PlateOfTypes;
        }

        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////
        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////

        public bool OperarionPlateOfType(PlateOfType Plates, string operartion)
        {
            bool response = false;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                //@user_id, @user_name, @user_pass, @user_type, @user_status

                param[0] = new SqlParameter("@Plate_type_id", SqlDbType.Int)
                {
                    Value = Plates.Plate_type_id
                };
                param[1] = new SqlParameter("@Plate_type_name", SqlDbType.NVarChar, 15)
                {
                    Value = Plates.Plate_type_name
                };

                param[2] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
                {
                    Value = operartion
                };

                var result = isphelper.Operarion(param, opreationSql.Sp_PlateTypeOperation, validationRegex.nameOfSp(opreationSql.Sp_PlateTypeOperation));

                if (result.Data)
                {
                    response = false;

                }
                cacheManager.Remove();
                response = true;

            }
            catch (Exception)
            {

            }

            return response;


        }
        ///////////////////////////////// end OperarionReasonToOblection/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start Check_Exsit/////////////////////////////////////
        public bool Check_Exsit(int value)
        {
            try
            {
                Hashtable keys = new Hashtable();
                keys.Add("Plate_type_id", value);
                var param = isphelper.prpareParam(keys);
                var result = isphelper.GetCollectionByParam(sP_Query.GetplateTypeById, validationRegex.nameOfSp(sP_Query.GetplateTypeById), param);
                if (result.Data.Count > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

            }
            return false;

        }
        ///////////////////////////////// end Check_Exsit/////////////////////////////////////
        public String GetPlatetype_name(int Plate_type_id)
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
                    CommandText = "GetPlatetype_name",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@GetPlatetype_id", Plate_type_id);
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

        public PlateOfType GetPlateByName(string name)
        {
            cacheManager.setCacheName("platetype");
            PlateOfType result = new PlateOfType();
            ObservableCollection<PlateOfType> getplatypechach = cacheManager.GetCach as ObservableCollection<PlateOfType>;
            if (getplatypechach != null)
            {
                foreach (var item in getplatypechach)
                {
                    if (item.Plate_type_name.Trim() == name.Trim())
                    {
                        result.Plate_type_id = item.Plate_type_id;
                        result.Plate_type_name = item.Plate_type_name;
                        break;

                    }

                }
            }
            else
            {
                Hashtable key = new Hashtable();
                key.Add("nameType", name.Trim());
                var parm = isphelper.prpareParam(key);
                var platsype = isphelper.GetCollectionByParam(sP_Query.GetplatypeByName, "GetplatypeByName", parm);

                if (platsype != null)
                {
                    foreach (DataRow row in platsype.Data)
                    {
                        if ((string)row[1] == name.Trim())
                        {
                            result.Plate_type_id = (int)row[0];
                            result.Plate_type_name = (string)row[1];
                            break;
                        }

                    }
                }

            }
            return result;
        }

        ///////////////////////////////// end GetDirectorate_name/////////////////////////////////////

        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<PlateOfType> PlateOfTypes)
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

                        PlateOfType per = new PlateOfType
                        {
                            Plate_type_id = Convert.ToInt32(row[0]),
                            Plate_type_name = row[1].ToString(),

                        };
                        OperarionPlateOfType(per, "Insert");



                        PlateOfTypes.Add(per); //الي بنربطه مع الجريد فيو
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
