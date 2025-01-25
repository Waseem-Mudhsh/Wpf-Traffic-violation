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
using Wpf_Traffic_violation.Services;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models
{
    public class ViolationTypeModel
    {
        helper helper;
        DataTable dt;
        ValidationRegex validationRegex;
        Isphelper sphelper;
        SP_Query sP_ViolationType;
        OpreationSql opreationSql;
        ViolationServices violationServices;
        CacheManager<ViolationType> cacheManager;
        public ViolationTypeModel()
        {
            helper = new helper();
            validationRegex = new ValidationRegex();
            sphelper = new Sphelper();
            sP_ViolationType = new SP_Query();
            violationServices = new ViolationServices();
            opreationSql = new OpreationSql();
            cacheManager = new CacheManager<ViolationType>("ViolationType");
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetViolationTypes/////////////////////////////////////
        public ObservableCollection<ViolationType> GetViolationTypes()
        {
            ObservableCollection<ViolationType> ViolationTypes = new ObservableCollection<ViolationType>();
            //var result = sphelper.GetCollection(sP_ViolationType.SP_GetViolationTye, validationRegex.nameOfSp(sP_ViolationType.SP_GetViolationTye));
            //if (result.Count <= 0) return null;

            //foreach (DataRow row in result)
            //{
            //    ViolationType violationType = new ViolationType
            //    {
            //        Violation_type_id = (int)row[0],
            //        Violation_type_name = (string)row[1],
            //        Minimum_price = (int)row[2],
            //        Maximum_price = (int)row[3],
            //        Penalty = (int)row[4],
            //        Interception_status = (bool)row[5],
            //    };
            //    ViolationTypes.Add(violationType);

            //}

            //ViolationTypes = violationServices.GetViolationTypes();
            return ViolationTypes;

        }
        public ObservableCollection<ViolationType> GetViolationType()
        {

            //cacheManager.setCacheName("ViolationType");
            ObservableCollection<ViolationType> ViolationTypes = new ObservableCollection<ViolationType>();
            ObservableCollection<ViolationType> getviolatioType = cacheManager.GetCach as ObservableCollection<ViolationType>;
            if (getviolatioType != null)
            {
                ViolationTypes = getviolatioType;
            }
            else
            {
                var result = sphelper.GetCollection(sP_ViolationType.SP_GetViolationTye, validationRegex.nameOfSp(sP_ViolationType.SP_GetViolationTye));

                if (result.Count <= 0) return null;
                ViolationTypes = helper.GetViollationcollecttion(result);

                cacheManager.setkey(ViolationTypes);

            }




            //ViolationTypes = violationServices.GetViolationTypes();
            return ViolationTypes;
        }

        ///////////////////////////////// end GetViolationTypes/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start OperarionViolationType/////////////////////////////////////
        public bool OperarionViolationType(ViolationType violationType, string operartion)
        {


            SqlParameter[] param = new SqlParameter[7];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Violation_type_id", SqlDbType.Int)
            {
                Value = violationType.Violation_type_id
            };
            param[1] = new SqlParameter("@Violation_type_name", SqlDbType.NVarChar, 50)
            {
                Value = violationType.Violation_type_name
            };
            param[2] = new SqlParameter("@Minimum_price", SqlDbType.Int)
            {
                Value = violationType.Minimum_price
            };
            param[3] = new SqlParameter("@Maximum_price", SqlDbType.Int)
            {
                Value = violationType.Maximum_price
            };
            param[4] = new SqlParameter("@Penalty", SqlDbType.Int)
            {
                Value = (violationType.Penalty == 0) ? 1 : violationType.Penalty
            };
            param[5] = new SqlParameter("@Interception_status", SqlDbType.Bit)
            {
                Value = (violationType.Interception_status == false) ? true : violationType.Interception_status
            };

            param[6] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };
            var result = sphelper.Operarion(param, opreationSql.OperationViolationtype, "opViolationType");
            if (!result.Data)
            {
                cacheManager.Remove();
                return false;

            }
            else
            {
                cacheManager.Remove();

                return true;
            }

        }

        ///////////////////////////////// end string/////////////////////////////////////


        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<ViolationType> ViolationTypes)
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
                        ViolationType per = new ViolationType
                        {
                            Violation_type_id = Convert.ToInt32(row[0]),
                            Violation_type_name = row[1].ToString(),
                            Minimum_price = Convert.ToInt32(row[2]),
                            Maximum_price = Convert.ToInt32(row[3]),
                            Penalty = Convert.ToInt32(row[4]),
                            Interception_status = Convert.ToBoolean(row[0])
                        };

                        OperarionViolationType(per, "Insert");



                        ViolationTypes.Add(per); //الي بنربطه مع الجريد فيو
                    }
                    string message = "عدد السجلات المستوردة = " + dt.Rows.Count;
                    string caption = "عملية الاستيراد";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }


        }

        public Violation_type GetViolationTypeByName(string name)
        {
            cacheManager.setCacheName("ViolationType");
            Violation_type result = new Violation_type();
            try
            {
                ObservableCollection<ViolationType> getviolatioType = cacheManager.GetCach as ObservableCollection<ViolationType>;
                if (getviolatioType != null)
                {
                    foreach (ViolationType type in getviolatioType)
                    {
                        if (type.Violation_type_name == name.Trim())
                        {
                            result.Penalty = Convert.ToInt32(type.Penalty);
                            result.Maximum_price = Convert.ToInt32(type.Maximum_price);
                            result.Minimum_price = Convert.ToInt32(type.Minimum_price);
                            result.Violation_type_name = type.Violation_type_name;
                            result.Interception_status = Convert.ToInt32(type.Interception_status);
                            result.Violation_type_id = type.Violation_type_id;
                        }
                    }
                }
                else
                {
                    Hashtable key = new Hashtable();
                    key.Add("name", name);
                    var param = sphelper.prpareParam(key);
                    var violationTypes = sphelper.GetCollectionByParam(sP_ViolationType.GetViolationByName, "GetViolationByName", param);
                    var prepareVilatiotype = helper.GetViollationcollecttion(violationTypes.Data);
                    if (prepareVilatiotype.Count > 0)
                    {
                        foreach (var item in prepareVilatiotype)
                        {
                            result.Penalty = Convert.ToInt32(item.Penalty);
                            result.Maximum_price = Convert.ToInt32(item.Maximum_price);
                            result.Minimum_price = Convert.ToInt32(item.Minimum_price);
                            result.Violation_type_name = item.Violation_type_name;
                            result.Interception_status = Convert.ToInt32(item.Interception_status);
                            result.Violation_type_id = item.Violation_type_id;
                            break;
                        }

                    }
                    else
                    {
                        result = null;

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
