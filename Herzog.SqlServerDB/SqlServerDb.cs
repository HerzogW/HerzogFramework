using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.SqlServerDB
{
    public class SqlServerDb
    {
        private readonly string sqlconnectionstring = ConfigurationManager.AppSettings["DefaultConnection"].ToString();

        public int Execute(string sqlCommand)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlCommand, conn);
                result = command.ExecuteNonQuery();
            }

            return result;
        }


        #region 查询Query

        public DataSet ExecuteQuery(string sqlCommand)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, conn);
                adapter.Fill(dataset);
            }

            return dataset;
        }

        public DataSet ExecureQuery(string sqlCommand, IDataParameter[] parameters)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildQueryCommand(conn, sqlCommand, parameters);
                adapter.Fill(dataset);
            }

            return dataset;
        }

        private SqlCommand BuildQueryCommand(SqlConnection connection, string sqlCommand, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.CommandType = CommandType.Text;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }

                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        #endregion


        #region 存储过程

        public SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                SqlCommand command = BuildProcQueryCommand(conn, storedProcName, parameters);
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildProcQueryCommand(conn, storedProcName, parameters);
                adapter.Fill(dataset, tableName);
            }

            return dataset;
        }

        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int times)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildProcQueryCommand(conn, storedProcName, parameters);
                adapter.SelectCommand.CommandTimeout = times;
                adapter.Fill(dataset);
            }

            return dataset;
        }

        public object RunProcdure(string storedProcName, IDataParameter[] parameters, string OutputName)
        {
            object obj;
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                SqlCommand command = BuildProcQueryCommand(conn, storedProcName, parameters);
                command.ExecuteNonQuery();
                obj = command.Parameters[OutputName].Value;
            }

            if (Object.Equals(obj, null) || Object.Equals(obj, DBNull.Value))
            {
                return null;
            }
            else
            {
                return obj;
            }
        }

        private SqlCommand BuildProcQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    //if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input)
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }

                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        #endregion
    }
}
