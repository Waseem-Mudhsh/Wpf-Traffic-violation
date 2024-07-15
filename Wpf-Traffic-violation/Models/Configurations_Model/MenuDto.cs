using System;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class MenuDto : BindableBase
    {
        private int menu_id { get; set; }
        private string menu_name { get; set; }
        public int Menu_id
        {
            get
            {
                return menu_id;
            }
            set
            {
                if (menu_id != value)
                {
                    menu_id = value;
                    RaisePropertyChanged("Menu_id");
                }
            }
        }
        public string Menu_name
        {
            get
            {
                return menu_name;
            }
            set
            {
                if (menu_name != value)
                {
                    menu_name = value;
                    RaisePropertyChanged("Menu_name");
                }
            }
        }
        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
