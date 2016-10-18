using Herzog.Interface;
using Herzog.MySqlDB;
using Herzog.OracleDB;
using Herzog.SqlServerDB;
using System.Configuration;

namespace Herzog.Factory
{
    public class DbFactory
    {
        private static string sqlConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public static IDataBase CreateDbInstance(DataBaseType type)
        {
            IDataBase db;
            switch (type)
            {
                case DataBaseType.MySQLDB:
                    db = new MySqlDb(sqlConnectionString);
                    break;
                case DataBaseType.OracleDB:
                    db = new OracleDb(sqlConnectionString);
                    break;
                //case DBType.PostgreSQLDB:

                //    break;
                //case DBType.SQLCEServerDB:

                //    break;
                //case DBType.SQLiteDB:

                //    break;
                case DataBaseType.SQLServerDB:
                    db = new SqlServerDb(sqlConnectionString);
                    break;
                default:
                    db = new SqlServerDb(sqlConnectionString);
                    break;
            }

            return db;
        }
    }
}
