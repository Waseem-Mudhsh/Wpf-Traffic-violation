using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models.Users_Model
{
    public class PermissionUserModel
    {
        ///////////////////////////////// start GetPermissionUser/////////////////////////////////////
        Isphelper sphelper;
        SP_Query sP_Query;
        ValidationRegex validationRegex;
        public PermissionUserModel()
        {
            validationRegex = new ValidationRegex();
            sphelper = new configuration();
            sP_Query = new SP_Query();
        }
        public ObservableCollection<PermissionUser> GetPermissionUser(string menu, int user_Id)
        {
            ObservableCollection<PermissionUser> PermissionUsers = new ObservableCollection<PermissionUser>();
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

                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetPermissionUser",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@menu", menu);
                Command.Parameters.AddWithValue("@user_id", user_Id);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PermissionUser per = new PermissionUser
                        {
                            User_id = (int)row[0],
                            Form_id = (int)row[1],
                            Add_opretion = (bool)row[2],
                            Delete_opretion = (bool)row[3],
                            Update_opretion = (bool)row[4],
                            Select_opretion = (bool)row[5],
                            Form = (bool)row[6]

                        };
                        per.String_Id = new Class_SqlConnection().Get_row("getUserName", per.User_id);
                        per.String_form = new Class_SqlConnection().Get_row("getFormName", per.Form_id);

                        PermissionUsers.Add(per);
                    }
                }
            }
            return PermissionUsers;

        }
        ///////////////////////////////// end GetPermissionGroup/////////////////////////////////////

        ///////////////////////////////// start OperarionPermissionGroup/////////////////////////////////////

        public bool OperarionPermissionUser(PermissionUser PermissionUser, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[8];


            param[0] = new SqlParameter("@User_id", SqlDbType.Int)
            {
                Value = PermissionUser.User_id
            };
            param[1] = new SqlParameter("@Form_id", SqlDbType.Int)
            {
                Value = PermissionUser.Form_id
            };
            param[2] = new SqlParameter("@Add_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Add_opretion
            };
            param[3] = new SqlParameter("@Delete_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Delete_opretion
            };
            param[4] = new SqlParameter("@Update_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Update_opretion
            };
            param[5] = new SqlParameter("@Select_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Select_opretion
            };
            param[6] = new SqlParameter("@Form", SqlDbType.Bit)
            {
                Value = PermissionUser.Form
            };
            param[7] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opPermissionUser", param))
            {
                return false;

            }
            return true;
        }

        public ObservableCollection<MenuDto> GetMenu()
        {
            ObservableCollection<MenuDto> GetAllMenu = new ObservableCollection<MenuDto>();

            var response = sphelper.GetCollection(sP_Query.GetAllMenu, "GetAllMenu");
            if (response.Count > 0)
            {
                foreach (DataRow row in response)
                {
                    MenuDto per = new MenuDto
                    {
                        Menu_id = (int)row[0],
                        Menu_name = (string)row[1],

                    };


                    //}
                    GetAllMenu.Add(per); //الي بنربطه مع الجريد فيو
                }
            }
            return GetAllMenu;
        }
        public ObservableCollection<MenuDetail> GetMenuDetl()
        {
            ObservableCollection<MenuDetail> GetAllMenuDetl = new ObservableCollection<MenuDetail>();

            var response = sphelper.GetCollection(sP_Query.GetAllMenuDetl, "GetAllMenuDetl");
            if (response.Count > 0)
            {
                foreach (DataRow row in response)
                {
                    MenuDetail per = new MenuDetail
                    {

                        ID = (int)row[0],
                        menu_id = (int)row[1],
                        User_type_id = (int)row[2],
                        is_active = (bool)row[3]


                    };


                    //}
                    GetAllMenuDetl.Add(per); //الي بنربطه مع الجريد فيو
                }
            }
            return GetAllMenuDetl;
        }
        public ObservableCollection<FormModel> GetFormBymenuid(int menuId)
        {
            ObservableCollection<FormModel> GetAllMenuDetl = new ObservableCollection<FormModel>();

            Hashtable keys = new Hashtable();
            keys.Add("menuId", menuId);
            var getparam = sphelper.prpareParam(keys);
            var result = sphelper.GetCollectionByParam(sP_Query.GetFormBymenuid, "GetFormBymenuid", getparam);
            if (result.Data.Count > 0)
            {
                foreach (DataRow row in result.Data)
                {
                    FormModel per = new FormModel
                    {
                        FormId = (int)row[0],
                        FormName = (string)row[1],
                        MenuId = (int)row[2],
                        FormType = (int)row[3],
                        //Code = ((string)row[4] == null) ? "" : (string)row[4]

                    };


                    //}
                    GetAllMenuDetl.Add(per); //الي بنربطه مع الجريد فيو
                }
            }
            return GetAllMenuDetl;
        }
        public ObservableCollection<PrivilegemenuUser> GetPrivilegeUser(int menuId, int usertypeId)
        {
            ObservableCollection<PrivilegemenuUser> GetAllMenuDetl = new ObservableCollection<PrivilegemenuUser>();

            Hashtable keys = new Hashtable();
            keys.Add("menuId", menuId);
            keys.Add("usertypeId", usertypeId);
            var getparam = sphelper.prpareParam(keys);
            var result = sphelper.GetCollectionByParam(sP_Query.GetmenuPrivilegeUser, "GetmenuPrivilegeUser", getparam);
            if (result.Data.Count > 0)
            {
                foreach (DataRow row in result.Data)
                {
                    PrivilegemenuUser privilegemenuUser = new PrivilegemenuUser
                    {
                        FormName = (string)row[0],
                        MenuId = (int)row[1],
                        FormId = (int)row[2],
                        PrivilegeAdd = (bool)row[3],
                        PrivilegeDelete = (bool)row[4],
                        PrivilegeUpdate = (bool)row[5],
                        PrivilegeSelect = (bool)row[6],
                        PrivilegeForm = (bool)row[7],
                        UserTypeId = (int)row[8],

                    };
                    //PrivilegemenuUser per = new PrivilegemenuUser();

                    //}
                    GetAllMenuDetl.Add(privilegemenuUser); //الي بنربطه مع الجريد فيو
                }
            }
            return GetAllMenuDetl;
        }
        ///////////////////////////////// end OperarionPermissionUser/////////////////////////////////////

    }
}
