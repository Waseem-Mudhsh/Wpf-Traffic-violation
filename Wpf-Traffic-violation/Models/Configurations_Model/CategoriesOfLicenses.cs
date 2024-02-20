using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class CategoriesOfLicenses : BindableBase
    {
        int class_licence_ID;
        public int Class_licence_ID
        {
            get
            {
                return class_licence_ID;
            }
            set
            {
                if (class_licence_ID != value)
                {
                    class_licence_ID = value;
                    RaisePropertyChanged("Class_licence_ID");
                }
            }
        }
        string class_licence_name;
        public string Class_licence_name
        {
            get
            {
                return class_licence_name;
            }
            set
            {
                if (class_licence_name != value)
                {
                    class_licence_name = value;
                    Combine();
                    RaisePropertyChanged("Class_licence_name");
                }
            }
        }
        int province_id;
        public int Province_id
        {
            get
            {
                return province_id;
            }
            set
            {
                if (province_id != value)
                {
                    province_id = value;
                    Combine();
                    RaisePropertyChanged("Province_id");
                }
            }
        }
        string province_name;
        public string Province_name
        {
            get
            {
                return province_name;
            }
            set
            {
                if (province_name != value)
                {
                    province_name = value;
                    RaisePropertyChanged("Province_name");
                }
            }
        }


        string search;
        public string Search
        {
            get
            {
                return search;
            }
            set
            {
                if (search != value)
                {
                    search = value;
                    RaisePropertyChanged("Search");
                }
            }
        }
        void Combine()
        {
            Search = string.Join(" || ", Class_licence_ID.ToString(), Class_licence_name);
        }




        public override void CollectErrors()
        {
            Errors.Clear();
            //if (Class_licence_ID == 0)
            //{
            //    Errors.Add("Class_licence_ID", "يجب أن لايكون فارغ ");
            //}
            if (string.IsNullOrWhiteSpace(Class_licence_name))
            {
                Errors.Add("Class_licence_name", "يجب أن يكون نص ");
            }
            //if (string.IsNullOrWhiteSpace(Province_name))
            //{
            //    Errors.Add("Province_name", "يجب أن يكون نص ");
            //}
        }
    }
}
