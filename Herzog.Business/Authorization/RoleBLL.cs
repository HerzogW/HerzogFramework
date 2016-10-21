using Herzog.Interface;
using Herzog.Model.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Business.Authorization
{
    public class RoleBLL
    {
        private IDataBase db = DbHelper.GetDbInstance();


        public bool InsertRole(RoleModel model)
        {
            return db.Insert<RoleModel>(model);
        }

        public bool UpdateRole(RoleModel model)
        {
            return db.Update<RoleModel>(model);
        }

        public bool DeleteRole(RoleModel model)
        {
            return db.Delete<RoleModel>(model);
        }

        public bool DeleteRoles(List<RoleModel> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                throw new ArgumentNullException("entities");
            }

            return db.Delete<RoleModel>(entities);
        }

        public bool DeletePermissions(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                throw new ArgumentNullException("ids");
            }

            List<RoleModel> entities = new List<RoleModel>();
            foreach (var id in ids)
            {
                entities.Add(new RoleModel() { Id = id });
            }

            return db.Delete<RoleModel>(entities);
        }

        public RoleModel GetRole(string id)
        {
            return db.Get<RoleModel>(id);
        }

        public List<RoleModel> GetAllRoles()
        {
            return db.GetAll<RoleModel>().ToList();
        }
    }
}
