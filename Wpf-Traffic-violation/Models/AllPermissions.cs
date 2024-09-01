using Syncfusion.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.Models
{
    public class AllPermissions
    {

        PermissionUserModel permissionUserModel;
        public AllPermissions()
        {
            permissionUserModel = new PermissionUserModel();


        }

        public void getAllPermissions()
        {
            try
            {
                PermissionsEntity permissionsEntity = new PermissionsEntity();
                Properties.Settings.Default.permission = null;
                Properties.Settings.Default.Save();
                SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                var menudetlsForUserType = permissionUserModel.GetMenuDetl(Properties.Settings.Default.UserType);
                var formsPrvlgeForUser = permissionUserModel.GetPrivilegeUser(usertypeId: Properties.Settings.Default.UserType);
                permissionsEntity.MenuPrevlg = menudetlsForUserType.Select(o => new MenuDetail(o.ID, o.menu_id, o.User_type_id, o.is_active, o.name)).ToList();
                permissionsEntity.FormPrevlg = formsPrvlgeForUser.Select(md => new PrivilegemenuUser(md.FormName,
                       md.MenuId,
                      md.FormId,
                       md.PrivilegeAdd,
                    md.PrivilegeDelete,
                      md.PrivilegeUpdate,
                      md.PrivilegeSelect,
                     md.PrivilegeForm,
                       md.UserTypeId)).ToList();

                Properties.Settings.Default.permissionUser = permissionsEntity;
            }
            catch
            {

            }


        }



        public void getPermission(PermissionUser permissionUser)
        {
            if (Properties.Settings.Default.permission.Rows.Count > 0)
            {
                foreach (DataRow row in Properties.Settings.Default.permission.Rows)
                {
                    if ((int)row[1] == permissionUser.Form_id)
                    {

                        permissionUser.User_id = (int)row[0];
                        permissionUser.Form_id = (int)row[1];
                        permissionUser.Add_opretion = (bool)row[2];
                        permissionUser.Delete_opretion = (bool)row[3];
                        permissionUser.Update_opretion = (bool)row[4];
                        permissionUser.Select_opretion = (bool)row[5];
                        permissionUser.Form = (bool)row[6];

                        //PermissionUser.String_Id = new Class_SqlConnection().Get_row("getUserName", PermissionUser.User_id);
                        //PermissionUser.String_form = new Class_SqlConnection().Get_row("getFormName", PermissionUser.Form_id);

                    }

                }
            }


        }
        //public List<PermissionUser> getPermissionForUser()
        //{
        //    List<PermissionUser> pemationLlist = new List<PermissionUser>();

        //    if (Properties.Settings.Default.permission.Rows.Count > 0)
        //    {

        //        foreach (DataRow row in Properties.Settings.Default.permission.Rows)
        //        {
        //            var permation = new PermissionUser();
        //            permation.User_id = (int)row[0];
        //            permation.Form_id = (int)row[1];
        //            permation.Add_opretion = (bool)row[2];
        //            permation.Delete_opretion = (bool)row[3];
        //            permation.Update_opretion = (bool)row[4];
        //            permation.Select_opretion = (bool)row[5];
        //            permation.Form = (bool)row[6];
        //            permation.Nameform = (string)row[7];
        //            permation.Codeform = (string)row[8];
        //            //PermissionUser.String_Id = new Class_SqlConnection().Get_row("getUserName", PermissionUser.User_id);
        //            //PermissionUser.String_form = new Class_SqlConnection().Get_row("getFormName", PermissionUser.Form_id);
        //            pemationLlist.Add(permation);
        //        }
        //    }


        //    return pemationLlist;
        //}
        //public PermissionUser GetFormPermation(List<PermissionUser> permation, string code)
        //{
        //    PermissionUser permissionUser = new PermissionUser();
        //    try
        //    {
        //        foreach (var row in permation)
        //        {
        //            if (row.Codeform == code)
        //            {
        //                permissionUser = row;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }


        //    return permissionUser;

        //}
        //public List<MenuDetail> GetMenuPermation()
        //{
        //    List<MenuDetail> permissionUser = new List<MenuDetail>();
        //    try
        //    {
        //        //foreach (var row in permation)
        //        //{
        //        //    if (true)
        //        //    {
        //        //        permissionUser = row;
        //        //    }
        //        //}
        //    }
        //    catch
        //    {
        //    }


        //    return permissionUser;

        //}


    }

}