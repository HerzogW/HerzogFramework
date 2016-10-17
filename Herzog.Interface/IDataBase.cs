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
        bool Insert<T>(T Entity) where T : class;

        bool Insert<T>(T Entity, IDbTransaction transaction = null, int? commandTimeOut = null) where T : class;

        bool Update<T>(T Entity) where T : class;

        bool Update<T>(T Entity, IDbTransaction transaction = null, int? commandTimeOut = null) where T : class;

        bool Delete<T>(T Entity) where T : class;

        bool Delete<T>(T Entity, IDbTransaction transaction = null, int? commandTimeOut = null) where T : class;

        bool DeleteAll<T>(IDbTransaction transaction = null, int? commandTimeOut = null) where T : class;

        T Get<T>(string id) where T : class;

        T Get<T>(string id, IDbTransaction transaction, int? commandTimeOut) where T : class;

        IEnumerable<T> GetAll<T>() where T : class;

        IEnumerable<T> GetAll<T>(IDbTransaction transaction, int? commandTimeOut) where T : class;


        IEnumerable<T> Query<T>(string sqlCommand);

        IEnumerable<T> Query<T>(string sqlCommand, object parameters);

        IEnumerable<T> Query<T>(string sqlCommand, object parameters = null, IDbTransaction transaction = null, bool buffered = false, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?));

        #region 存储过程

        IEnumerable<T> RunProcedure<T>(string storedProcName, IDictionary[] parameters);

        #endregion
    }
}
