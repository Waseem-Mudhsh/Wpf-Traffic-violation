using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Users_Model
{
    public class PermissionGroup : BindableBase
    {
        int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        int form_id;
        public int Form_id
        {
            get
            {
                return form_id;
            }
            set
            {
                if (form_id != value)
                {
                    form_id = value;
                    RaisePropertyChanged("Form_id");
                }
            }
        }
        bool add_opretion;
        public bool Add_opretion
        {
            get
            {
                return add_opretion;
            }
            set
            {
                if (add_opretion != value)
                {
                    add_opretion = value;
                    RaisePropertyChanged("Add_opretion");
                }
            }
        }
        bool update_opretion;
        public bool Update_opretion
        {
            get
            {
                return update_opretion;
            }
            set
            {
                if (update_opretion != value)
                {
                    update_opretion = value;
                    RaisePropertyChanged("Update_opretion");
                }
            }
        }
        bool delete_opretion;
        public bool Delete_opretion
        {
            get
            {
                return delete_opretion;
            }
            set
            {
                if (delete_opretion != value)
                {
                    delete_opretion = value;
                    RaisePropertyChanged("Delete_opretion");
                }
            }
        }
        bool select_opretion;
        public bool Select_opretion
        {
            get
            {
                return select_opretion;
            }
            set
            {
                if (select_opretion != value)
                {
                    select_opretion = value;
                    RaisePropertyChanged("Select_opretion");
                }
            }
        }
        bool form;
        public bool Form
        {
            get
            {
                return form;
            }
            set
            {
                if (form != value)
                {
                    form = value;
                    RaisePropertyChanged("Form");
                }
            }
        }
        string string_Id;
        public string String_Id
        {
            get
            {
                return string_Id;
            }
            set
            {
                if (string_Id != value)
                {
                    string_Id = value;
                    RaisePropertyChanged("String_Id");
                }
            }
        }
        string string_form;
        public string String_form
        {
            get
            {
                return string_form;
            }
            set
            {
                if (string_form != value)
                {
                    string_form = value;
                    RaisePropertyChanged("String_form");
                }
            }
        }


        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
