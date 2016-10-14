using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.IDatabase
{
    public interface IDatabase
    {
        void ExecuteSql(string SqlCommandText);
    }
}
