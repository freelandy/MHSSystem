using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionBox.Business
{
    public class User
    {
        private readonly Repository.User da = new Repository.User();

        public List<Entity.User> Get(string where)
        {
            return da.Get(where);
        }

        public int Insert(Entity.User user)
        {
            return da.Insert(user);
        }

        public bool Update(Entity.User user)
        {
            return da.Update(user);
        }

        public bool Delete(int id)
        {
            return da.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns>0: success; 1: loginName does not exist; 2: invalid password</returns>
        public void Login(string loginName, string password)
        {

        }


        public void GetRoles()
        {

        }


        public void GetDepartment()
        {


        }


        public void GetModules()
        {

        }

        public void GetOperations()
        {

        }
    }
}
