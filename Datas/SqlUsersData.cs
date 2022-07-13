using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dot_bioskop.Interfaces;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Datas
{
    public class SqlUsersData : IUsersData
    {
        private MyDBContext _myDBContext;

        public SqlUsersData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public users AddUser(users user)
        {
            _myDBContext.users.Add(user);
            _myDBContext.SaveChanges();
            return user;
        }

        public void DeleteUser(users user)
        {
            _myDBContext.users.Remove(user);
            _myDBContext.SaveChanges();
        }

        public users GetUser(int id)
        {
            var user = _myDBContext.users.Find(id);
            return user;
        }

        public List<users> GetUsers()
        {
            return _myDBContext.users.ToList();
        }

        public users UpdateUser(users user)
        {
            var existingUser = _myDBContext.users.Find(user.id);
            if(existingUser != null)
            {
                existingUser.name = user.name;
                existingUser.email = user.email;
                existingUser.password = user.password;
                existingUser.avatar = user.avatar;
                existingUser.is_admin = user.is_admin;
                _myDBContext.users.Update(existingUser);
                _myDBContext.SaveChanges();
            }
            return user;
        }
    }
}
