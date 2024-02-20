using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.Models;

namespace Wpf_Traffic_violation.Core.helper
{
    public interface ICacheManager 
    {
        List<Hashtable>     GetFileContents(string filePath);
        ObservableCollection<T> GetKey(string v);
         void  setKey(ObservableCollection<T> plattypechach);
    }
}
