using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Dapper.Contrib
{
    public static class PropertyInfoExtension
    {

        public static string GetColumnName(this PropertyInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            string name = property.Name;
            foreach (var item in property.CustomAttributes)
            {
                if (item.AttributeType.Name.Equals("ColumnAttribute"))
                {
                    if (item.ConstructorArguments.Count > 0)
                    {
                        name = item.ConstructorArguments[0].Value.ToString();
                    }
                }
            }

            return name;
        }
    }
}
