using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Wpf_Traffic_violation.Services;

namespace Wpf_Traffic_violation.Models
{
    public class ReceiptModel
    {

        ///////////////////////////////// start GetReceipts/////////////////////////////////////
        ReceiptServices receipt;
        helper _helper;
        public ReceiptModel()
        {
            receipt = new ReceiptServices();
            _helper = new helper();

        }

        public Wpf_Traffic_violation.MagrationDB.Receipt CreateReceipt(Receipt current_Receipt, int count)
        {
            var receiptModel = _helper.CreateReceiptModel(current_Receipt, count);

            var result = receipt.CreateNewRecipt(receiptModel);
            return result;
        }
        public ObservableCollection<Receipt> GetReceipts()
        {
            ObservableCollection<Receipt> Receipts = new ObservableCollection<Receipt>();

            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            // Properties.Settings.Default.con = con;
            //Properties.Settings.Default.Save();

            //Class_SqlConnection sql = new Class_SqlConnection();
            using (con)
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {

                    MessageBox.Show("Cant Open con");
                }
                //SqlCommand Command = new SqlCommand("Select * from Person", con);
                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetReceipts",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Receipt per = new Receipt
                        {
                            Receipt_id = (int)row[0]
                            ,
                            Account_id = (int)row[1]
                            ,
                            Receipt_statement = row[2].ToString()
                            ,
                            Receipt_amount = (int)row[3]
                            ,
                            Receipt_status = (bool)row[4]
                            ,
                            Receipt_date = row[5].ToString()
                            ,
                            Post_date = row[6].ToString()

                        };
                        per.String_Account = new Class_SqlConnection().Get_row("GetAccountName", per.Account_id);

                        Receipts.Add(per);
                    }
                }

            }
            return Receipts;
        }
        ///////////////////////////////// end GetReceipts/////////////////////////////////////


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
        public Wpf_Traffic_violation.MagrationDB.Receipt_detail OperarionReceiptdetail(int Receipt_detail_id, int Receipt_id, string Receipt_detail_statement, int Violation_id, int Receipt_detail_amount, string nameOfPaid, string resonOfPaid, int receipt_amountwithdiscont)
        {
            var PrpareModel = _helper.CreateReceiptDetailModel(Receipt_id, Receipt_detail_statement, Violation_id, Receipt_detail_amount, nameOfPaid, resonOfPaid, receipt_amountwithdiscont);
            var result = receipt.CreateReciptDetail(PrpareModel);
            return result;
        }



        /////////////////////////////////start Check_Exsit /////////////////////////////////////
        public bool Check_Exsit(int value)
        {
            Class_SqlConnection sql = new Class_SqlConnection();
            using (sql.con)
            {
                try
                {
                    sql.con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cant Open Conncation");

                }
                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "checkReceipt",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Receipt_id", value);


                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }


            }
        }



        /////////////////////////////////end Check_Exsit/////////////////////////////////////

    }
}
