using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Interface
{
    public interface IDataBase
    {
        bool Insert<T>(T entity) where T : class;

        bool Insert<T>(T entity, int? commandTimeOut = null) where T : class;

        bool Update<T>(T entity) where T : class;

        bool Update<T>(T entity, int? commandTimeOut = null) where T : class;

        bool Delete<T>(T entity) where T : class;

        bool Delete<T>(T entity, int? commandTimeOut = null) where T : class;

        bool Delete<T>(IEnumerable<T> entitys) where T : class;

        bool DeleteAll<T>(int? commandTimeOut = null) where T : class;

        T Get<T>(string id) where T : class;

        T Get<T>(string id, int? commandTimeOut) where T : class;

        IEnumerable<T> GetAll<T>() where T : class;

        IEnumerable<T> GetAll<T>(int? commandTimeOut) where T : class;

        IEnumerable<T> Query<T>(string sqlCommand);

        IEnumerable<T> Query<T>(string sqlCommand, object parameters);

        IEnumerable<T> Query<T>(string sqlCommand, object parameters = null, bool buffered = false, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null);

        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(
             string sql, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null);

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(
           string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null);

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        int Execute(string sqlCommand);

        int Execute(string sqlCommand, object parameters);

        int Execute(string sqlCommand, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        #region 存储过程

        IEnumerable<T> ExecuteProcedure<T>(string storedProcName, IDictionary[] parameters);


        IEnumerable<T> ExecuteProcedure<T>(string storedProcName, IDictionary[] parameters = null, bool buffered = false, int? commandTimeout = default(int));

        #endregion
    }
}
