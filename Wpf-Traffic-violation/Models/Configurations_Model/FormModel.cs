using System;
using System.Collections.Generic;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class FormModel : BindableBase
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public int FormType { get; set; }
        public int MenuId { get; set; }
        public string Code { get; set; }
        public bool Add_opretion { get; set; }
        public bool Update_opretion { get; set; }
        public bool Delete_opretion { get; set; }
        public bool Select_opretion { get; set; }
        public bool Is_active { get; set; }

        public FormModel()
        {

        }
        public FormModel(int _formId, string _formName, int _menuId, int _formType, string _code, bool _add_op = false, bool _update_op = false,
            bool _delete_op = false, bool _select_op = false, bool _isactive = false)
        {
            FormId = _formId;
            FormName = _formName;
            MenuId = _menuId;
            FormType = _formType;
            Code = _code;
            Select_opretion = _select_op;
            Delete_opretion = _delete_op;
            Add_opretion = _add_op;
            Update_opretion = _update_op;
            Is_active = _isactive;



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
