using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models.Account_Model
{
   public class BondOfExchangeModel
    {
        ///////////////////////////////// start GetBondOfExchanges/////////////////////////////////////

        public void GetBondOfExchanges(ObservableCollection<BondOfExchange> BondOfExchanges)
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
                    CommandText = "GetBondOfExchanges",
                    Connection = con

                };
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
                            Bond_Exchange_status=(bool)row[6],
                            Post_date = row[7].ToString(),
                            Reference_number = (int)row[8],


                        };
                        per.String_Accountfrom = new Class_SqlConnection().Get_row("GetAccountName", per.Account_from_id);
                        per.String_Accountto = new Class_SqlConnection().Get_row("GetAccountName", per.Account_to_id);

                        BondOfExchanges.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }

            }
        }
        ///////////////////////////////// end GetBondOfExchanges/////////////////////////////////////


        ///////////////////////////////// start GetBond_Exchange_details/////////////////////////////////////

        public void GetBond_Exchange_details(ObservableCollection<Bond_Exchange_detail> Bond_Exchange_details,int Bond_Exchange_id)
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
                    CommandText = "GetBond_Exchange_details",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Bond_Exchange_id", Bond_Exchange_id);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Bond_Exchange_detail per = new Bond_Exchange_detail
                        {
                            Bond_Exchange_detail_id = (int)row[0],
                            Bond_Exchange_id = (int)row[1],
                            Bond_Exchange_detail_statement = row[2].ToString(),
                            Bond_Exchange_detail_amount = (int)row[3]
                        };
                       
                        Bond_Exchange_details.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }

            }
        }
        ///////////////////////////////// end GetBond_Exchange_details/////////////////////////////////////

        ///////////////////////////////// start OperarionBondOfExchange/////////////////////////////////////

        public static bool OperarionBondOfExchange(BondOfExchange BondOfExchange, ObservableCollection<Bond_Exchange_detail> Grid_Bond_Exchange_detail, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();
          
            //--------------------------------------------
            if (operartion=="Delete")
            {
                OperarionBond_Exchange_detail(Grid_Bond_Exchange_detail,"Delete");
            }
            //---------------------------------------------

            SqlParameter[] param = new SqlParameter[10];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Bond_Exchange_id", SqlDbType.Int)
            {
                Value = BondOfExchange.Bond_Exchange_id
            };
            param[1] = new SqlParameter("@Bond_Exchange_date", SqlDbType.NVarChar, 50)
            {
                Value = BondOfExchange.Bond_Exchange_date
            };
            param[2] = new SqlParameter("@Account_from_id", SqlDbType.Int)
            {
                Value = BondOfExchange.Account_from_id
            };
            param[3] = new SqlParameter("@Account_to_id", SqlDbType.Int)
            {
                Value = BondOfExchange.Account_to_id
            };
            param[4] = new SqlParameter("@Bond_Exchange_statement", SqlDbType.NVarChar)
            {
                Value = BondOfExchange.Bond_Exchange_statement
            };
            param[5] = new SqlParameter("@Bond_Exchange_amount", SqlDbType.Int)
            {
                Value = BondOfExchange.Bond_Exchange_amount
            };
            param[6] = new SqlParameter("@Bond_Exchange_status", SqlDbType.Bit)
            {
                Value = BondOfExchange.Bond_Exchange_status
            };
            param[7] = new SqlParameter("@Post_date", SqlDbType.NVarChar, 50)
            {
                Value = BondOfExchange.Post_date
            };
            param[8] = new SqlParameter("@Reference_number", SqlDbType.Int)
            {
                Value = BondOfExchange.Reference_number
            };
            param[9] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opBondOfExchange",param))
            {
                return false;
            }
            else if(operartion == "Insert"|| operartion == "Update")
               OperarionBond_Exchange_detail(Grid_Bond_Exchange_detail, operartion);

            return true;
        }
        ///////////////////////////////// end OperarionBondOfExchange/////////////////////////////////////

        public static bool OperarionBond_Exchange_detail(ObservableCollection<Bond_Exchange_detail> Grid_Bond_Exchange_detail, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            foreach (Bond_Exchange_detail a in Grid_Bond_Exchange_detail)
            {
                SqlParameter[] param = new SqlParameter[5];
                //@user_id, @user_name, @user_pass, @user_type, @user_status

                param[0] = new SqlParameter("@Bond_Exchange_detail_id", SqlDbType.Int)
                {
                    Value = sql.Get_Max("Bond_Exchange_detail")
                };
                param[1] = new SqlParameter("@Bond_Exchange_id", SqlDbType.Int)
                {
                    Value =a.Bond_Exchange_id
                };
                param[2] = new SqlParameter("@Bond_Exchange_detail_statement", SqlDbType.NVarChar, 50)
                {
                    Value = a.Bond_Exchange_detail_statement
                };
                param[3] = new SqlParameter("@Bond_Exchange_detail_amount", SqlDbType.Int)
                {
                    Value = a.Bond_Exchange_detail_amount
                };
                param[4] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
                {
                    Value = operartion
                };
                sql.Operarion("opBond_Exchange_detail", param);

                }
            
            return true;
        }
        ///////////////////////////////// end OperarionBond_Exchange_detail/////////////////////////////////////

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
                    CommandText = "Chick_Bond_Exchange",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Bond_Exchange_id", value);


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
