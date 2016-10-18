using Herzog.Factory;
using Herzog.Interface;
using Herzog.Model;
using System;
using System.Data;

namespace Herzog.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sqlCommand = "";
            IDataBase db = DbFactory.CreateDbInstance(DataBaseType.SQLServerDB);

            //db.Insert<TestEntity>(new TestEntity() { Id = Guid.NewGuid().ToString(), Name = "Wangwenjia" });
            //db.Update<TestEntity>(new TestEntity() { Id = "6ae644f7-aae9-41b7-98f7-a96d30b2b4a0", Name = "Wangwenjia111" });
            //db.Delete<TestEntity>(new TestEntity() { Id = "6ae644f7-aae9-41b7-98f7-a96d30b2b4a0", Name = "Wangwenjia" });

            //var result = db.GetAll<TestEntity>();
            //foreach (var item in result)
            //{
            //    Console.WriteLine("Id = {0}, Name =  {1}", item.Id, item.Name);
            //}

            //Console.WriteLine("***********************************");

            //var entity = db.Get<TestEntity>("a11cd74b-e93a-4d54-b8d0-0165c7226a4c");
            //if (entity != null)
            //{
            //    Console.WriteLine("Id = {0}, Name =  {1}", entity.Id, entity.Name);
            //}

            Console.ReadKey();
        }
    }
}
