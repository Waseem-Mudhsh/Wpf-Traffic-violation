using System;
using System.Collections.Generic;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class PrivilegemenuUser : BindableBase
    {
        public string FormName { get; set; }
        public int MenuId { get; set; }
        public int FormId { get; set; }
        public bool PrivilegeAdd { get; set; }
        public bool PrivilegeDelete { get; set; }
        public bool PrivilegeUpdate { get; set; }
        public bool PrivilegeSelect { get; set; }
        public bool PrivilegeForm { get; set; }
        public int UserTypeId { get; set; }
        public PrivilegemenuUser() { }
        public PrivilegemenuUser(string formName, int menuId, int formId, bool privilegeAdd,
                             bool privilegeDelete, bool privilegeUpdate, bool privilegeSelect,
                             bool privilegeForm, int userTypeId)
        {
            FormName = formName;
            MenuId = menuId;
            FormId = formId;
            PrivilegeAdd = privilegeAdd;
            PrivilegeDelete = privilegeDelete;
            PrivilegeUpdate = privilegeUpdate;
            PrivilegeSelect = privilegeSelect;
            PrivilegeForm = privilegeForm;
            UserTypeId = userTypeId;

        }

        protected bool SetProperty<T>(ref T member, T value, string propertyName)
        {

            if (EqualityComparer<T>.Default.Equals(member, value))
            {
                return false;
            }

            member = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
