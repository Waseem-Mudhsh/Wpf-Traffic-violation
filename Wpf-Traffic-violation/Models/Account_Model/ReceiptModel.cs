using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Traffic_violation.Models
{
    public class ReceiptModel
    {
        public bool OperarionReceipt(Receipt Receipt, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[8];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Receipt_id", SqlDbType.Int)
            {
                Value = Receipt.Receipt_id
            };
            param[1] = new SqlParameter("@Account_id", SqlDbType.Int)
            {
                Value = Receipt.Account_id
            };
            param[2] = new SqlParameter("@Receipt_statement", SqlDbType.NVarChar, 50)
            {
                Value = Receipt.Receipt_statement
            };
            param[3] = new SqlParameter("@Receipt_amount", SqlDbType.Int)
            {
                Value = Receipt.Receipt_amount
            };
            param[4] = new SqlParameter("@Receipt_status", SqlDbType.Bit)
            {
                Value = Receipt.Receipt_status
            };
            param[5] = new SqlParameter("@Receipt_date", SqlDbType.NVarChar, 50)
            {
                Value = Receipt.Receipt_date
            };
            param[6] = new SqlParameter("@Post_date", SqlDbType.NVarChar, 50)
            {
                Value = Receipt.Post_date
            };
            param[7] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opReceipt", param))
            {
                return false;

            }
            return true;
        }

        public bool OperarionReceiptdetail(int Receipt_detail_id, int Receipt_id, string Receipt_detail_statement, int Violation_id, int Receipt_detail_amount, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[6];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Receipt_detail_id", SqlDbType.Int)
            {
                Value = Receipt_detail_id
            };
            param[1] = new SqlParameter("@Receipt_id", SqlDbType.Int)
            {
                Value = Receipt_id
            };
            param[2] = new SqlParameter("@Receipt_detail_statement", SqlDbType.NVarChar, 50)
            {
                Value = Receipt_detail_statement
            };
            param[3] = new SqlParameter("@Violation_id", SqlDbType.Int)
            {
                Value = Violation_id
            };
            param[4] = new SqlParameter("@Receipt_detail_amount", SqlDbType.Int)
            {
                Value = Receipt_detail_amount
            };
            param[5] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opReceiptdetail", param))
            {
                return false;

            }
            return true;
        }


    }
}
