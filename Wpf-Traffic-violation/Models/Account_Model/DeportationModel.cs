using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Models.Account_Model;

namespace Wpf_Traffic_violation.Models.Account_Mode
{
    public class DeportationModel
    {
        //ObservableCollection<BondOfExchange> BondOfExchanges;
        //ObservableCollection<Receipt> Receipts;
        //BondOfExchangeModel BondOfExchangeModel;
        //ReceiptModel ReceiptModel;


        ///////////////////////////////// start GetBondOfExchanges_Deportation/////////////////////////////////////

        public void GetBondOfExchanges_Deportation(ObservableCollection<BondOfExchange> BondOfExchanges_Deportation,SqlParameter[] Param)
        {
           // BondOfExchanges = new ObservableCollection<Account_Model.BondOfExchange>();
            //BondOfExchangeModel.GetBondOfExchanges(BondOfExchanges);

            // Command.Parameters.AddRange(Param);
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
                    CommandText = "GetDeportation",
                    Connection = con

                };
                Command.Parameters.AddRange(Param);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        
                            BondOfExchange per = new BondOfExchange
                            {
                                Bond_Exchange_id = (int)row[0],
                                Bond_Exchange_date = row[1].ToString(),
                                Account_from_id = (int)row[2],
                                Account_to_id = (int)row[3],
                                Bond_Exchange_statement = row[4].ToString(),
                                Bond_Exchange_amount = (int)row[5],
                                Bond_Exchange_status = (bool)row[6],
                                Post_date = row[7].ToString(),
                                Reference_number = (int)row[8]
                            };
                            per.String_Accountfrom = new Class_SqlConnection().Get_row("GetAccountName", per.Account_from_id);
                            per.String_Accountto = new Class_SqlConnection().Get_row("GetAccountName", per.Account_to_id);

                            BondOfExchanges_Deportation.Add(per);
                    }
                }

            }
           


        }
        ///////////////////////////////// end GetBondOfExchanges_Deportation/////////////////////////////////////


        ///////////////////////////////// start GetBondOfExchanges_Deportation/////////////////////////////////////

        public void GetReceipt_Deportation(ObservableCollection<Receipt> Receipts_Deportation, SqlParameter[] Param)
        {
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
                    CommandText = "GetDeportation",
                    Connection = con

                };
                Command.Parameters.AddRange(Param);
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

                        Receipts_Deportation.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }

            }
        }
        ///////////////////////////////// end GetBondOfExchanges_Deportation/////////////////////////////////////

    }
}
