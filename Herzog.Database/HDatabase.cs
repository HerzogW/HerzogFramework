using Herzog.Dapper;
using Herzog.Dapper.Contrib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Database
{
    public class HDatabase
    {
        private readonly string sqlconnectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public bool Insert<T>(T Entity) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Insert<T>(Entity);
            }
        }

        public bool Insert<T>(T Entity, IDbTransaction transaction = null, int? commandTimeOut = null) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Insert<T>(Entity, transaction, commandTimeOut);
            }
        }

        public bool Update<T>(T Entity) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Update<T>(Entity);
            }
        }

        public bool Update<T>(T Entity, IDbTransaction transaction = null, int? commandTimeOut = null) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Update<T>(Entity, transaction, commandTimeOut);
            }
        }

        public bool Delete<T>(T Entity) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Delete<T>(Entity);
            }
        }

        public bool Delete<T>(T Entity, IDbTransaction transaction = null, int? commandTimeOut = null) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Delete<T>(Entity, transaction, commandTimeOut);
            }
        }

        public bool DeleteAll<T>(IDbTransaction transaction = null, int? commandTimeOut = null) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.DeleteAll<T>(transaction, commandTimeOut);
            }
        }

        public T Get<T>(string id) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Get<T>(id);
            }
        }

        public T Get<T>(string id, IDbTransaction transaction, int? commandTimeOut) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Get<T>(id, transaction, commandTimeOut);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.GetAll<T>();
            }
        }

        public IEnumerable<T> GetAll<T>(IDbTransaction transaction, int? commandTimeOut) where T : class
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.GetAll<T>(transaction, commandTimeOut);
            }
        }


        public IEnumerable<T> Query<T>(string sqlCommand)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Query<T>(sqlCommand);
            }
        }

        public IEnumerable<T> Query<T>(string sqlCommand, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Query<T>(sqlCommand, parameters);
            }
        }

        public IEnumerable<T> Query<T>(string sqlCommand, object parameters = null, IDbTransaction transaction = null, bool buffered = false, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Query<T>(sqlCommand, parameters, transaction, buffered, commandTimeout, commandType);
            }
        }

        #region 存储过程

        public IEnumerable<T> RunProcedure<T>(string storedProcName, IDictionary[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
            {
                conn.Open();
                return conn.Query<T>(storedProcName, parameters, null, false, null, CommandType.StoredProcedure);
            }
        }

        #endregion
    }
}
