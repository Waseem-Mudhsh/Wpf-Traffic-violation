using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models
{
    public class AccountModel
    {

        ///////////////////////////////// start GetAccounts/////////////////////////////////////

        public ObservableCollection<Account> GetAccounts()
        {
            ObservableCollection<Account> Accounts = new ObservableCollection<Account>();
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
                    CommandText = "GetAccounts",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Account per = new Account
                        {
                            Account_id = (int)row[0],
                            Account_parent = (int)row[1],
                            Account_name = row[2].ToString(),
                            Account_type = (int)row[3],
                            Account_order = (int)row[4],
                            Account_debtor = (int)row[5],
                            Account_creditor = (int)row[6],
                            Account_date = row[7].ToString(),
                            Account_status = (bool)row[8]

                        };
                        per.String_Acc = new Class_SqlConnection().Get_row("GetAccountName", per.Account_id);
                        per.String_AccParent = new Class_SqlConnection().Get_row("GetAccountName", per.Account_parent);
                        if (per.Account_type == 1)
                            per.String_AccType = "رئيسي";
                        else if (per.Account_type == 2)
                            per.String_AccType = "فرعي";

                        Accounts.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }

            }
            return Accounts;
        }
        ///////////////////////////////// end GetAccounts/////////////////////////////////////

        ///////////////////////////////// start GetAccounts/////////////////////////////////////

        public ObservableCollection<Account> GetAccountParent()
        {
            ObservableCollection<Account> AccountParent = new ObservableCollection<Account>();
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
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
                    CommandText = "GetAccountParent",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Account per = new Account
                        {
                            Account_id = (int)row[0],
                            Account_parent = (int)row[1],
                            Account_name = row[2].ToString(),
                            Account_type = (int)row[3],
                            Account_order = (int)row[4],
                            Account_debtor = (int)row[5],
                            Account_creditor = (int)row[6],
                            Account_date = row[7].ToString(),
                            Account_status =(bool)row[8]

                        };
                        per.String_Acc = new Class_SqlConnection().Get_row("GetAccountName", per.Account_id);
                        per.String_AccParent = new Class_SqlConnection().Get_row("GetAccountName", per.Account_parent);
                        if (per.Account_type == 1)
                            per.String_AccType = "رئيسي";
                        else if (per.Account_type == 2)
                            per.String_AccType = "فرعي";


                        AccountParent.Add(per); //الي بنربطه مع الجريد فيو


                    }
                }

            }
            return AccountParent;
        }
        ///////////////////////////////// end GetAccounts/////////////////////////////////////
     
        ///////////////////////////////// start OperarionAccount/////////////////////////////////////
      
        public static bool OperarionAccount(Account Account, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[10];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Account_id", SqlDbType.Int)
            {
                Value = Account.Account_id
            };
            param[1] = new SqlParameter("@Account_parent", SqlDbType.Int)
            {
                Value = Account.Account_parent
            };
            param[2] = new SqlParameter("@Account_name", SqlDbType.NVarChar, 30)
            {
                Value = Account.Account_name
            };
            param[3] = new SqlParameter("@Account_type", SqlDbType.Int)
            {
                Value = Account.Account_type
            };
            param[4] = new SqlParameter("@Account_order", SqlDbType.Int)
            {
                Value = Account.Account_order
            };
            param[5] = new SqlParameter("@Account_debtor", SqlDbType.Int)
            {
                Value = Account.Account_debtor
            };
            param[6] = new SqlParameter("@Account_creditor", SqlDbType.Int)
            {
                Value = Account.Account_creditor
            };
            param[7] = new SqlParameter("@Account_date", SqlDbType.NVarChar,50)
            {
                Value = Account.Account_date
            };
            param[8] = new SqlParameter("@Account_status", SqlDbType.Bit)
            {
                Value = Account.Account_status
            };
            param[9] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opAccount", param))
            {
                return false;

            }



            return true;
        }
        ///////////////////////////////// end OperarionAccount/////////////////////////////////////


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
                    CommandText = "checkAccount",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Account_id", value);


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




        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<Account> Accounts)
        {

            OleDbConnection con;
            OleDbDataAdapter da;
            DataTable dt;
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a Excel File";
            op.Filter = "AllFiles | *.* | Excel Files |*.XLSX";
            if (op.ShowDialog() == true)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + op.FileName + "; Extended Properties=Excel 12.0");
                da = new OleDbDataAdapter("select * from [page$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Account per = new Account
                        {
                            Account_id = Convert.ToInt32( row[0]),
                            Account_parent = Convert.ToInt32(row[1]),
                            Account_name = row[2].ToString(),
                            Account_type = Convert.ToInt32(row[3]),
                            Account_order = Convert.ToInt32(row[4]),
                            Account_debtor = Convert.ToInt32(row[5]),
                            Account_creditor = Convert.ToInt32(row[6]),
                            Account_date = row[7].ToString(),
                            Account_status= Convert.ToBoolean(row[8]),

                        };
                        OperarionAccount(per, "Insert");



                        Accounts.Add(per); //الي بنربطه مع الجريد فيو
                    }
                    string message = "عدد السجلات المستوردة = " + dt.Rows.Count;
                    string caption = "عملية الاستيراد";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }


        }
        /////////////////////////////////evd GetExcel/////////////////////////////////////

        ///////////////////////////////// start GetAccountChild/////////////////////////////////////

        public ObservableCollection<Account> GetAccountChild()
        {
            ObservableCollection<Account> AccountParent = new ObservableCollection<Account>();
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
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
                    CommandText = "GetAccountChild",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Account per = new Account
                        {
                            Account_id = (int)row[0],
                            Account_parent = (int)row[1],
                            Account_name = row[2].ToString(),
                            Account_type = (int)row[3],
                            Account_order = (int)row[4],
                            Account_debtor = (int)row[5],
                            Account_creditor = (int)row[6],
                            Account_date = row[7].ToString(),
                            Account_status = Convert.ToBoolean(row[8])

                        };
                        per.String_Acc = new Class_SqlConnection().Get_row("GetAccountName", per.Account_id);
                        per.String_AccParent = new Class_SqlConnection().Get_row("GetAccountName", per.Account_parent);
                        if (per.Account_type == 1)
                            per.String_AccType = "رئيسي";
                        else if (per.Account_type == 2)
                            per.String_AccType = "فرعي";


                        AccountParent.Add(per); //الي بنربطه مع الجريد فيو


                    }
                }

            }
            return AccountParent;
        }
        ///////////////////////////////// end GetAccountChild/////////////////////////////////////

        ///////////////////////////////// start GetCreate_Account/////////////////////////////////////

        public int GetCreate_Account(int account_parint)
        {
            int account_id = 0;
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

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
                    CommandText = "Create_Account",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@acc_pr", account_parint);

                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        account_id = (int)row[0];

                    }
                }

            }
            return account_id;
        }
        ///////////////////////////////// end GetCreate_Account/////////////////////////////////////


        public bool Check_Parint(int value)
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
                    CommandText = "Chick_Account_Isparent",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Account_parent", value);


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
