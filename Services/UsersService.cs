using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class UsersService : IUsersService
    {
        private List<users> _usersItem;

        public UsersService()
        {
            _usersItem = new List<users>();
        }

        public List<users> GetUsers()
        {
            return _usersItem;
        }

        public users AddUsers(users customers)
        {
            _usersItem.Add(customers);
            return customers;
        }

        public users UpdateUsers(int id, users user)
        {
            for (var index = _usersItem.Count - 1; index >= 0; index--)
            {
                if (_usersItem[index].id == id)
                {
                    _usersItem[index] = user;
                }
            }
            return user;
        }

        public string DeleteUsers(int id)
        {
            for (var index = _usersItem.Count - 1; index >= 0; index--)
            {
                if (_usersItem[index].id == id)
                {
                    _usersItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
