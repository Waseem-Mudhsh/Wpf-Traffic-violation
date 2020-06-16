using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf_Traffic_violation;

namespace Wpf_Traffic_violation.ViewModel
{
    public class ItemMenu
    {
      
        public ItemMenu(string header,List<SubItem> subitems,PackIconKind icon)
        {
            Header = header;
            SubItems = subitems;
            Icon = icon;
        }
   
        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        //public UserControl Screen { get; private set; }
    }
}
