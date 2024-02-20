using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.Core.helper;
using static Xceed.Wpf.Toolkit.Calculator;

namespace Wpf_Traffic_violation.Services.helper
{
    public interface Isphelper
    {
       DataRowCollection  GetCollection(string SpStoredProcedureQuery, string name = null);
        Response<DataRowCollection> GetCollectionByParam(string SpStoredProcedureName, string v, SqlCommand command=null);
        T Operations<T>(string SpStoredProcedureQuery, string name = null);
        SqlCommand prpareParam(Hashtable keys);
        Response<bool> Operarion(SqlParameter[] parameters, string SpStoredProcedureQuery, string nameSp = null);
        DataRowCollection GetMax(string SpStoredProcedureQuery, string name = null, string tableName = null, string namecolmn = null); 
        DataRowCollection GetNameOfRow(string SpStoredProcedureQuery, string operation = null, string tableName = null, int id = 0);

    }
}
