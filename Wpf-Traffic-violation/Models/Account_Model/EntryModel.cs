using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Traffic_violation.Models
{
    public class EntryModel
    {

        ///////////////////////////////// start AddEntry/////////////////////////////////////
        public bool AddEntry(int Entry_Id, string Entry_statement, string Entry_date, int Account_id1, int Account_id2, int Amount)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[6];
            //@user_id, @user_name, @user_pass, @user_type, @user_status
            param[0] = new SqlParameter("@Entry_id", SqlDbType.Int)
            {
                Value = Entry_Id
            };
            param[1] = new SqlParameter("@Entry_statement", SqlDbType.NVarChar, 50)
            {
                Value = String.Join(Entry_statement, " مقابل عمل مخالفة")
            };
            param[2] = new SqlParameter("@Entry_date", SqlDbType.NVarChar, 50)
            {
                Value = Entry_date
            };

            param[3] = new SqlParameter("@Account_id1", SqlDbType.Int)
            {
                Value = Account_id1
            };
            param[4] = new SqlParameter("@Account_id2", SqlDbType.Int)
            {
                Value = Account_id2
            };
            param[5] = new SqlParameter("@Amount", SqlDbType.Int)
            {
                Value = Amount
            };
            if (!sql.Operarion("AddEntry", param))
            {
                return false;
            }
            return true;
        }
        ///////////////////////////////// end AddEntry/////////////////////////////////////

        ///////////////////////////////// start UpdateEntry/////////////////////////////////////
        public bool UpdateEntry(int Account_id1, int Account_id2, string Entry_date, int Amount)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@Account_id1", SqlDbType.Int)
            {
                Value = Account_id1
            };
            param[1] = new SqlParameter("@Account_id2", SqlDbType.Int)
            {
                Value = Account_id2
            };
            param[2] = new SqlParameter("@Entry_date", SqlDbType.NVarChar, 50)
            {
                Value = Entry_date
            };
            param[3] = new SqlParameter("@Amount", SqlDbType.Int)
            {
                Value = Amount
            };
            if (!sql.Operarion("UpdateEntry", param))
            {
                return false;
            }
            return true;
        }
        ///////////////////////////////// end UpdateEntry/////////////////////////////////////

        ///////////////////////////////// start DeleteEntry/////////////////////////////////////
        public bool DeleteEntry(int Account_id1, int Account_id2, string Entry_date)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Account_id1", SqlDbType.Int)
            {
                Value = Account_id1
            };
            param[1] = new SqlParameter("@Account_id2", SqlDbType.Int)
            {
                Value = Account_id2
            };
            param[2] = new SqlParameter("@Entry_date", SqlDbType.NVarChar, 50)
            {
                Value = Entry_date
            };

            if (!sql.Operarion("DeleteEntry", param))
            {
                return false;
            }
            return true;
        }
        ///////////////////////////////// end AddEntry/////////////////////////////////////
    }
}
