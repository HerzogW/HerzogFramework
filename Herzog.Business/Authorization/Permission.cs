using Herzog.Interface;
using Herzog.Model.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Herzog.Business.Authorization
{
    public class PermissionBLL
    {
        private IDataBase db = DbHelper.GetDbInstance();

        public bool InsertPermission(PermissionModel model)
        {
            return db.Insert<PermissionModel>(model);
        }

        public bool UpdatePermission(PermissionModel model)
        {
            return db.Update<PermissionModel>(model);
        }

        public bool DeletePermission(PermissionModel model)
        {
            return db.Delete<PermissionModel>(model);
        }

        public bool DeletePermissions(List<PermissionModel> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                throw new ArgumentNullException("entities");
            }

            return db.Delete<PermissionModel>(entities);
        }

        public bool DeletePermissions(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                throw new ArgumentNullException("ids");
            }

            List<PermissionModel> entities = new List<PermissionModel>();
            foreach (var id in ids)
            {
                entities.Add(new PermissionModel() { Id = id });
            }

            return db.Delete<PermissionModel>(entities);
        }

        public PermissionModel GetPermission(string id)
        {
            return db.Get<PermissionModel>(id);
        }

        public List<PermissionModel> GetAllPermissions()
        {
            return db.GetAll<PermissionModel>().ToList();
        }
    }
}
