using Herzog.Dapper;
using Herzog.Dapper.Contrib.Extensions;
using Herzog.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Herzog.MySqlDB
{
    public class MySqlDb : IDataBase
    {
        private readonly string SqlConnectionString;

        public MySqlDb(string connectionString)
        {
            SqlConnectionString = connectionString;
        }

        public bool Insert<T>(T Entity) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Insert<T>(Entity);
            }
        }

        public bool Insert<T>(T Entity, int? commandTimeOut = null) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Insert<T>(Entity, null, commandTimeOut);
            }
        }

        public bool Update<T>(T Entity) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Update<T>(Entity);
            }
        }

        public bool Update<T>(T Entity, int? commandTimeOut = null) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Update<T>(Entity, null, commandTimeOut);
            }
        }

        public bool Delete<T>(T Entity) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Delete<T>(Entity);
            }
        }

        public bool Delete<T>(T Entity, int? commandTimeOut = null) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Delete<T>(Entity, null, commandTimeOut);
            }
        }

        public bool Delete<T>(IEnumerable<T> entitys) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var entity in entitys)
                        {
                            conn.Delete<T>(entity, tran);
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }

            return true;
        }

        public bool DeleteAll<T>(int? commandTimeOut = null) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.DeleteAll<T>(null, commandTimeOut);
            }
        }

        public T Get<T>(string id) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Get<T>(id);
            }
        }

        public T Get<T>(string id, int? commandTimeOut) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Get<T>(id, null, commandTimeOut);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.GetAll<T>();
            }
        }

        public IEnumerable<T> GetAll<T>(int? commandTimeOut) where T : class
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.GetAll<T>(null, commandTimeOut);
            }
        }

        public IEnumerable<T> Query<T>(string sqlCommand)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<T>(sqlCommand);
            }
        }

        public IEnumerable<T> Query<T>(string sqlCommand, object parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<T>(sqlCommand, parameters);
            }
        }

        public IEnumerable<T> Query<T>(string sqlCommand, object parameters = null, bool buffered = false, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<T>(sqlCommand, parameters, null, buffered, commandTimeout, commandType);
            }
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sqlCommand, Func<TFirst, TSecond, TReturn> map, object param = null)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<TFirst, TSecond, TReturn>(sqlCommand, map, param);
            }
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(
              string sqlCommand, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<TFirst, TSecond, TReturn>(sqlCommand, map, param, null, buffered, splitOn, commandTimeout, commandType);
            }
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sqlCommand, Func<TFirst, TSecond, TThird, TReturn> map, object param = null)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<TFirst, TSecond, TThird, TReturn>(sqlCommand, map, param);
            }
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(
             string sqlCommand, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<TFirst, TSecond, TThird, TReturn>(sqlCommand, map, param, null, buffered, splitOn, commandTimeout, commandType);
            }
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sqlCommand, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<TFirst, TSecond, TThird, TFourth, TReturn>(sqlCommand, map, param);
            }
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(
            string sqlCommand, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<TFirst, TSecond, TThird, TFourth, TReturn>(sqlCommand, map, param, null, buffered, splitOn, commandTimeout, commandType);
            }
        }

        public int Execute(string sqlCommand)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Execute(sqlCommand);
            }
        }

        public int Execute(string sqlCommand, object parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Execute(sqlCommand, parameters);
            }
        }

        public int Execute(string sqlCommand, object parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Execute(sqlCommand, parameters, null, commandTimeout, commandType);
            }
        }
        #region 存储过程

        public IEnumerable<T> ExecuteProcedure<T>(string storedProcName, IDictionary[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<T>(storedProcName, parameters, null, false, null, CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> ExecuteProcedure<T>(string storedProcName, IDictionary[] parameters, bool buffered = false, int? commandTimeout = default(int))
        {
            using (MySqlConnection conn = new MySqlConnection(SqlConnectionString))
            {
                conn.Open();
                return conn.Query<T>(storedProcName, parameters, null, buffered, commandTimeout, CommandType.StoredProcedure);
            }
        }

        #endregion
    }
}
