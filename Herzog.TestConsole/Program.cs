using Herzog.Database;
using Herzog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sqlCommand = "";
            HDatabase db = new HDatabase();

            //db.Insert<TestEntity>(new TestEntity() { Id = Guid.NewGuid().ToString(), Name = "Wangwenjia" });
            //db.Update<TestEntity>(new TestEntity() { Id = "6ae644f7-aae9-41b7-98f7-a96d30b2b4a0", Name = "Wangwenjia111" });
            //db.Delete<TestEntity>(new TestEntity() { Id = "6ae644f7-aae9-41b7-98f7-a96d30b2b4a0", Name = "Wangwenjia" });

            var ListEntities = db.GetAll<TestEntity>();
            foreach (var item in ListEntities)
            {
                Console.WriteLine("Id = {0},UserName = {1}", item.Id, item.Name);
            }

            Console.ReadKey();
        }
    }
}
