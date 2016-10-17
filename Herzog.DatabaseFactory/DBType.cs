using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Factory
{
    public enum DataBaseType
    {
        //For MySql Server
        MySQLDB,

        //For Oracle Server
        OracleDB,

        //For Postgres Server
        PostgreSQLDB,

        //For SqlCe Server
        SQLCEServerDB,

        //For SQLite Server
        SQLiteDB,

        //For MS Sql Server
        SQLServerDB,
    }
}
