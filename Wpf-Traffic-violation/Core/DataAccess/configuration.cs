using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Wpf_Traffic_violation.Core.helper;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Core.DataAccess
{
    public class configuration : Isphelper
    {
        public DataRowCollection GetCollection(string SpStoredProcedureQuery, string name = null)
        {
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            DataRowCollection Result = null;
            try
            {
                using (con)
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(

                        $"IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = '{name}') " +
                        "BEGIN SELECT 'Exists' AS Result; END " +
                        "ELSE BEGIN SELECT 'Does Not Exist' AS Result; END", con))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string resultString = result.ToString();
                            //chech if the SP Exist on DataBase or not if it is there we get data by name and if its not there  create it 
                            if (resultString == "Exists")///
                            {
                                command.CommandText = name;
                                command.CommandType = CommandType.StoredProcedure;
                                command.Connection = con;
                                command.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                                dataAdapter.Fill(dt);

                                Result = dt.Rows;
                            }
                            else if (resultString == "Does Not Exist")
                            {
                                command.CommandText = SpStoredProcedureQuery;
                                command.CommandType = CommandType.Text;
                                command.Connection = con;
                                command.ExecuteScalar();
                                SqlCommand sqlCommand = new SqlCommand
                                {
                                    CommandText = name,
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con
                                };
                                DataTable dt = new DataTable();
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                                dataAdapter.Fill(dt);

                                Result = dt.Rows;
                            }


                        }
                        else
                        {
                            // Handle the case where the result is null
                            // This might indicate an issue with the query or connection
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return Result;
        }

        public Response<DataRowCollection> GetCollectionByParam(string SpStoredProcedureName, string Spname, SqlCommand parameters)
        {
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

            Response<DataRowCollection> result = new Response<DataRowCollection>();
            try
            {
                con.Close();
                using (con)
                {
                    try
                    {
                        con.Open();
                    }
                    catch (Exception e)
                    {
                        result.Message = "Cant Open Conncation";

                    }
                    using (SqlCommand command = new SqlCommand(

                        $"IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = '{Spname}') " +
                        "BEGIN SELECT 'Exists' AS Result; END " +
                        "ELSE BEGIN SELECT 'Does Not Exist' AS Result; END", con))
                    {
                        var IsExsist = command.ExecuteScalar();
                        if (result != null)
                        {
                            string resultString = IsExsist.ToString();
                            //chech if the SP Exist on DataBase or not if it is there we get data by name and if its not there  create it 
                            if (resultString == "Exists")///
                            {
                                SqlCommand sqlCommand = new SqlCommand
                                {
                                    CommandType = CommandType.StoredProcedure,
                                    CommandText = Spname,
                                    Connection = con

                                };

                                if (parameters != null)
                                {
                                    sqlCommand.Parameters.Clear();
                                    foreach (SqlParameter param in parameters.Parameters)
                                    {
                                        sqlCommand.Parameters.AddWithValue(param.ParameterName, param.Value);
                                    }

                                }
                                DataTable dt = new DataTable();
                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                                {
                                    dataAdapter.Fill(dt);
                                }

                                result.Data = dt.Rows;


                            }
                            else if (resultString == "Does Not Exist")
                            {
                                command.CommandText = SpStoredProcedureName;
                                command.CommandType = CommandType.Text;
                                command.Connection = con;
                                command.ExecuteScalar();
                                SqlCommand sqlCommand = new SqlCommand
                                {
                                    CommandText = Spname,
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con

                                };
                                if (parameters != null)
                                {
                                    foreach (SqlParameter param in parameters.Parameters)
                                    {
                                        sqlCommand.Parameters.AddWithValue(param.ParameterName, param.Value);
                                    }


                                }
                                //sqlCommand.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                                dataAdapter.Fill(dt);
                                result.Data = dt.Rows;

                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }


            return result;
        }
        public DataRowCollection GetMax(string SpStoredProcedureQuery, string name = null, string tablename = null, string namecolmn = null)
        {
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

            DataRowCollection Result = null;
            try
            {
                using (con)
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(

                        $"IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = '{name}') " +
                        "BEGIN SELECT 'Exists' AS Result; END " +
                        "ELSE BEGIN SELECT 'Does Not Exist' AS Result; END", con))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string resultString = result.ToString();
                            //chech if the SP Exist on DataBase or not if it is there we get data by name and if its not there  create it 
                            if (resultString == "Exists")///
                            {
                                command.CommandText = name;
                                command.CommandType = CommandType.StoredProcedure;
                                command.Connection = con;
                                command.Parameters.AddWithValue("@TableName", tablename);
                                command.Parameters.AddWithValue("@coulmName", namecolmn);
                                command.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                                dataAdapter.Fill(dt);

                                Result = dt.Rows;
                            }
                            else if (resultString == "Does Not Exist")
                            {
                                command.CommandText = SpStoredProcedureQuery;
                                command.CommandType = CommandType.Text;
                                command.Connection = con;
                                command.ExecuteScalar();
                                SqlCommand sqlCommand = new SqlCommand
                                {
                                    CommandText = name,
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con
                                };
                                sqlCommand.Parameters.AddWithValue("@TableName", tablename);
                                DataTable dt = new DataTable();
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                                dataAdapter.Fill(dt);

                                Result = dt.Rows;
                            }


                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return Result;
        }

        public DataRowCollection GetNameOfRow(string SpStoredProcedureQuery, string operation = null, string tableName = null, int id = 0)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Operarion(SqlParameter[] parameters, string SpStoredProcedureQuery, string nameSp = null)
        {
            SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");


            Response<bool> result = new Response<bool>();
            try
            {
                using (con)
                {
                    try
                    {
                        con.Open();
                    }
                    catch (Exception)
                    {
                        result.Message = "Cant Open Conncation";

                    }
                    using (SqlCommand command = new SqlCommand(

                        $"IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = '{nameSp}') " +
                        "BEGIN SELECT 'Exists' AS Result; END " +
                        "ELSE BEGIN SELECT 'Does Not Exist' AS Result; END", con))
                    {
                        var IsExsist = command.ExecuteScalar();
                        if (result != null)
                        {
                            string resultString = IsExsist.ToString();
                            //chech if the SP Exist on DataBase or not if it is there we get data by name and if its not there  create it 
                            if (resultString == "Exists")///
                            {
                                SqlCommand Command = new SqlCommand
                                {
                                    CommandType = CommandType.StoredProcedure,
                                    CommandText = nameSp,
                                    Connection = con

                                };
                                if (parameters != null)
                                {
                                    Command.Parameters.AddRange(parameters);

                                }
                                result.Code = Command.ExecuteNonQuery();
                                if (!(result.Code == -1))
                                {
                                    result.Data = false;
                                }

                                result.Data = true;

                            }
                            else if (resultString == "Does Not Exist")
                            {


                                command.CommandText = SpStoredProcedureQuery;
                                command.CommandType = CommandType.Text;
                                command.Connection = con;
                                command.ExecuteScalar();
                                SqlCommand sqlCommand = new SqlCommand
                                {
                                    CommandText = nameSp,
                                    CommandType = CommandType.StoredProcedure,
                                    Connection = con

                                };
                                if (parameters != null)
                                {
                                    //sqlCommand.Parameters.Add(parameters);
                                    sqlCommand.Parameters.AddRange(parameters);

                                }
                                result.Code = sqlCommand.ExecuteNonQuery();
                                if (!(result.Code == -1))
                                {
                                    result.Data = false;
                                }

                                result.Data = true;

                            }
                        }
                        else
                        {
                            // Handle the case where the result is null
                            // This might indicate an issue with the query or connection
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


            return result;

        }
        public T Operations<T>(string SpStoredProcedureQuery, string name = null)
        {
            throw new NotImplementedException();
        }

        public SqlCommand prpareParam(Hashtable items)
        {
            SqlCommand command = new SqlCommand();
            Hashtable keys = new Hashtable();

            command.Parameters.Clear();

            foreach (DictionaryEntry key in items)
            {
                string param = "@" + key.Key;
                var newparms = command.Parameters.AddWithValue(param, key.Value);

                //command.Parameters.AddRange(newparms)/*;*/
            }

            return command;
        }
    }
}
