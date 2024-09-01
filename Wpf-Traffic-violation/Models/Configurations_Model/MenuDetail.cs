using System;
using System.Collections.Generic;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class MenuDetail : BindableBase
    {
        public int ID { get; set; }
        public int menu_id { get; set; }
        public int User_type_id { get; set; }
        public bool is_active { get; set; }
        public string name { get; set; }

        public MenuDetail() { }

        public MenuDetail(int id, int menuId, int userTypeId, bool isActive, string name)
        {
            ID = id;
            menu_id = menuId;
            User_type_id = userTypeId;
            is_active = isActive;
            this.name = name;
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
