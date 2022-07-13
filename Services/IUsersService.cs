using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface IUsersService
    {
        public List<users> GetUsers();

        public users AddUsers(users user);

        public users UpdateUsers(int id, users user);

        public string DeleteUsers(int id);
    }
}
