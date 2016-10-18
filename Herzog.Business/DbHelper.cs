using Herzog.Factory;
using Herzog.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Business
{
    public class DbHelper
    {
        public static IDataBase GetDbInstance()
        {
            return DbFactory.CreateDbInstance(DataBaseType.SQLServerDB);
        }
    }
}
