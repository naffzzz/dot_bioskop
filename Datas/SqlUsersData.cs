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

        public users ActivationUser1(logins login)
        {
            var existingUser = _myDBContext.users.Where(b => b.email == login.email).Where(b => b.password == login.password).Where(b => b.activation_key == login.activation_key).FirstOrDefault();
            return existingUser;
        }

        public users ActivationUser2(logins login)
        {
            var existingUser = _myDBContext.users.Where(b => b.email == login.email).Where(b => b.password == login.password).Where(b => b.activation_key == login.activation_key).FirstOrDefault();
            if (existingUser != null)
            {
                existingUser.is_confirmed = 1;
                _myDBContext.users.Update(existingUser);
                _myDBContext.SaveChanges();
            }

            return existingUser;
        }

        public void DeleteUser(users user)
        {
            _myDBContext.users.Remove(user);
            _myDBContext.SaveChanges();
        }

        public users GetUser(int id)
        {
            var user = _myDBContext.users.Where(b => b.id == id).FirstOrDefault(); 
            return user;
        }
        public users LoginUser(logins login)
        {
            var user = _myDBContext.users.Where(b => b.email == login.email).Where(b => b.password == login.password).Where(b => b.is_confirmed == 1).FirstOrDefault();
            return user;
        }
        
        public List<users> GetUsers()
        {
            return _myDBContext.users.ToList();
        }

        public users SoftDeleteUser(users user)
        {
            var existingUser = _myDBContext.users.Where(b => b.id == user.id).FirstOrDefault(); 
            if (existingUser != null)
            {
                existingUser.deleted_at = user.deleted_at;
                _myDBContext.users.Update(existingUser);
                _myDBContext.SaveChanges();
            }
            return user;
        }

        public users UpdateUser(users user)
        {
            var existingUser = _myDBContext.users.Where(b => b.id == user.id).FirstOrDefault();
            if (existingUser != null)
            {
                existingUser.name = user.name;
                existingUser.email = user.email;
                existingUser.password = user.password;
                existingUser.avatar = user.avatar;
                existingUser.is_admin = user.is_admin;
                existingUser.updated_at = user.updated_at;
                _myDBContext.users.Update(existingUser);
                _myDBContext.SaveChanges();
            }
            return user;
        }
    }
}
